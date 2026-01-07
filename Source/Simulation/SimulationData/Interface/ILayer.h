#pragma once
class ILayer
{

public:
	ILayer();
	~ILayer();

	virtual void OnProcessUpdate(double deltaTime) = 0;
	virtual void OnUpdatePublish(double deltaTime) = 0;

};

