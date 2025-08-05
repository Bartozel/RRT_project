#include "MotionModelFactory.h"

std::unique_ptr<IMotionModel> MotionModelFactory::GetMotionModel(const MotionModelSetting& setting)
{
	return std::unique_ptr<IMotionModel>();
}
