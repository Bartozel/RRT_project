#pragma once
#include <vector>
#include <mutex>
#include "SpatialPoint.h"
#include "..\ExportMacro.h"

struct DLL_API SpatialNode : public SpatialPoint
{
public:
	SpatialNode(SpatialNode* parent, float distanceToParent, unsigned x, unsigned y);
	SpatialNode(SpatialNode* parent, float distanceToParent, const SpatialPoint& definingPoint);

public:
	void SetParent(SpatialNode* parent, float distance);
	void AddChild(std::shared_ptr<SpatialNode> child);
	void RemoveChild(const SpatialNode& child);
	std::shared_ptr<SpatialNode> GetChildOwnership(const SpatialNode& child);

	const float GetDistanceToParent() { return m_distanceToParent; };

public:
	inline static unsigned MaxChildren;

public:

	bool operator==(const SpatialNode& other) const;

private:
	float m_distanceToParent;
	SpatialNode* m_parent;
	std::vector<std::shared_ptr<SpatialNode>> m_children;
	std::mutex m_lock;
};

