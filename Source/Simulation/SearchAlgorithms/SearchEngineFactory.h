#pragma once
#include <memory>
#include "ExportMacro.h"
#include "Data\SearchEngineSetting.h"
#include "Interface\ISearchEngine.h"
#include "Interface\ISpatialDataStructure.h"

class DLL_API SearchEngineFactory
{
public:
	static std::unique_ptr<ISearchEngine> GetSearchEngine(const SearchEngineSetting& setting, std::shared_ptr<ISpatialDataStructure> dataMap);
};

