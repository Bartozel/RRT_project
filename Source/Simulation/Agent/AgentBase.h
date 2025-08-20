#pragma once
#include <memory>
#include "Interface\IAgent.h"

/// <summary>
/// Create an abstract class which implements base behaviour. Like movement, sensor data gathering.
/// </summary>
class AgentBase : public  IAgent
{
public:

private:
	/// <summary>
	/// position at which agen tries to get
	/// TODO object is copied, for current atructure it is cheap, revisit at the end
	/// </summary>
	SpatialPoint m_goalPosition;
	/// <summary>
	/// It provides a movement ability. Agent moves as model describes
	/// </summary>
	std::unique_ptr<IMotionModel> m_movement;
	/// <summary>
	/// It contain mapped envinronment.
	/// </summary>
	std::shared_ptr<ISpatialDataStructure> m_mappedEnvinronment;
};

