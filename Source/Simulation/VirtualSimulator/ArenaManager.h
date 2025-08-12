#pragma once
#include <vector>
#include <string>
#include "Data\AgentSetting.h"

class ArenaManager
{
public:
	ArenaManager();

	void Start();
	void Stop();
	void Reset();

	void InsertAgent(const AgentSetting& agent);
	void InsertAgent(const std::vector<AgentSetting>& agents);

	void DeleteAgent(const AgentSetting& agent);
	void DeleteAgent(const std::vector<AgentSetting>& agents);

	void UpdateAgent(const AgentSetting& agent);
	void UpdateAgent(const std::vector<AgentSetting>& agents);

	void SetArenaEnvironment(const ArenaSetting& arena);
	void UpdateArenaEnvironment(const ArenaSetting& arena);

};

