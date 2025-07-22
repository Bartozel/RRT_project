#include "RrtSearchEngine.h"
#include "RrtAlgorithm.h"

RrtSearchEngine::RrtSearchEngine(eRrtAlgorithm algorithmType, const ISpatialDataStructure& rrtTree) :
	m_rrtSpatialGenerator(CreateGenerator(algorithmType)),
	m_rrtTree(rrtTree),
	m_rd(),
	m_engine(m_rd()),
	m_dist(0, 1000) // TODO - make dynamic + canvas size may not be square
{
}

SpatialNode RrtSearchEngine::GetNode()
{
	SpatialPoint sp = CreateSpatialPoint();
	SteerToNearestNode(&sp);

	return SpatialNode(sp.X, sp.Y);
}

IRrtAlgorithm RrtSearchEngine::CreateGenerator(eRrtAlgorithm algorithmType)
{
	switch (algorithmType)
	{
	case RRT:
		return RrtAlgorithm();
		break;
	case RRT_START:
	case RRT_INFORMED:
	case RRT_X:
	default:
		return RrtAlgorithm();
		break;
	}
}
