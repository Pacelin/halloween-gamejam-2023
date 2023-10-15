public class EnemyAttackState : State<EnemyStateMachine>
{
	public EnemyAttackState(StateMachine machine, EnemyStateMachine context) : base(machine, context) { }

	public override void OnEnter()
	{
		_context.Target.KillSelf();
	}
}