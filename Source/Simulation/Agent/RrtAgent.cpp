#include "RrtAgent.h"
#include "..\SimulationEnvinronment\SpatialDataStructureFactory.h"
#include "..\SearchAlgorithms\SearchEngineFactory.h"
#include "..\Movement\MotionModelFactory.h"

RrtAgent::RrtAgent(unsigned id, const AgentSetting& agentSetting, const SpatialPoint& startPosition) : AgentBase(id),
m_goalPosition(startPosition),
m_mappedEnvinronment(std::make_shared<ISpatialDataStructure>(SpatialDataStructureFactory::GetEnvinronment(agentSetting.SpatialDataSetting))),
m_searchEngine(RrtSearchEngine(agentSetting.SearchEngineSetting, m_mappedEnvinronment)),
m_movement(MotionModelFactory::GetMotionModel(agentSetting.MotionModelSetting))
{
	SetOwnPosition(startPosition);
}

void RrtAgent::SetOwnPosition(const SpatialPoint& newPosition)
{

}

void RrtAgent::SetGoal(const SpatialPoint& newPosition)
{
	m_goalPosition = SpatialPoint(newPosition);
}

void RrtAgent::MapEnvironment()
{
}
