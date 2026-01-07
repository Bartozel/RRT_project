#include "TimeSynchronizator.h"
#include <chrono>

TimeSynchronizator::TimeSynchronizator() :
	m_shutdown(false),
	m_currentTick(0),
	m_tickCv(),
	m_tickMutex()
{

}

uint64_t TimeSynchronizator::GetCurrentTick() const
{
	return m_currentTick.load();
}

void TimeSynchronizator::RequestShutdown()
{
	m_shutdown.store(true);
}

void TimeSynchronizator::ResetSimulationTime()
{
	m_currentTick = 0;
}

void TimeSynchronizator::StartSimulation()
{
	m_lastTick = std::chrono::steady_clock::now();
}

uint64_t TimeSynchronizator::FromLastTick()
{
	return std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::steady_clock::now() - m_lastTick).count();
}

void TimeSynchronizator::MarkTickFinished()
{
	m_currentTick += 1;
	m_lastTick = std::chrono::steady_clock::now();
}

void TimeSynchronizator::WaitForRestOfTickTime(float tickDuration)
{
	std::unique_lock<std::mutex> lock(m_tickMutex);

	auto timePoint = std::chrono::steady_clock::now();
	const auto waitInterval = std::chrono::duration_cast<std::chrono::milliseconds>(timePoint - m_lastTick).count() - tickDuration;

	if (waitInterval <= 0) {
		return;
	}
	else {
		
		m_tickCv.wait_until(
			lock, 
			timePoint + std::chrono::milliseconds(static_cast<int>(waitInterval * 1000)), 
			[this] {return m_shutdown.load(); }
		);
	}
}