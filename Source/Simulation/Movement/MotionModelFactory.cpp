#include "MotionModelFactory.h"
#include "Enum\eMotionType.h"
#include "LinearMotionModel.h"


std::unique_ptr<IMotionModel> MotionModelFactory::GetMotionModel(const MotionModelSetting& setting)
{
	switch (setting.GetType())
	{
	case Linear:
		return std::make_unique<LinearMotionModel>(setting);
	default:
		break;
	}
}
