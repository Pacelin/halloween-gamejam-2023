using UnityEngine.AI;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
	public bool IsAlive => _isAlive;

	[Header("State Controls")]
	[SerializeField] private bool _isAlive;
	[Space]
	[Header("Walk Settings")]
	public EnemyWalkState WalkState;
	[Space]
	public NavMeshAgent NavAgent;
	public Transform[] WalkTrajectory;
	[Header("Death Settings")]
	public EnemyDeathState DeathState;
	[Space]
	public ParticleSystem DeathParticles;
	public MeshRenderer EnemyMeshRenderer;

	private void Start()
	{
		WalkState = Instantiate(WalkState);
		DeathState = Instantiate(DeathState);
		WalkState.Init(this);
		DeathState.Init(this);
		SwitchState(WalkState);
	}
}