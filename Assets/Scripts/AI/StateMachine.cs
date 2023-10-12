using UnityEngine;

public class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
{
    public T Data;

    public State<T> CurrentState => _currentState;
    private State<T> _currentState;

	private void OnValidate()
	{
		if (Data == null)
			Data = gameObject.AddComponent<T>();
	}

	public void SwitchState(State<T> state)
    {
        _currentState?.OnExit(this);
        _currentState = state;
        _currentState?.OnEnter(this);
    }

	private void Update()
	{
        _currentState?.OnUpdate(this);
	}

	private void FixedUpdate()
	{
		_currentState?.OnFixedUpdate(this);
	}
}
