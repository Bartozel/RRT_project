#pragma once
#include "..\ExportMacro.h"
#include "..\Data\SpatialPoint.h"

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

	//virtual const SpatialPoint& Move(); TODO

protected:
	unsigned m_id;
};
