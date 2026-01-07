#pragma once
#include <memory>
#include "..\..\ExportMacro.h"
#include "MotionModelSetting.h"
#include "SpatialDataStructureSetting.h"

/// <summary>
/// Agent setting provide complex object which helps to encapsulate all settings necessary for IAgent. Structure comes from IAgent description.
/// </summary>
struct DLL_API AgentSetting
{
public:
	AgentSetting(AgentId id, MotionModelSetting&& movementSetting, SpatialDataStructureSetting&& spatialDataSetting) :
		MotionModelSetting(std::move(movementSetting)), 
		SpatialDataSetting(std::move(spatialDataSetting))
	{	
	}

	AgentId Id;
	MotionModelSetting MotionModelSetting;
	SpatialDataStructureSetting SpatialDataSetting;
};