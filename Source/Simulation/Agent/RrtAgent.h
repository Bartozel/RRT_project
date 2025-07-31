#pragma once
#include <memory>

#include "Interface\IAgent.h"
#include "Interface\ISpatialDataStructure.h"
#include "Interface\IMovementModel.h"
#include "Interface\ISearchEngine.h"
#include "Enum\eRrtAlgorithm.h"
#include "Data\AgentSetting.h"

class RrtAgent : public IAgent
{
public:
	RrtAgent(AgentSetting agentSetting, const SpatialPoint& startPosition);

public:
	void StartMapEnvinronment() const override;
	void SetOwnPosition(const SpatialPoint& newPosition) override;
	void SetGoal(const SpatialPoint& newPosition) override;
	void Tick(const double& delta) override;

private:
	std::shared_ptr<SpatialPoint> m_goalPosition;

	std::unique_ptr<IMotionModel> m_movement;
	std::unique_ptr<ISearchEngine> m_searchEngine;
	std::shared_ptr<ISpatialDataStructure> m_mappedEnvinronment;
};

