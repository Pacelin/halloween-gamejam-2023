using UnityEngine;

public class EnemyWaitState : EnemyAliveState
{
	private float _timer;
	public EnemyWaitState(StateMachine machine, EnemyStateMachine context) : base(machine, context) { }

	public override void OnEnter()
	{
		base.OnEnter();
		_timer = 0;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		_timer += Time.deltaTime;
		if (_timer >= 1)
			_machine.SwitchState(_context.FollowState);
	}
}