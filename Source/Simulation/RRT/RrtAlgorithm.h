#pragma once
#include <random>

#include <Interface/IRrtAlgorithm.h>
#include <Data/SpatialPoint.h>

class RrtAlgorithm : public IRrtAlgorithm
{
public:
	RrtAlgorithm();

public:
	std::shared_ptr<SpatialNode> GetNewNode() override;
	bool UpdateNodeParent(SpatialNode& referenceNode, const std::vector<std::shared_ptr<SpatialNode>>& nearNodes)const override;

private:
	SpatialPoint CreateSpatialPoint() const;
	void SteerToNearestNode(SpatialPoint& steeredNode);
	std::shared_ptr<SpatialNode> FindNearestAvailableNode(const SpatialPoint& sp);

private:
	std::random_device m_rd;
	std::mt19937 m_engine;
	std::uniform_int_distribution<int> m_dist;
};

