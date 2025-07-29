#pragma once
class SearchEngineFactory
{
public:
	static std::unique_ptr<ISearchEngine> GetSearchEngine(const SearchEngineSetting& setting, std::shared_ptr<ISpatialDataStructure> dataMap);
};

