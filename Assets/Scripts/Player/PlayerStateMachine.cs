using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerStateMachine : StateMachine
{
	public UnityEvent OnDead = new UnityEvent();
	
	public bool IsAlive => _isAlive;
	public bool AimEnabled => _aimEnabled;
	public bool MovementEnabled => _movementEnabled;

	[Header("State Controls")]
	[SerializeField] private bool _isAlive = true;
	[SerializeField] private bool _aimEnabled = true;
	[SerializeField] private bool _movementEnabled = true;
	[Space]
	[Header("Idle Settings")]
	public PlayerIdleState IdleState;
	[Header("Movement Settings")]
	public PlayerMoveState MoveState;
	public NavMeshAgent NavAgent;

	public Camera MainCamera => _mainCamera;
	private Camera _mainCamera;

	private void Awake()
	{
		_mainCamera = Camera.main;
		IdleState = Instantiate(IdleState);
		MoveState = Instantiate(MoveState);
		IdleState.Init(this);
		MoveState.Init(this);
	}

	private void Start() =>
		SwitchState(IdleState);

	public void KillSelf()
	{
		_isAlive = false;
		OnDead.Invoke();
	}
}