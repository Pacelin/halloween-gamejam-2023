using UnityEngine;

public class EnemyAliveState : State<EnemyStateMachine>
{
	public EnemyAliveState(StateMachine machine, EnemyStateMachine context) : base(machine, context) { }

	public override void OnUpdate()
	{
		if (_machine.CurrentState != _context.FollowState)
			if (Vector3.Distance(_context.transform.position, _context.Target.position) <= _context.DistanceToFollow)
				_machine.SwitchState(_context.FollowState);
		if (_context.IsAlive) return;
		_machine.SwitchState(_context.DeathState);
	}
}