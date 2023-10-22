using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : EnemyAliveState
{
	private int _currentPoint;
	private NavMeshPath _path;
	private float _timer;
	private float _stopTime;
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
		{
			if (_timer == 0)
				_context.DistanceToFollow *= _context.DistanceToFollowWhenStoppedMultiplier;

			_timer += Time.deltaTime;
			if (_timer > _stopTime)
			{
				_context.DistanceToFollow /= _context.DistanceToFollowWhenStoppedMultiplier;
				SetDestination();
			}
		}
	}

	private void SetDestination()
	{
		NavMesh.CalculatePath(_machine.transform.position, _context.WalkTrajectory[_currentPoint].position, NavMesh.AllAreas, _path);
		_context.NavAgent.SetPath(_path);
		_currentPoint = (_currentPoint + 1) % _context.WalkTrajectory.Length;
		_stopTime = Random.Range(_context.StopTimeRange.x, _context.StopTimeRange.y);
		_timer = 0;
	}
}