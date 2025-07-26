#include "../Math/SpatialCalculator.h"
#include "RrtAlgorithm.h"

RrtAlgorithm::RrtAlgorithm() :
	m_rd(),
	m_engine(m_rd()),
	m_dist(0, 1000) // TODO - make dynamic + canvas size may not be square
{
}

SpatialPoint RrtAlgorithm::GenerateSpatialPoint()
{
	return SpatialPoint(m_dist(m_engine), m_dist(m_engine));

}

bool RrtAlgorithm::UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes) const
{
	if (nearNodes.empty()) {
		return false;
	}

	auto lowestDistance = std::numeric_limits<float>::max();
	SpatialNode* nearestNode = nearNodes[0].get();

	for (const auto& nearNode : nearNodes) {

		auto distance = SpatialCalculator::DistanceSquared(referenceNode, *nearNode.get());

		if (distance < lowestDistance) {
			lowestDistance = distance;
			nearestNode = nearNode.get();
		}
	}

	if (*nearestNode != referenceNode.Parent()) {
		referenceNode.SetParent(nearestNode, lowestDistance);
	}

	return true;
}
