# UI
	- Provides a user interface for monitoring and controlling robots in a mapped area.

### Main Views
#### Home View
	- Dashboard view of available robots and their statuses

#### Settings View
	- Configuration options for robots and application settings

#### Map View
	- Shows robots on a mapped area with real-time updates and previous paths
	- Allows change final destination for selected robot when autonomous mode is enabled

#### Robot Mapped Area View
	- Detailed view of a selected robot's mapped area and navigation data


# Simulation
	- Contains an agent injectable with different sensors and actuators, so robot is able to
	move and behave as needed.

## Virtual Environment
	- For simulation purposes agents have to be injected with MOK sensors and actuators.
	Which operates in predefined environment.

## Real Environment
	- For real robot operation agents have to be injected with REAL sensors and actuators
	installed on robots body. T

# TODO
	- Communication 
		- currently consider if I should implement it or use existing solution like ROS2
		- One of option may be to use gRPC for communication between different endpoints,
		it offers high performance, language interoperability and scalability for real-time data exchange.

	- Data Storage
		- consider using a database like PostgreSQL or MongoDB to store robot data, maps, and configurations.
		- This would allow for better data management, querying capabilities, and persistence across sessions.