using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : EnemyAliveState
{
	private int _currentPoint;
	private NavMeshPath _path;

	public EnemyWalkState(StateMachine machine, EnemyStateMachine context) : base(machine, context) { }

	public override void OnEnter()
	{
		_path = new NavMeshPath();
		_currentPoint = 0;
		SetDestination();
	}

	public override void OnExit()
	{
		_context.NavAgent.ResetPath();
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		if (!_context.NavAgent.hasPath)
			SetDestination();
	}

	private void SetDestination()
	{
		NavMesh.CalculatePath(_machine.transform.position, _context.WalkTrajectory[_currentPoint].position, NavMesh.AllAreas, _path);
		_context.NavAgent.SetPath(_path);
		_currentPoint = (_currentPoint + 1) % _context.WalkTrajectory.Length;
	}
}