#pragma once
#include "Interface/ISpatialDataStructure.h"
#include "Enum/eRrtAlgorithm.h"
#include "Data/SpatialNode.h"
#include "Interface/IRrtAlgorithm.h"

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
	/// <param name="rrtTree">Provides available spatial data.</param>
	RrtSearchEngine(eRrtAlgorithm algorithmType, std::shared_ptr<ISpatialDataStructure> rrtTree);

public:
	SpatialNode ProduceNode() const;
	void NodeRewire(SpatialNode& node);
	void RewireAroundPoint(const SpatialPoint& point);

private:
	std::unique_ptr<IRrtAlgorithm> CreateGenerator(eRrtAlgorithm algorithmType) const;

private:
	std::unique_ptr<IRrtAlgorithm> m_rrtAlgorithm;
	std::shared_ptr<ISpatialDataStructure> m_rrtTree;
};