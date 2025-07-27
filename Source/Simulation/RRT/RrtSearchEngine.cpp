#include "RrtSearchEngine.h"
#include "RrtAlgorithm.h"
#include "Enum\eSearchedArea.h"
#include "..\Math\SpatialCalculator.h"

RrtSearchEngine::RrtSearchEngine(eRrtAlgorithm algorithmType, std::shared_ptr<ISpatialDataStructure> rrtTree) :
	m_rrtAlgorithm(CreateGenerator(algorithmType)),
	m_rrtTree(rrtTree)
{
}

SpatialNode RrtSearchEngine::ProduceNode()
{
	auto newPoint = m_rrtAlgorithm->GenerateSpatialPoint();
	const auto& nearNodes = m_rrtTree->GetNearNodes(newPoint);
	const auto& parentNode = m_rrtAlgorithm->GetNearestWithDistance(newPoint, nearNodes);
	float distanceToParent = std::get<1>(parentNode);

	m_rrtAlgorithm->SteerToParent(newPoint, distanceToParent);

	return SpatialNode(std::get<0>(parentNode).get(), distanceToParent, newPoint);
}

void RrtSearchEngine::NodeRewire(SpatialNode& node)
{
	const auto& nearNodes = m_rrtTree->GetNearNodes(node);
	m_rrtAlgorithm->UpdateNodeParent(node, nearNodes);
}

std::unique_ptr<IRrtAlgorithm> RrtSearchEngine::CreateGenerator(eRrtAlgorithm algorithmType) const
{
	switch (algorithmType)
	{
	case RRT:
		return std::make_unique<RrtAlgorithm>();

	case RRT_START:
	case RRT_INFORMED:
	case RRT_X:
	default:
		return std::make_unique<RrtAlgorithm>();
	}
}