#pragma once
#include <memory>
#include "SearchEngineSetting.h"
#include "MotionModelSetting.h"
#include "SpatialDataStructureSetting.h"

/// <summary>
/// Agent setting provide complex object which helps to encapsulate all settings necessary for IAgent. Structure comes from IAgent description.
/// </summary>
struct DLL_API AgentSetting
{
public:
	AgentSetting(MotionModelSetting&& movementSetting, SearchEngineSetting&& searchEngineSetting, SpatialDataStructureSetting&& spatialDataSetting) :
		MotionModelSetting(std::move(movementSetting)), 
		SearchEngineSetting(std::move(searchEngineSetting)), 
		SpatialDataSetting(std::move(spatialDataSetting))
	{
	}

	MotionModelSetting MotionModelSetting;
	SearchEngineSetting SearchEngineSetting;
	SpatialDataStructureSetting SpatialDataSetting;
};