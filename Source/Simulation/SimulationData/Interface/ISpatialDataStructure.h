#pragma once
#include <vector>
#include <memory>
#include "..\Data\SpatialNode.h"
#include "..\ExportMacro.h"

class DLL_API ISpatialDataStructure
{
public:
	virtual std::vector<std::shared_ptr<SpatialNode>> GetNearNodes(const SpatialPoint& node, int searchedAreaSideSize) const  = 0;
	virtual std::vector<std::shared_ptr<SpatialNode>> GetNearNodes(const SpatialPoint& node) const = 0;

	//TODO move out, it don't have to be available to engine
	virtual bool Insert(std::shared_ptr<SpatialNode> node) = 0;
	virtual bool Delete(std::shared_ptr<SpatialNode> node) = 0;
	virtual bool Delete(const std::vector<std::shared_ptr<SpatialNode>>& node) = 0;
};

