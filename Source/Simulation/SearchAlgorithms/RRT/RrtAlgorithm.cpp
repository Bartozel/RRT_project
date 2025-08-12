#include "../Math/SpatialCalculator.h"
#include "RrtAlgorithm.h"

RrtAlgorithm::RrtAlgorithm(unsigned searchDistance) :
	m_rd(),
	m_engine(m_rd()),
	m_dist(0, searchDistance),
	m_maxDistanceBetweenNodes(20) //TODO it is env dependent, so it should be set based on that
{
}

SpatialPoint RrtAlgorithm::GenerateSpatialPoint()
{
	return SpatialPoint(m_dist(m_engine), m_dist(m_engine));
}

void RrtAlgorithm::SteerToParent(SpatialPoint& steeredNode, const std::shared_ptr<SpatialNode>& parent)
{
	auto distance = SpatialCalculator::ExactDistance(steeredNode, *parent.get());

	SteerToParent(steeredNode, distance);
}

void RrtAlgorithm::SteerToParent(SpatialPoint& steeredNode, float parentDistance)
{
	if (parentDistance > m_maxDistanceBetweenNodes) {
		auto ration = m_maxDistanceBetweenNodes / parentDistance;

		steeredNode.SetX(steeredNode.GetX() * ration);
		steeredNode.SetY(steeredNode.GetY() * ration);
		steeredNode.SetZ(steeredNode.GetZ() * ration);
	}
}

bool RrtAlgorithm::UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes) const
{
	if (nearNodes.empty()) {
		return false;
	}

	auto nearestNode = GetNearestWithDistance(referenceNode, nearNodes);
	auto newParent = std::get<0>(nearestNode);
	auto distanceToParent = std::get<1>(nearestNode);

	if (*newParent.get() != referenceNode.Parent()) {
		referenceNode.SetParent(newParent.get(), distanceToParent);
	}

	return true;
}

std::tuple<std::shared_ptr<SpatialNode>, float> RrtAlgorithm::GetNearestWithDistance(const SpatialPoint& referencePoint, const std::vector<std::shared_ptr<SpatialNode>> nearNodes) const
{
	if (nearNodes.empty()) {
		//this can happen only when root will try to find other nodes in empty spatial structure
		throw std::runtime_error("FindNearest - nearNodes collection is empty");
	}

	auto lowestDistance = std::numeric_limits<float>::max();
	std::shared_ptr<SpatialNode> nearestNode = nearNodes[0];

	for (const auto& nearNode : nearNodes) {

		auto distance = SpatialCalculator::DistanceSquared(referencePoint, *nearNode.get());

		if (distance < lowestDistance) {
			lowestDistance = distance;
			nearestNode = nearNode;
		}
	}

	return std::make_tuple(nearestNode, lowestDistance);
}
