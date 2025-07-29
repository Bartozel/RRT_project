#pragma once
class SpatialDataStructureFactory
{
public:
	static std::shared_ptr<ISpatialDataStructure> GetEnvinronment(const SpatialDataStructureSetting& setting);
};

