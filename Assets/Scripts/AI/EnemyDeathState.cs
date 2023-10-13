using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class EnemyDeathState : State<EnemyStateMachineData>
{
	private int _currentPoint;
	private NavMeshPath _path;
	private void OnEnable()
	{
		_path = new NavMeshPath();
	}
	public override void OnEnter(StateMachine<EnemyStateMachineData> machine)
	{
		_currentPoint = 0;
		SetDestination(machine);
	}
	public override void OnUpdate(StateMachine<EnemyStateMachineData> machine)
	{
		if (!machine.Data.NavAgent.hasPath)
			SetDestination(machine);
	}

	private void SetDestination(StateMachine<EnemyStateMachineData> machine)
	{
		NavMesh.CalculatePath(machine.transform.position, machine.Data.WalkTrajectory[_currentPoint].position, NavMesh.AllAreas, _path);
		machine.Data.NavAgent.SetPath(_path);
		_currentPoint = (_currentPoint + 1) % machine.Data.WalkTrajectory.Length;
	}
}