#pragma once
#include "..\..\ExportMacro.h"

/// <summary>
/// Represent a setting for a area in which Agent work and collaborate
/// </summary>
struct DLL_API ArenaSetting
{
public:
	size_t NummberParalelizationThreads = 2;
	float TickDuration = 1 / 60;
};

