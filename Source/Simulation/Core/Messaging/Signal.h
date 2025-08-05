#pragma once
#include <functional>
#include <vector>

template<typename... Args>
class Signal
{
public:
	void Connect(std::function<void(Args...)> slot) {
		m_slots.push_back(std::move(slot));
	}

	void Disconnect(std::function<void(Args...)> slot) {
		m_slots.erase(std::move(slot));
	}

	void DisconnectAll() {
		m_slots.clear();
	}

	template<typename... ForwardArgs>
	void Emit(ForwardArgs&&... args)
		requires (
			sizeof... (ForwardArgs) == sizeof... (Args) &&
			(std::is_convertible_v<ForwardArgs, Args>&& ...)
		)

	{

		for (const auto& slot : sots) {
			slot(std::forward<ForwardArgs>(args)...);
		}
	}

private:
	void std::vector<std::function<void(Args...)>> m_slots;
};
