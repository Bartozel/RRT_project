#pragma once
#include <vector>
#include <string>
#include "Data\AgentSetting.h"

/// <summary>
/// Main entry point which manages all things in arena:
/// - IAgent behaviour
/// - arena dynamic behaviour
/// 
/// For synchronization uses custom Thread pool and Time synchronizator.
///
/// Main goal is to publish thru this class public API which can be used to manage simulation from web, or desctop UI.
/// </summary>
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

