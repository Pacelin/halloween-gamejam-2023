public class EnemyAliveState : State<EnemyStateMachine>
{
	public EnemyAliveState(StateMachine machine, EnemyStateMachine context) : base(machine, context) { }

	public override void OnUpdate()
	{
		if (_context.IsAlive) return;

		_machine.SwitchState(_context.DeathState);
	}
}