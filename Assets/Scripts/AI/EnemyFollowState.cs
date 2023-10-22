using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowState : EnemyAliveState
{
	private NavMeshPath _path;
	private float _timer;

	public EnemyFollowState(StateMachine machine, EnemyStateMachine context) : base(machine, context)
	{
		_path = new NavMeshPath();
	}

	public override void OnEnter()
	{
		base.OnEnter();
		_context.NavAgent.speed *= _context.SpeedUpMultiplier;
		_context.OnPlayerFound.Invoke();
		_timer = 0;	
	}

	public override void OnExit()
	{
		base.OnExit();
		if (_timer > _context.RageTime)
			_context.NavAgent.speed /= _context.RageSpeedUpMultiplier;
		_context.NavAgent.speed /= _context.SpeedUpMultiplier;
		_context.NavAgent.ResetPath();
	}
	public override void OnUpdate()
	{
		base.OnUpdate();
		NavMesh.CalculatePath(_machine.transform.position, _context.Target.transform.position, NavMesh.AllAreas, _path);
		_context.NavAgent.SetPath(_path);

		_timer += Time.deltaTime;

		if (_timer > _context.RageTime & _timer - Time.deltaTime <= _context.RageTime)
		{
			_context.NavAgent.speed *= _context.RageSpeedUpMultiplier;
			_context.OnRage.Invoke();
		}

		var distance = Vector3.Distance(_context.transform.position, _context.Target.transform.position) ;
		if (_timer >= _context.MinFollowTime && distance >= _context.DistanceToReturn)
			_machine.SwitchState(_context.WaitState);
		else if (distance <= _context.AttackDistance)
			_machine.SwitchState(_context.AttackState);

	}
}
