#pragma once
#include <memory>
#include "Interface\ISpatialDataStructure.h"
#include "Data\SpatialDataStructureSetting.h"

class SpatialDataStructureFactory
{
public:
	static std::unique_ptr<ISpatialDataStructure> GetEnvinronment(const SpatialDataStructureSetting& setting);
};

