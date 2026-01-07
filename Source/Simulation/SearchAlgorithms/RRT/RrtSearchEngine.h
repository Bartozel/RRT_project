#pragma once
#include "Enum/eSearchAlgorithm.h"
#include "Data/SpatialNode.h"
#include "Data/SearchEngineSetting.h"
#include "Interface/IRrtAlgorithm.h"
#include "Interface/ISpatialDataStructure.h"


/// <summary>
/// Interlink data produced by rrt algorithm, with alghorithm calculation when it is needed.
/// </summary>
class RrtSearchEngine
{
public:
	/// <summary>
	/// 
	/// </summary>
	/// <param name="algorithmType">Defines under what algorithm engine produces spatial data.</param>
	/// <param name="mappedEnv">Provides available spatial data.</param>
	RrtSearchEngine(const SearchEngineSetting& algorithmSetting, std::shared_ptr<ISpatialDataStructure> mappedEnv);

public:
	SpatialNode ProduceNode() const;
	void NodeRewire(SpatialNode& node);
	void RewireAroundPoint(const SpatialPoint& point);

private:

private:
	std::unique_ptr<IRrtAlgorithm> m_rrtAlgorithm;
	std::shared_ptr<ISpatialDataStructure> m_mappedEnv;
};