#pragma once
#include "Interface\IMotionModel.h"
#include "Data\MotionModelSetting.h"

class LinearMotionModel : public IMotionModel
{
public:
	LinearMotionModel(const MotionModelSetting& setting);
};

