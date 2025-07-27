#include "../Math/SpatialCalculator.h"
#include "RrtAlgorithm.h"

RrtAlgorithm::RrtAlgorithm() :
	m_rd(),
	m_engine(m_rd()),
	m_dist(0, 1000) // TODO - make dynamic + canvas size may not be square
{
	MaxDistance = 20; //TODO it shoudl be settable
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

void RrtAlgorithm::SteerToParent(SpatialPoint& steeredNode, const float& parentDistance)
{
	if (parentDistance > MaxDistance) {
		auto ration = MaxDistance / parentDistance;

		auto newX = steeredNode.GetX() * ration;
		auto newY = steeredNode.GetY() * ration;

		steeredNode = SpatialPoint(newX, newY);
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
		throw std::runtime_error("FindNearest - nearNodes collection is empty"); //TODo it shouldn't happen. Notify in case it does, so it is possible to prevent it.
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
