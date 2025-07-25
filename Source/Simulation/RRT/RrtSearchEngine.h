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
	/// <param name="algorithmType">Defines under what algorithm engine produces spatial data</param>
	/// <param name="rrtTree">Provides an information about developped spatial tree. Those are used for rewiringand steering processes.</param>
	RrtSearchEngine(eRrtAlgorithm algorithmType, const ISpatialDataStructure& rrtTree);

public:
	std::shared_ptr<SpatialNode> GetNode() { return m_rrtSpatialGenerator->GetNewNode(); };
	void NodeRewire(SpatialNode& node);

private:
	std::unique_ptr<IRrtAlgorithm> CreateGenerator(eRrtAlgorithm algorithmType) const ;
	//std::optional<SpatialNode&> FindNearestNode(const SpatialNode& referenceNode, const std::vector<std::reference_wrapper<SpatialNode>>& nearNodes);

private:
	std::unique_ptr<IRrtAlgorithm> m_rrtSpatialGenerator;
	const ISpatialDataStructure& m_rrtTree;
};