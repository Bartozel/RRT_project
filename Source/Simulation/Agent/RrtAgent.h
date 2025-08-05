#pragma once
#include <memory>

#include "Interface\IAgent.h"
#include "Interface\ISpatialDataStructure.h"
#include "Interface\IMotionModel.h"
#include "Interface\ISearchEngine.h"
#include "Enum\eRrtAlgorithm.h"
#include "Data\AgentSetting.h"

class RrtAgent : public IAgent
{
public:
	RrtAgent(unsigned id, AgentSetting agentSetting, const SpatialPoint& startPosition);

public:
	void SetOwnPosition(const SpatialPoint& newPosition) override;
	void SetGoal(const SpatialPoint& newPosition) override;
	//void Tick(const double& delta) override;

private:
	void MapEnvironment();

private:
	std::shared_ptr<SpatialPoint> m_goalPosition;

	std::unique_ptr<IMotionModel> m_movement;
	std::unique_ptr<ISearchEngine> m_searchEngine;
	std::shared_ptr<ISpatialDataStructure> m_mappedEnvinronment;
};

