#include "RrtAgent.h"
#include "..\SimulationEnvinronment\SpatialDataStructureFactory.h"
#include "..\SearchAlgorithms\SearchEngineFactory.h"
#include "..\Movement\MotionModelFactory.h"

RrtAgent::RrtAgent(AgentSetting agentSetting, const SpatialPoint& startPosition) :
	m_goalPosition(std::make_shared<SpatialPoint>(startPosition)),
	m_mappedEnvinronment(SpatialDataStructureFactory::GetEnvinronment(agentSetting.SpatialDataSetting, startPosition)),
	m_searchEngine(SearchEngineFactory::GetSearchEngine(agentSetting.SearchEngineSetting, m_mappedEnvinronment)),
	m_movement(MotionModelFactory::GetMotionModel(agentSetting.MotionModelSetting))
{

}

void RrtAgent::SetOwnPosition(const SpatialPoint& newPosition)
{
	m_mappedEnvinronment.get()->UpdateOwnPostion(newPosition);
	m_searchEngine.get()->RewireAroundPoint(newPosition);
}

void RrtAgent::SetGoal(const SpatialPoint& newPosition)
{
	m_goalPosition = std::make_shared<SpatialPoint>(newPosition);
}

void RrtAgent::Tick(const double& delta)
{
	auto goalPosition = m_goalPosition;
	auto pathToGoal = m_searchEngine->PathToGoal(*goalPosition);

	if (!pathToGoal.empty()) {
		auto numberOfPathSegments = pathToGoal.size();
		auto indexOfNextBreakPoint = numberOfPathSegments > 1 ? numberOfPathSegments - 2 : numberOfPathSegments - 1;

		const auto& nextBreakPoint = pathToGoal[indexOfNextBreakPoint];
		auto newOwnPosition = m_movement->Move(m_mappedEnvinronment->OwnPosition, nextBreakPoint, delta);

		SetOwnPosition(newOwnPosition);
	}
}