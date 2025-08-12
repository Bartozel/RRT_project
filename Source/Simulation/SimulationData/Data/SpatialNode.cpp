#include "SpatialNode.h"

SpatialNode::SpatialNode(SpatialNode* parent, float distanceToParent, unsigned x, unsigned y) :
	SpatialNode(parent, distanceToParent, x, y, 0.0f) {
}

SpatialNode::SpatialNode(SpatialNode* parent, float distanceToParent, unsigned x, unsigned y, unsigned z) :
	SpatialPoint(x, y, z),
	m_parent(parent),
	m_distanceToParent(distanceToParent)
{
}

SpatialNode::SpatialNode(SpatialNode* parent, float distanceToParent, const SpatialPoint& definingPoint) :
	SpatialNode(parent, distanceToParent, definingPoint.GetX(), definingPoint.GetY()) {
}

void SpatialNode::SetParent(SpatialNode* parent, float distance)
{
	std::lock_guard<std::mutex> lock(m_parentLock);

	m_parent = parent;
	m_distanceToParent = distance;
}

const SpatialNode& SpatialNode::Parent()
{
	std::lock_guard<std::mutex> lock(m_parentLock);

	if (m_parent) {
		return *m_parent;
	}
	else {
		throw std::runtime_error("SpatialNode.Parent() - Unexpected nullptr: m_parent object can not be null.");
	}
}

void SpatialNode::AddChild(std::shared_ptr<SpatialNode> child)
{
	std::lock_guard<std::mutex> lock(m_childrenLock);
	m_children.emplace_back(child);
}

void SpatialNode::RemoveChild(const SpatialNode& child)
{
	std::lock_guard<std::mutex> lock(m_childrenLock);

	m_children.erase(
		std::remove_if(
			m_children.begin(), m_children.end(),
			[&](const std::shared_ptr<SpatialNode>& ptr) { return *ptr == child; }
		),
		m_children.end()
	);
}

std::shared_ptr<SpatialNode> SpatialNode::GetChildOwnership(const SpatialNode& child)
{
	std::lock_guard<std::mutex> lock(m_childrenLock);

	auto it = std::find_if(m_children.begin(), m_children.end(),
		[&child](const std::shared_ptr<SpatialNode>& ptr) {
			return ptr.get() == &child;
		});

	if (it != m_children.end()) {
		auto result = std::move(*it);
		m_children.erase(it);
		return result;
	}

	return nullptr;
}

unsigned SpatialNode::ChildCount()
{
	return m_children.size();
}
