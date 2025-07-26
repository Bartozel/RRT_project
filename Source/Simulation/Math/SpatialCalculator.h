#pragma once
#include <Data/SpatialNode.h>

#define DLL_API __declspec(dllexport)

class DLL_API SpatialCalculator
{
public:
	static float DistanceSquared(const SpatialPoint& a, const SpatialPoint& b);
	static inline float ExactDistance(const SpatialPoint& a, const SpatialPoint& b);

private:
	SpatialCalculator() {};
};

