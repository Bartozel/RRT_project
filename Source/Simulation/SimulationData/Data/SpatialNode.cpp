#include "SpatialNode.h"

SpatialNode::SpatialNode(SpatialNode* parent, float distanceToParent, unsigned x, unsigned y) :
	SpatialPoint(x, y),
	m_parent(parent),
	m_distanceToParent(distanceToParent)
{
}

SpatialNode::SpatialNode(SpatialNode* parent, float distanceToParent, const SpatialPoint& definingPoint) :
	SpatialNode(parent, distanceToParent, definingPoint.GetX(), definingPoint.GetY()) {
}

void SpatialNode::SetParent(SpatialNode* parent, float distance)
{
	m_parent = parent;
	m_distanceToParent = distance;
}

void SpatialNode::AddChild(std::shared_ptr<SpatialNode> child)
{
	std::lock_guard<std::mutex> lock(m_lock);
	m_children.emplace_back(child);
}

void SpatialNode::RemoveChild(const SpatialNode& child)
{
	std::lock_guard<std::mutex> lock(m_lock);

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
	std::lock_guard<std::mutex> lock(m_lock);

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

bool SpatialNode::operator==(const SpatialNode& other) const {
	return X == other.GetX() && Y == other.GetY();
}