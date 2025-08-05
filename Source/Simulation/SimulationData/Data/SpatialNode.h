#pragma once
#include <vector>
#include <mutex>
#include "SpatialPoint.h"
#include "..\ExportMacro.h"

struct DLL_API SpatialNode : public SpatialPoint
{
public:
	SpatialNode(SpatialNode* parent, float distanceToParent, unsigned x, unsigned y);
	SpatialNode(SpatialNode* parent, float distanceToParent, unsigned x, unsigned y, unsigned z);
	SpatialNode(SpatialNode* parent, float distanceToParent, const SpatialPoint& definingPoint);

public:
	void SetParent(SpatialNode* parent, float distance);
	const SpatialNode& Parent();

	void AddChild(std::shared_ptr<SpatialNode> child);
	void RemoveChild(const SpatialNode& child);
	std::shared_ptr<SpatialNode> GetChildOwnership(const SpatialNode& child);
	unsigned ChildCount();

	const float GetDistanceToParent() const { return m_distanceToParent; };
	const unsigned GetId() const { return m_id; }

private:
	unsigned m_id;
	float m_distanceToParent;
	SpatialNode* m_parent;
	std::vector<std::shared_ptr<SpatialNode>> m_children;

	std::mutex m_childrenLock;
	std::mutex m_parentLock;
};

