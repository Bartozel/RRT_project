#pragma once
#include <random>
#include "Interface/IRrtAlgorithm.h"
#include "Data/SpatialPoint.h"

class RrtAlgorithm : public IRrtAlgorithm
{
public:
	RrtAlgorithm();

public:
	SpatialPoint GenerateSpatialPoint() override;
	void SteerToParent(SpatialPoint& steeredNode, const std::shared_ptr<SpatialNode>& nearNodes) override;
	void SteerToParent(SpatialPoint& steeredNode, float parentDistance) override;
	bool UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes)const override;
	std::tuple<std::shared_ptr<SpatialNode>, float> GetNearestWithDistance(const SpatialPoint& referencePoint, const std::vector<std::shared_ptr<SpatialNode>> nearNodes) const override;

public:
	inline static unsigned MaxDistance;

private:

private:
	std::random_device m_rd;
	std::mt19937 m_engine;
	std::uniform_int_distribution<int> m_dist;
};