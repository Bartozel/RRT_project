#include "AgentBase.h"
#include "MotionModelFactory.h"
#include "SpatialDataStructureFactory.h"

AgentBase::AgentBase(unsigned id, const AgentSetting& agentSetting, const SpatialPoint& startPosition) :
	m_movement(MotionModelFactory::GetMotionModel(agentSetting.MotionModelSetting)),
	m_mappedEnvinronment(SpatialDataStructureFactory::GetEnvinronment(agentSetting.SpatialDataSetting)),
	m_goalPosition(startPosition)
{
}

void AgentBase::SetOwnPosition(const SpatialPoint& newPosition)
{

}

void AgentBase::SetGoal(const SpatialPoint& goalPosition)
{
	m_goalPosition = SpatialPoint(goalPosition);
}