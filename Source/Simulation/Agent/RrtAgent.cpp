#include "RrtAgent.h"
#include "..\SimulationEnvinronment\SpatialDataStructureFactory.h"
#include "..\SearchAlgorithms\SearchEngineFactory.h"
#include "..\Movement\MotionModelFactory.h"

RrtAgent::RrtAgent(unsigned id, AgentSetting agentSetting, const SpatialPoint& startPosition) :
	m_goalPosition(std::make_shared<SpatialPoint>(startPosition)),
	m_mappedEnvinronment(SpatialDataStructureFactory::GetEnvinronment(agentSetting.SpatialDataSetting)),
	m_searchEngine(SearchEngineFactory::GetSearchEngine(agentSetting.SearchEngineSetting, m_mappedEnvinronment)),
	m_movement(MotionModelFactory::GetMotionModel(agentSetting.MotionModelSetting)),
	IAgent(id)
{
	SetOwnPosition(startPosition);
}

void RrtAgent::SetOwnPosition(const SpatialPoint& newPosition)
{
	m_mappedEnvinronment->UpdateOwnPostion(newPosition);
	m_searchEngine->RewireAroundPoint(newPosition);
}

void RrtAgent::SetGoal(const SpatialPoint& newPosition)
{
	m_goalPosition = std::make_shared<SpatialPoint>(newPosition);
}

//TODO
void RrtAgent::MapEnvironment()
{
}

//TODO
//void RrtAgent::Tick(const double& delta)
//{
//	auto goalPosition = m_goalPosition;
//	auto pathToGoal = m_searchEngine->PathToGoal(*goalPosition);
//
//	if (!pathToGoal.empty()) {
//		auto numberOfPathSegments = pathToGoal.size();
//		auto indexOfNextBreakPoint = numberOfPathSegments > 1 ? numberOfPathSegments - 2 : numberOfPathSegments - 1;
//
//		const auto& nextBreakPoint = pathToGoal[indexOfNextBreakPoint];
//		auto newOwnPosition = m_movement->Move(m_mappedEnvinronment->GetOwnPosition(), nextBreakPoint, delta);
//
//		SetOwnPosition(newOwnPosition);
//	}
//}