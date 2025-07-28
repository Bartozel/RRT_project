#pragma once
#include <optional>
#include <Interface/ISpatialDataStructure.h>
#include <Enum/eRrtAlgorithm.h>
#include <Data/SpatialNode.h>
#include <Interface/IRrtAlgorithm.h>

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
	SpatialNode ProduceNode();
	void NodeRewire(SpatialNode& node);

private:
	std::unique_ptr<IRrtAlgorithm> CreateGenerator(eRrtAlgorithm algorithmType) const;

private:
	std::unique_ptr<IRrtAlgorithm> m_rrtAlgorithm;
	std::shared_ptr<ISpatialDataStructure> m_rrtTree;
};