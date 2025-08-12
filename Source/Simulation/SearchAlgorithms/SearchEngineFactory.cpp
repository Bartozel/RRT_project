#include "SearchEngineFactory.h"

std::unique_ptr<ISearchEngine> SearchEngineFactory::GetSearchEngine(const SearchEngineSetting& setting, std::shared_ptr<ISpatialDataStructure> dataMap)
{
	return std::unique_ptr<ISearchEngine>(); //TODO
}