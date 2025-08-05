#include "SpatialDataStructureFactory.h"

std::shared_ptr<ISpatialDataStructure> SpatialDataStructureFactory::GetEnvinronment(const SpatialDataStructureSetting& setting)
{
	return std::shared_ptr<ISpatialDataStructure>();
}
