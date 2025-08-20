#pragma once
#include <vector>
#include <memory>
#include "..\Data\SpatialNode.h"
#include "..\ExportMacro.h"

/// <summary>
/// Data structure mapped by the agent. Env is continuously resized, updated with information gained via IAgent sensors.
/// Contains data about mapped obstacles
/// </summary>
class DLL_API ISpatialDataStructure
{
public:
	virtual const SpatialPoint& GetOwnPosition() const = 0;
	virtual void UpdateOwnPostion(const SpatialPoint& ownPosition) = 0;
	virtual bool Insert(std::shared_ptr<SpatialNode> node) = 0;
	virtual bool Delete(std::shared_ptr<SpatialNode> node) = 0;
	virtual bool Delete(const std::vector<std::shared_ptr<SpatialNode>>& node) = 0;
};

