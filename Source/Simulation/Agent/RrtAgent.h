#pragma once
#include <memory>

#include "AgentBase.h"
#include "Interface\ISpatialDataStructure.h"
#include "Interface\IMotionModel.h"
#include "RRT\RrtSearchEngine.h"
#include "Enum\eRrtAlgorithm.h"
#include "Data\AgentSetting.h"

/// <summary>
/// Extend AgentBase with search engine, which enables local navigation.
/// </summary>
class RrtAgent : public AgentBase
{
public:
	RrtAgent(unsigned id, const AgentSetting& agentSetting, const SpatialPoint& startPosition);

public:
	void SetOwnPosition(const SpatialPoint& newPosition) override;
	void SetGoal(const SpatialPoint& newPosition) override;

private:
	void MapEnvironment();

private:
	/// <summary>
	/// It provides an acess to different rrt based algorithms
	/// </summary>
	RrtSearchEngine m_searchEngine;
};

