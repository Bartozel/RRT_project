#pragma once
#include "..\ExportMacro.h"
#include "..\Data\SpatialPoint.h"

/// <summary>
/// provides an abstraction over an object which goal is to:
/// - map surounding environment based on sensors model
/// - provide a spatial movement between Own and Goal position based on provided motion model.
/// - takes into account local and global navigation
/// - search thru local dynamic, or static envinronment to avoid obstacles
/// </summary>
class DLL_API IAgent
{
public:
	IAgent(unsigned id) :
		m_id(id)
	{

	}
	/// <summary>
	/// Updated regullarly with each IAgent move, or whenever user move agent manually
	/// </summary>
	/// <param name="goalPosition"></param>
	virtual void SetOwnPosition(const SpatialPoint& goalPosition) = 0;
	/// <summary>
	/// Update regullarly with each user update
	/// </summary>
	/// <param name="goal"></param>
	virtual void SetGoal(const SpatialPoint& goal) = 0;

protected:
	unsigned m_id;
};
