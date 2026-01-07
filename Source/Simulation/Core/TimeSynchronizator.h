#pragma once
#include <cstdint>
#include <mutex>

/// <summary>
/// Provide a synchronization for tasks running in different threads.
/// </summary>
class TimeSynchronizator
{
public:
	TimeSynchronizator();
public:
	uint64_t GetCurrentTick() const;
	void RequestShutdown();
	void ResetSimulationTime();
	void StartSimulation();
	uint64_t FromLastTick();
	void MarkTickFinished();
	void WaitForRestOfTickTime(float tickDuration);

private:
	std::mutex m_tickMutex;
	std::condition_variable m_tickCv;

	std::atomic<uint64_t> m_currentTick;
	std::chrono::steady_clock::time_point m_lastTick;
	std::atomic<bool> m_shutdown;
};

