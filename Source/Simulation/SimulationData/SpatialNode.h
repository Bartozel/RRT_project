#pragma once
#include "SpatialPoint.h"

struct SpatialNode : public SpatialPoint
{
public:
	SpatialNode(unsigned x, unsigned y) : SpatialPoint(x, y) {};
	SpatialNode(const SpatialPoint& definingPoint) : SpatialPoint(definingPoint.X, definingPoint.Y) {};;
};

