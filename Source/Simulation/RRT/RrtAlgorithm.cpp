#include "../Math/SpatialCalculator.h"
#include "RrtAlgorithm.h"

RrtAlgorithm::RrtAlgorithm() :
	m_rd(),
	m_engine(m_rd()),
	m_dist(0, 1000) // TODO - make dynamic + canvas size may not be square
{
}

std::shared_ptr<SpatialNode> RrtAlgorithm::GetNewNode()
{
	auto sp = CreateSpatialPoint();
	auto nn = FindNearestAvailableNode(sp);
	SteerToNearestNode(sp);

	auto sn = std::make_shared<SpatialNode>(nn.get(), SpatialCalculator::Distance(sp, *nn.get()), sp);
	nn.get()->AddChild(std::move(sn));

	return sn;
}

bool RrtAlgorithm::UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes) const
{
	if (nearNodes.empty()) {
		return false;
	}

	auto lowestDistance = std::numeric_limits<float>::max();
	SpatialNode* nearestNode = nearNodes[0].get();

	for (const auto& nearNode : nearNodes) {

		auto distance = SpatialCalculator::Distance(referenceNode, *nearNode.get());

		if (distance < lowestDistance) {
			lowestDistance = distance;
			nearestNode = nearNode.get();
		}
	}

	referenceNode.SetParent(nearestNode, lowestDistance);

	return true;
}