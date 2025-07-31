#pragma once
#include "SearchEngineSetting.h"
#include "MotionModelSetting.h"
#include "SpatialDataStructureSetting.h"

struct AgentSetting
{
public:
	AgentSetting(const MotionModelSetting& movementSetting, const SearchEngineSetting& searchEngineSetting, const SpatialDataStructureSetting& spatialDataSetting) :
		MotionModelSetting(movementSetting), SearchEngineSetting(searchEngineSetting), SpatialDataSetting(spatialDataSetting)
	{}

	const MotionModelSetting MotionModelSetting;
	const SearchEngineSetting SearchEngineSetting;
	const SpatialDataStructureSetting SpatialDataSetting;
};