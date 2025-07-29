#pragma once
#include <Data/MotionModelSetting.h>

class MotionModelFactory
{
public:
	static std::unique_ptr<IMotionModel> GetMotionModel(const MotionModelSetting& setting);
};

