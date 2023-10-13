using UnityEngine;

public abstract class State<T> : ScriptableObject where T : MonoBehaviour
{
	public virtual void OnEnter(StateMachine<T> machine) { }
    public virtual void OnUpdate(StateMachine<T> machine) { }
    public virtual void OnFixedUpdate(StateMachine<T> machine) { }
    public virtual void OnExit(StateMachine<T> machine) { }
    public virtual void OnTriggerEnterEvent(StateMachine<T> machine) { }
}