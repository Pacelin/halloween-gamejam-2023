using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowState : EnemyAliveState
{
	private NavMeshPath _path;
	public EnemyFollowState(StateMachine machine, EnemyStateMachine context) : base(machine, context)
	{
		_path = new NavMeshPath();
	}

	public override void OnEnter()
	{
		base.OnEnter();
		_context.NavAgent.speed *= _context.SpeedUpMultiplier;
		_context.OnPlayerFound.Invoke();
	}

	public override void OnExit()
	{
		base.OnExit();
		_context.NavAgent.speed /= _context.SpeedUpMultiplier;
		_context.NavAgent.ResetPath();
	}
	public override void OnUpdate()
	{
		base.OnUpdate();
		NavMesh.CalculatePath(_machine.transform.position, _context.Target.transform.position, NavMesh.AllAreas, _path);
		_context.NavAgent.SetPath(_path);

		var distance = Vector3.Distance(_context.transform.position, _context.Target.transform.position) ;
		if (distance >= _context.DistanceToReturn)
			_machine.SwitchState(_context.WaitState);
		else if (distance <= _context.AttackDistance)
			_machine.SwitchState(_context.AttackState);

	}
}
