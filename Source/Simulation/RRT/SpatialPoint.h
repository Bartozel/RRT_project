#pragma once
struct SpatialPoint
{
public:
	SpatialPoint(unsigned x, unsigned y) :
		X(x), Y(y)
	{

	}

public:
	unsigned X;
	unsigned Y;
};