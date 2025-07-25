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

protected:
	unsigned X;
	unsigned Y;
};