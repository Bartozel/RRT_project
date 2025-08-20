#pragma once
#include "..\ExportMacro.h"
#include "..\Data\SpatialPoint.h"

/// <summary>
/// Provides a necessary abstraction over agent movement
/// </summary>
class DLL_API IMotionModel
{
public:
	virtual SpatialPoint Move(const SpatialPoint& startPoint, const SpatialPoint& endPoin, const double& timeDelta) const = 0;
};

