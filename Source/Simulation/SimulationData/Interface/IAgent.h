#pragma once
#include "..\Data\SpatialPoint.h"

class DLL_API IAgent
{
	virtual void SetOwnPosition(const SpatialPoint& goalPosition) = 0;
	virtual void SetGoal(const SpatialPoint& goal) = 0;
	virtual void Tick(const double& delta) = 0;
};

