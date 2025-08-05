#pragma once
#include <memory>
#include "ExportMacro.h"
#include "Data/MotionModelSetting.h"
#include "Interface/IMotionModel.h"

class DLL_API MotionModelFactory
{
public:
	static std::unique_ptr<IMotionModel> GetMotionModel(const MotionModelSetting& setting);
};

