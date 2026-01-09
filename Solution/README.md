# UI - C#
	- Provides a user interface for monitoring and controlling robots in a mapped area.

### Main Views
#### Home View
	- Dashboard view of available robots and their statuses

#### Settings View
	- Configuration options for robots and application settings

#### Map View
	- Shows robots on a mapped area with real-time updates and previous paths
	- Allows change final destination for selected robot when autonomous mode is disabled

#### Robot Mapped Area View
	- Detailed view of a selected robot's mapped area and navigation data



# Simulation - C++
	- Define an agent injectable with different sensors and actuators, so robot is able to
	move and behave as needed.
	- Necessary data structures for representing the environment, robot state, and sensor data will
	be querible thru predefined communication protocol.

## Virtual Environment
	- In virtual agent should behave in same way as real one.
	- What will differe is:
		- Sensors will be simulated and provide data based on virtual environment.
		- Actuators will affect virtual environment and robot position in it.
		- For coordination of mutiple agents will be needed:
			- Scheduler to manage time steps and agent actions.
			- Environment model to represent the virtual world and its dynamics.
			- State management to track agent states and interactions.
			- Communication module to handle data exchange between agents and the environment.
	- Simulation will acept configuration data and create an agents based on it. It replaces
	the State service from real environment.

## Real Environment
	- After controller boot, State service should be started. It will listen on specified port for incoming
	connfiguration data.
	- Service should be responsible for starting and stopping the simulation process.
	- It may also handle monitoring of the simulation process and restart it when it 
	crashes or stops unexpectedly.
	- Simullation will acept configuration data and create an agent based on it.
	- In real env robot will be injected with REAL sensors and actuators
	installed on robots body. Start sequence may look like this:
		- Load prepared configuration file.
		Based on cfg create collections of sensors and actuators.
		Create communication module with predefined endpoints and protocol.
		Create an Agen an inject those sensors, actuators and communication module in it.
		Report robot own state thru HeartBeat messages.
	- Configuration should contain endpoint adresses for communication module, frequency
	of HeartBeat messages, list of sensors and actuators with their parameters.
	-Service monitoring resources of montroller would be nice to have feature.

# Communication
	## UI -> Simulation/Real Environment
	- Configuration data
	- In case of virtual simulation, it has to provide:
		environment
	- Control commands (start, stop, pause, resume)
	- Command events (change destination, switch mode)

	## Simulation/Real Environment -> UI
	- HeartBeat messages with robot status
	- State data (position, speed, battery level, sensor readings)


# TODO

	- Communication
		- Decide what approach use. Predefined standard like MAVLink, ROS, PX4, ArduPilot, or design something
		more custom gRPC for communication between different endpoints, it offers high performance, language 
		interoperability and scalability for real-time data exchange. Clear disadvantage is complexity and
		and dll dependency.
		- How to send a state data. We have tree options:
			- Polling - UI requests data at regular intervals.
			- Pushing:
				- WebSockets - persistent connection for real-time updates.
				- gRPC streaming - continuous stream of data from simulation to UI.
			- Saving in data cloud - UI fetches data when needed.

	- Data Storage
		- consider using a database like PostgreSQL or MongoDB to store robot data, maps, and configurations.
		- This would allow for better data management, querying capabilities, and persistence across sessions.