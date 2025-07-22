#pragma once
#include <random>
#include <SpatialNode.h>
#include <IRrtAlgorithm.h>
#include <ISpacialDataManager.h>
#include <Enum.h>

#include "SpatialPoint.h"
#include <ISpatialDataStructure.h>

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
	SpatialNode GetNode();
	void Rewire(const SpatialNode& node);

private:
	IRrtAlgorithm CreateGenerator(eRrtAlgorithm algorithmType);
	SpatialPoint CreateSpatialPoint();
	void SteerToNearestNode(SpatialPoint* steeredNode);

private:
	IRrtAlgorithm m_rrtSpatialGenerator;
	const ISpatialDataStructure& m_rrtTree;
	std::random_device m_rd;
	std::mt19937 m_engine;
	std::uniform_int_distribution<int> m_dist;
};