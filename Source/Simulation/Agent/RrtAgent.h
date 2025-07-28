#pragma once
#include <memory>

#include "Interface\IAgent.h"
#include "Interface\ISpatialDataStructure.h"
#include "Interface\IAgentMovement.h"
#include "Interface\ISearchEngine.h"
#include "Enum\eRrtAlgorithm.h"

class RrtAgent : public IAgent
{
public:
	RrtAgent(eRrtAlgorithm searchAlgorithm, SpatialPoint startPosition);

public:
	void SetOwnPosition(const SpatialPoint& goalPosition) override;
	void SetGoal(const SpatialPoint& goalPosition) override;
	void Tick(const double& delta) override;

private:
	SpatialPoint m_ownPosition;
	SpatialPoint m_goalPosition;

	std::unique_ptr<IAgentMovement> m_movement;
	std::unique_ptr<ISearchEngine> m_searchEngine;
	std::shared_ptr<ISpatialDataStructure> m_mappedEnvinronment;
};

