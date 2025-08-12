#pragma once
#include <random>
#include "Interface/IRrtAlgorithm.h"
#include "Data/SpatialPoint.h"

class RrtAlgorithm : public IRrtAlgorithm
{
public:
	RrtAlgorithm(unsigned searchDistance);

public:
	SpatialPoint GenerateSpatialPoint() override;
	void SteerToParent(SpatialPoint& steeredNode, const std::shared_ptr<SpatialNode>& nearNodes) override;
	void SteerToParent(SpatialPoint& steeredNode, float parentDistance) override;
	bool UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes)const override;
	std::tuple<std::shared_ptr<SpatialNode>, float> GetNearestWithDistance(const SpatialPoint& referencePoint, const std::vector<std::shared_ptr<SpatialNode>> nearNodes) const override;

public:
	void SetMaxDistanceBetweenNodes(size_t size) {
		m_maxDistanceBetweenNodes = size;
	}

private:
	size_t m_maxDistanceBetweenNodes;
	std::random_device m_rd;
	std::mt19937 m_engine;
	std::uniform_int_distribution<int> m_dist;
};