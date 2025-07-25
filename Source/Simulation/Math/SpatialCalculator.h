#pragma once
#include <Data/SpatialNode.h>

#define DLL_API __declspec(dllexport)

class DLL_API SpatialCalculator
{
public:
	static float Distance(const SpatialPoint& a, const SpatialPoint& b);

private:
	SpatialCalculator() {};
};

