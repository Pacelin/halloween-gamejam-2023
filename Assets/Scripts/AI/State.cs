using UnityEngine;

public abstract class State : ScriptableObject
{
	public virtual void OnEnter(StateMachine machine) { }
    public virtual void OnUpdate(StateMachine machine) { }
    public virtual void OnFixedUpdate(StateMachine machine) { }
    public virtual void OnExit(StateMachine machine) { }
    public virtual void OnTriggerEnterEvent(StateMachine machine) { }
}

public abstract class State<T> : State
{
    protected T _context;
    public void Init(T context) => _context = context;
}