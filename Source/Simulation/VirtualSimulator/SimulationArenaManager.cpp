#include "SimulationArenaManager.h"
#include "SpatialDataStructureFactory.h"
#include "AgentFactory.h"
#include "Data\CustomTypes.h"

SimulationArenaManager::SimulationArenaManager(ArenaSetting&& setting, std::shared_ptr<DescriptorDataManger> simulationDataManipulator) :
	m_currentState(eState::Ready),
	m_setting(setting),
	m_agentsInArena(),
	m_timeSynchro(),
	m_simulationData(simulationDataManipulator)
{
}

EProcedureStatus SimulationArenaManager::Start()
{
	if (m_currentState.load() != Ready) {
		return FailedDueToSimulationState;
	}

	std::lock_guard(m_stateLock);
	m_currentState.store(Running);
	m_mainThread = std::thread(MainSimulationLoop);
}

EProcedureStatus SimulationArenaManager::ScenarioReset()
{
	if (m_currentState == Running) {
		Stop();
	}

	std::lock_guard(m_stateLock);

	m_mainThread.join();

	for (const auto& agent : m_agentsInArena) {
		agent->Reset();
	}

	m_timeSynchro.ResetSimulationTime();
	m_currentState.store(Ready);
}

EProcedureStatus SimulationArenaManager::Stop()
{
	if (m_currentState.load() != Running) {
		return;
	}

	std::lock_guard(m_stateLock);

	m_agentsInArena = std::vector<std::unique_ptr<IAgent>>();
	m_timeSynchro.ResetSimulationTime();
	//m_threadPool.Clear();
	m_arena = nullptr;

	m_currentState.store(Reset);
	m_currentState.store(Init);
}

EProcedureStatus SimulationArenaManager::Pause()
{
	if (m_currentState.load() != Running) {
		return;
	}

	std::lock_guard(m_stateLock);
	m_currentState.store(Ready);

	m_mainThread.join();
}

EProcedureStatus SimulationArenaManager::InsertAgent(const AgentSetting& agent)
{
	if (m_currentState.load() == Running) {
		return;
	}

	m_agentsInArena.push_back(AgentFactory::GetAgent(agent));

	if (!m_agentsReady) {
		m_agentsReady = true;
		TrySetReadyState();
	}

	return Success;
}

EProcedureStatus SimulationArenaManager::InsertAgent(const std::vector<AgentSetting>& agents)
{	
	for (const auto& as : agents) {
		InsertAgent(as);
	}

	return Success; //TODO
}

EProcedureStatus SimulationArenaManager::DeleteAgent(AgentId id)
{
	if (m_currentState.load() == Running) {
		return FailedDueToSimulationState;
	}

	for (auto agentIt = m_agentsInArena.begin(); agentIt != m_agentsInArena.end(); agentIt++) {
		if (agentIt->get()->GetId() == id) {
			m_agentsInArena.erase(agentIt);
			break;
		}
	}

	if (m_agentsReady && m_agentsInArena.empty()) {
		m_agentsReady = false;
		TrySetReadyState();
	}

	return Success;
}

EProcedureStatus SimulationArenaManager::DeleteAgent(const std::vector<AgentId>& ids)
{
	if (m_currentState.load() == Running) {
		return FailedDueToSimulationState;
	}
	auto new_end = std::remove_if(m_agentsInArena.begin(), m_agentsInArena.end(),
		[&ids](const auto& agent) { return std::find(ids.begin(), ids.end(), agent->GetId()) != ids.end(); }
	);

	m_agentsInArena.erase(new_end, m_agentsInArena.end());

	if (m_agentsReady && m_agentsInArena.empty()) {
		m_agentsReady = false;
		TrySetReadyState();
	}

	return Success;
}

EProcedureStatus SimulationArenaManager::SetArenaEnvironment(const SpatialDataStructureSetting& arena)
{
	if (m_currentState != Init || m_currentState != Ready) {
		return FailedDueToSimulationState;
	}

	m_arena = SpatialDataStructureFactory::GetEnvinronment(arena);
	return Success;
}

eState SimulationArenaManager::GetState()
{
	return m_currentState.load();
}

void SimulationArenaManager::MainSimulationLoop()
{
	m_timeSynchro.StartSimulation();

	while (m_currentState == Running) {

		const auto& deltaTime = m_timeSynchro.FromLastTick();

		ProcessEventQueue();
		UpdateEnvironment(deltaTime);
		UpdateAgentState(deltaTime);
		CheckForCollisions();

		m_timeSynchro.MarkTickFinished();
		m_timeSynchro.WaitForRestOfTickTime(m_setting.TickDuration);
	}
}

void SimulationArenaManager::TrySetReadyState()
{

}
