#include "RrtAgent.h"
#include "Data/SpatialNodeMap.h"
#include "../SearchAlgorithms/RRT/RrtSearchEngine.h" //TODO
#include "../Movement/SimulationMovement.h" // TODO

RrtAgent::RrtAgent(eRrtAlgorithm searchAlgorithm, SpatialPoint startPosition) :
	m_ownPosition(startPosition),
	m_goalPosition(startPosition),
	m_mappedEnvinronment(std::make_shared<SpatialNodeMap>()), //TODO - could be more dynamic in case I want different implementation of an evn more suitable for specific search engine
	m_searchEngine(std::make_unique<RrtSearchEngine>(RrtSearchEngine(searchAlgorithm, m_mappedEnvinronment))),
	m_movement(std::make_unique<SimulationMovement>()) // TODO - could be more dynamic. In theory we  have Simulation and Real HW movement
{
}
