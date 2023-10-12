using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachineData : MonoBehaviour
{
	public NavMeshAgent NavAgent;
	public EnemyWalkState WalkState;
	public Transform[] WalkTrajectory;
}