#pragma once
#include "..\ExportMacro.h"

struct DLL_API SpatialPoint
{
public:
	SpatialPoint(unsigned x, unsigned y) :
		X(x), Y(y)
	{ }

public:
	unsigned GetX() const { return X; }
	unsigned GetY() const { return Y; }

public:
	bool operator==(const SpatialPoint& other) const {
		return X == other.GetX() && Y == other.GetY();
	}

	bool operator!=(const SpatialPoint& other) const {
		return !(X == Y);
	}

protected:
	unsigned X;
	unsigned Y;
};