#pragma once
#include <memory>
#include "Interface\ISpatialDataStructure.h"
#include "Data\SpatialDataStructureSetting.h"
#include "ExportMacro.h"

class DLL_API SpatialDataStructureFactory
{
public:
	static std::shared_ptr<ISpatialDataStructure> GetEnvinronment(const SpatialDataStructureSetting& setting);
};