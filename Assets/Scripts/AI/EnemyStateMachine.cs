using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMachine : StateMachine
{
	public UnityEvent OnDead = new UnityEvent();
	public UnityEvent OnPlayerFound = new UnityEvent();
	public UnityEvent OnRage = new UnityEvent();

	public bool IsAlive => _isAlive;
	public EnemyWalkState WalkState { get; private set; }
	public EnemyDeathState DeathState { get; private set; }
	public EnemyFollowState FollowState { get; private set; }
	public EnemyWaitState WaitState { get; private set; }
	public EnemyAttackState AttackState { get; private set; }

	[Header("State Controls")]
	[SerializeField] private bool _isAlive;
	[Space]
	[Header("Walk Settings")]
	public NavMeshAgent NavAgent;
	public Transform[] WalkTrajectory;
	public Vector2 StopTimeRange;
	[Header("Death Settings")]
	public ParticleSystem DeathParticles;
	public MeshRenderer[] Meshes;
	public Collider SelfCollider;
	[Header("Follow Settings")]
	public Player Target;
	public float DistanceToFollow;
	public float DistanceToReturn;
	public float DistanceToFollowWhenStoppedMultiplier;
	public float MinFollowTime;
	[Space]
	public float SpeedUpMultiplier;
	public float RageSpeedUpMultiplier;
	public float RageTime;
	[Space]
	public float AttackDistance;
	

	private void Start()
	{
		WalkState = new EnemyWalkState(this, this);
		DeathState = new EnemyDeathState(this, this);
		FollowState = new EnemyFollowState(this, this);
		WaitState = new EnemyWaitState(this, this);
		AttackState = new EnemyAttackState(this, this);
		SwitchState(WalkState);
	}

	public void KillSelf()
	{
		SelfCollider.enabled = false;
		_isAlive = false;
		OnDead?.Invoke();
	}
}