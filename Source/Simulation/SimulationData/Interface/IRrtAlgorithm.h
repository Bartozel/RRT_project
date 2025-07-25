#pragma once
#include "..\ExportMacro.h"

class DLL_API IRrtAlgorithm
{
public:
	virtual std::shared_ptr<SpatialNode> GetNewNode() = 0;
	virtual bool UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes) const = 0;
};

