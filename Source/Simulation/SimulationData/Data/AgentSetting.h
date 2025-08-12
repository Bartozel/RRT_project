#pragma once
#include "SearchEngineSetting.h"
#include "MotionModelSetting.h"
#include "SpatialDataStructureSetting.h"

struct DLL_API AgentSetting
{
public:
	AgentSetting(std::unique_ptr<MotionModelSetting> movementSetting, std::unique_ptr <SearchEngineSetting> searchEngineSetting, std::unique_ptr < SpatialDataStructureSetting> spatialDataSetting) :
		MotionModelSetting(std::move(movementSetting)), SearchEngineSetting(std::move(searchEngineSetting)), SpatialDataSetting(std::move(spatialDataSetting))
	{
	}

	std::unique_ptr <MotionModelSetting> MotionModelSetting;
	std::unique_ptr <SearchEngineSetting> SearchEngineSetting;
	std::unique_ptr <SpatialDataStructureSetting> SpatialDataSetting;
};