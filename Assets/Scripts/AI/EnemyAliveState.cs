using UnityEngine;

public class EnemyAliveState : State<EnemyStateMachine>
{
	public EnemyAliveState(StateMachine machine, EnemyStateMachine context) : base(machine, context) { }

	public override void OnUpdate()
	{
		if (_machine.CurrentState != _context.FollowState &&
			_machine.CurrentState != _context.WaitState)
			if (Vector3.Distance(_context.transform.position, _context.Target.transform.position) <= _context.DistanceToFollow)
				_machine.SwitchState(_context.FollowState);
		if (_context.IsAlive) return;
		_machine.SwitchState(_context.DeathState);
	}
}