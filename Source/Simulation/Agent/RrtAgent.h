#pragma once
#include <memory>

#include "AgentBase.h"
#include "RRT\RrtSearchEngine.h"
#include "Data\AgentSetting.h"

/// <summary>
/// Extend AgentBase with search engine, which enables local navigation.
/// </summary>
class RrtAgent : public AgentBase
{
public:
	RrtAgent(unsigned id, const AgentSetting& agentSetting, const SpatialPoint& startPosition);

private:
	void MapEnvironment();

private:
	/// <summary>
	/// It provides an acess to different rrt based algorithms
	/// </summary>
	RrtSearchEngine m_searchEngine;
};

