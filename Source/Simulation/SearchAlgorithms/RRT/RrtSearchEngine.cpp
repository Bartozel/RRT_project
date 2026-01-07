#include "RrtSearchEngine.h"
#include "RrtAlgorithm.h"
#include "Enum\eSearchedArea.h"
#include "..\Math\SpatialCalculator.h"

RrtSearchEngine::RrtSearchEngine(const SearchEngineSetting& algorithmSetting, std::shared_ptr<ISpatialDataStructure> rrtTree) :
	m_rrtAlgorithm(CreateGenerator(algorithmSetting.AlgorithmType)),
	m_mappedEnv(rrtTree)
{
}

SpatialNode RrtSearchEngine::ProduceNode() const
{
	//auto newPoint = m_rrtAlgorithm->GenerateSpatialPoint();
	//const auto& nearNodes = m_rrtTree->GetNearNodes(newPoint);
	//const auto [parentNode, distanceToParentNode] = m_rrtAlgorithm->GetNearestWithDistance(newPoint, nearNodes);

	//m_rrtAlgorithm->SteerToParent(newPoint, distanceToParentNode);

	//return SpatialNode(parentNode.get(), distanceToParentNode, newPoint);
}

void RrtSearchEngine::NodeRewire(SpatialNode& node)
{
	//const auto& nearNodes = m_rrtTree->GetNearNodes(node);
	//m_rrtAlgorithm->UpdateNodeParent(node, nearNodes);
}

void RrtSearchEngine::RewireAroundPoint(const SpatialPoint& point)
{
	//TODO
}