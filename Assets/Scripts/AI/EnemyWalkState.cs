using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class EnemyWalkState : State<EnemyStateMachine>
{
	private int _currentPoint;
	private NavMeshPath _path;

	public override void OnEnter(StateMachine machine)
	{
		_path = new NavMeshPath();
		_currentPoint = 0;
		SetDestination(machine);
	}

	public override void OnExit(StateMachine machine)
	{
		_context.NavAgent.ResetPath();
	}

	public override void OnUpdate(StateMachine machine)
	{
		if (!_context.NavAgent.hasPath)
			SetDestination(machine);

		if (!_context.IsAlive) machine.SwitchState(_context.DeathState);
	}

	private void SetDestination(StateMachine machine)
	{
		NavMesh.CalculatePath(machine.transform.position, _context.WalkTrajectory[_currentPoint].position, NavMesh.AllAreas, _path);
		_context.NavAgent.SetPath(_path);
		_currentPoint = (_currentPoint + 1) % _context.WalkTrajectory.Length;
	}
}