#pragma once
#include "..\Enum\eMotionType.h"

/// <summary>
/// Defines which motion model will be used on agent for motion navigation accros the choosen path.
/// </summary>
struct DLL_API MotionModelSetting
{
public:
	eMotionType GetType() const {
		return m_type;
	}

	void SetType(eMotionType type) {
		m_type = type;
	}

private:
	eMotionType m_type;
};