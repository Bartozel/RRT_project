#pragma once
#include "..\ExportMacro.h"

class DLL_API IRrtAlgorithm
{
public:
	virtual SpatialPoint GenerateSpatialPoint() = 0;
	virtual void SteerToParent(SpatialPoint& point, const std::shared_ptr<SpatialNode>& nearNode) = 0;
	virtual void SteerToParent(SpatialPoint& steeredNode, float parentDistance) = 0;
	virtual bool UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes) const = 0;
	virtual std::tuple<std::shared_ptr<SpatialNode>, float> GetNearestWithDistance(const SpatialPoint& referencePoint, const std::vector<std::shared_ptr<SpatialNode>> nearNodes) const = 0;
};