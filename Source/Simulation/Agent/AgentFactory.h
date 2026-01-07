#pragma once
#include <memory>
#include "Interface\IAgent.h"
#include "Data\Setting\AgentSetting.h"

class AgentFactory
{
public:
	static std::unique_ptr<IAgent> GetAgent(const AgentSetting& setting);
};

