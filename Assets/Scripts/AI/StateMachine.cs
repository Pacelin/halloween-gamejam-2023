using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    private State _currentState;

	public void SwitchState(State state)
    {
        _currentState?.OnExit();
        _currentState = state;
        _currentState?.OnEnter();
    }

    private void Update() => _currentState?.OnUpdate();
	private void FixedUpdate() => _currentState?.OnFixedUpdate();
}
