#include "RrtSearchEngine.h"
#include "RrtAlgorithm.h"

#include <Enum\eSearchedArea.h>

RrtSearchEngine::RrtSearchEngine(eRrtAlgorithm algorithmType, const ISpatialDataStructure& rrtTree) :
	m_rrtSpatialGenerator(CreateGenerator(algorithmType)),
	m_rrtTree(rrtTree)
{
}

void RrtSearchEngine::NodeRewire(SpatialNode& node)
{
	for (int i = 0; i <= 3; ++i) {

		auto nearNodesCollection = m_rrtTree.GetNearNodes(node, eSearchedArea::Small * i);

		if (m_rrtSpatialGenerator->UpdateNodeParent(node, nearNodesCollection))
		{
			break;
		}
	}
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