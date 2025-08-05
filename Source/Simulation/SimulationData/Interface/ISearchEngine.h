#pragma once
#include <vector>
#include "..\Data\SpatialPoint.h"
#include "..\Data\SpatialNode.h"
#include "..\ExportMacro.h"


class DLL_API ISearchEngine
{
public:
	virtual SpatialNode ProduceNode() const = 0;
	virtual void NodeRewire(SpatialNode& node) = 0;
	virtual	std::vector<const SpatialPoint&> PathToGoal(const SpatialPoint& goalPotition) const = 0;
	virtual void RewireAroundPoint(const SpatialPoint& point) = 0;
};