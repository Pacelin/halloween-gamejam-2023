public abstract class State
{
    protected StateMachine _machine;
    public State(StateMachine machine) =>
        _machine = machine;
	public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
    public virtual void OnExit() { }
    public virtual void OnTriggerEnterEvent() { }
}

public abstract class State<T> : State
{
    protected T _context;
	protected State(StateMachine machine, T context) : base(machine) =>
        _context = context;
}