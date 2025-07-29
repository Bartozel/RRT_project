#include "RrtAgent.h"
#include "..\SimulationEnvinronment\SpatialDataStructureFactory.h"
#include "..\SearchAlgorithms\SearchEngineFactory.h"
#include "..\Movement\MotionModelFactory.h"


RrtAgent::RrtAgent(AgentSetting agentSetting, SpatialPoint startPosition) :
	m_ownPosition(startPosition),
	m_goalPosition(startPosition),
	m_mappedEnvinronment(SpatialDataStructureFactory::GetEnvinronment(agentSetting.SpatialDataSetting)),
	m_searchEngine(SearchEngineFactory::GetSearchEngine(agentSetting.SearchEngineSetting, m_mappedEnvinronment)),
	m_movement(MotionModelFactory::GetMotionModel(agentSetting.MotionModelSetting))
{
}
