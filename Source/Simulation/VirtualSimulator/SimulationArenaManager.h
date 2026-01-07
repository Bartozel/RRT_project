#pragma once
#include <vector>
#include <string>
#include <memory>

#include "Interface\IAgent.h"
#include "Interface\ISpatialDataStructure.h"
#include "Data\Setting\AgentSetting.h"
#include "Data\Setting\ArenaSetting.h"
#include "Enum\eState.h"
#include "TimeSynchronizator.h"
#include "ThreadPool.h"
#include "Enum/EProcedureStatus.h"
#include "Data/Update/AgentEquipemntUpdate.h"
#include "Data/Update/AgentMovementUpdate.h"
#include "Data/Update/PositionUpdate.h"
#include "Data/Update/EnvironmentUpdate.h"
#include "DescriptorDataManger.h"
#include "Data/CustomTypes.h"

/// <summary>
/// Main entry point which manages all things in arena:
/// - IAgent behaviour
/// - arena dynamic behaviour
/// 
/// For synchronization uses custom Thread pool and Time synchronizator.
///
/// This class represents public API which can be used to manage simulation from web, or desctop UI.
/// </summary>
class SimulationArenaManager
{
public:
	SimulationArenaManager(ArenaSetting&& setting, std::shared_ptr<DescriptorDataManger> simulationDataManipulator);

	/// <summary>
	/// It starts predefined simulation
	/// </summary>
	EProcedureStatus Start(); //TODO return type indicationg operations outcome
	/// <summary>
	/// It roll back simulation to initial state.
	/// </summary>
	EProcedureStatus ScenarioReset(); //TODO return type indicationg operations outcome
	/// <summary>
	/// Clear all aditional data for simulation.
	/// </summary>
	EProcedureStatus Stop(); //TODO return type indicationg operations outcome
	/// <summary>
	/// It pauses current simulation and it can resume in future.
	/// </summary>
	EProcedureStatus Pause(); //TODO return type indicationg operations outcome
	/// <summary>
	/// It creates an agent with predefined behaviour
	/// </summary>
	/// <param name="agent"></param>
	EProcedureStatus InsertAgent(const AgentSetting& agent);
	EProcedureStatus InsertAgent(const std::vector<AgentSetting>& agents);
	/// <summary>
	/// Erase an agent with same AgnetId
	/// </summary>
	/// <param name="id"></param>
	EProcedureStatus DeleteAgent(AgentId id);
	EProcedureStatus DeleteAgent(const std::vector<AgentId>& ids);	
	/// <summary>
	/// preset an env in which simulation goes
	/// </summary>
	/// <param name="arena"></param>
	EProcedureStatus SetArenaEnvironment(const SpatialDataStructureSetting& arena);

	eState GetState();

private:
	/// <summary>	
	/// run main simulation loop
	/// it manages synchronization context and start working threads work on predefined synchronizatin signal.
	/// Define procedures which should be calculated in one tick:
	/// - Update Agent state -> 
	///		position - fully paralelized,
	///		collision - after all position update finish,
	///		inner state - only if agent is not in collision,
	///		actions - many actions may be parallelized - fire, jump or other user defined actions
	/// - Update Envinronment -> weather, map, dayilight etc. - It seems that those procedures are mainly independent, so possible process in paralel
	/// - Process agent actions, which were already started -> action which was started by agent, or user in one frame and continue in future frames, like 
	///								detonation,
	/// </summary>
	void MainSimulationLoop();
	/// <summary>
	/// Try to switch simulation state in Ready state, IF all conditions are fulfiled.
	/// </summary>
	void TrySetReadyState();

	void ProcessEventQueue();
	void UpdateEnvironment(const uint64_t& delta);
	void UpdateAgentState(const uint64_t& delta);
	void CheckForCollisions();


private:
	std::atomic<eState> m_currentState;
	std::vector<std::unique_ptr<IAgent>> m_agentsInArena;
	TimeSynchronizator m_timeSynchro;

	std::unique_ptr<ISpatialDataStructure> m_arena;
	std::shared_ptr<DescriptorDataManger> m_simulationData;

	ArenaSetting m_setting;
	std::mutex m_stateLock;
	std::mutex m_processLock;
	std::thread m_mainThread;


	bool m_agentsReady;
};

