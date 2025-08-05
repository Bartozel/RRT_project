#pragma once
#include "Interface/ISpatialDataStructure.h"
#include "Enum/eRrtAlgorithm.h"
#include "Data/SpatialNode.h"
#include "Interface/IRrtAlgorithm.h"
#include "Interface/ISearchEngine.h"

class RrtSearchEngine : public ISearchEngine
{
public:
	/// <summary>
	/// 
	/// </summary>
	/// <param name="algorithmType">Defines under what algorithm engine produces spatial data.</param>
	/// <param name="rrtTree">Provides available spatial data.</param>
	RrtSearchEngine(eRrtAlgorithm algorithmType, std::shared_ptr<ISpatialDataStructure> rrtTree);

public:
	SpatialNode ProduceNode() const override;
	void NodeRewire(SpatialNode& node) override;
	void RewireAroundPoint(const SpatialPoint& point) override;

private:
	std::unique_ptr<IRrtAlgorithm> CreateGenerator(eRrtAlgorithm algorithmType) const;

private:
	std::unique_ptr<IRrtAlgorithm> m_rrtAlgorithm;
	std::shared_ptr<ISpatialDataStructure> m_rrtTree;
};