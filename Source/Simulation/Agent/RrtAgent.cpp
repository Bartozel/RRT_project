#include "RrtAgent.h"
#include "..\SimulationEnvinronment\SpatialDataStructureFactory.h"
#include "..\Movement\MotionModelFactory.h"

RrtAgent::RrtAgent(unsigned id, const AgentSetting& agentSetting, const SpatialPoint& startPosition) : AgentBase(id, agentSetting, startPosition),
m_searchEngine(agentSetting.SearchEngineSetting, m_mappedEnvinronment)
{
	SetOwnPosition(startPosition);
}

void RrtAgent::MapEnvironment()
{
}
