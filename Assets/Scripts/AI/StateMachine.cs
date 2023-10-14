using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    private State _currentState;

	public void SwitchState(State state)
    {
        _currentState?.OnExit(this);
        _currentState = state;
        _currentState?.OnEnter(this);
    }

    private void Update() => _currentState?.OnUpdate(this);
	private void FixedUpdate() => _currentState?.OnFixedUpdate(this);
}
