#include <cmath>
#include "SpatialCalculator.h"


float SpatialCalculator::DistanceSquared(const SpatialPoint& a, const SpatialPoint& b)
{
	auto dx = a.GetX() - b.GetX();
	auto dy = a.GetX() - b.GetX();

	return dx * dx + dy * dy;
}

inline float SpatialCalculator::ExactDistance(const SpatialPoint& a, const SpatialPoint& b)
{
	const float dx = a.GetX() - b.GetX();
	const float dy = a.GetX() - b.GetX();

	return std::sqrtf(dx * dx + dy * dy);
}