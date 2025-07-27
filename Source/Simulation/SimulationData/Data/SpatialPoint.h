#pragma once
#include "..\ExportMacro.h"

struct DLL_API SpatialPoint
{
public:
	SpatialPoint(unsigned x, unsigned y) :
		X(x), Y(y), Z(0)
	{
	}

	SpatialPoint(unsigned x, unsigned y, unsigned z) :
		X(x), Y(y), Z(z)
	{
	}

public:
	unsigned GetX() const { return X; }
	unsigned GetY() const { return Y; }
	unsigned GetZ() const { return Z; }

public:
	bool operator==(const SpatialPoint& other) const {
		return X == other.GetX() && Y == other.GetY() && Z == other.GetZ();
	}

	bool operator!=(const SpatialPoint& other) const {
		return !(X == Y);
	}

protected:
	unsigned X;
	unsigned Y;
	unsigned Z;
};