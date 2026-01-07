#pragma once
enum eState
{
	/// <summary>
	/// Simulation is ready to be set up.
	/// State is reached after Start, or after end of simulation
	/// </summary>
	Init,
	/// <summary>
	/// Simulation is ready to start
	/// </summary>
	Ready,
	/// <summary>
	/// Simulation started and running
	/// </summary>
	Running,
	/// <summary>
	/// Running simulation has been Stopped and it can be restored
	/// </summary>
	Stopped,
	/// <summary>
	/// Simulation was stopped and manager was cleared
	/// </summary>
	Reset
};

