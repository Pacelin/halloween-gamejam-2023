using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerStateMachine : StateMachine
{
	public PlayerIdleState IdleState { get; private set; }
	public PlayerMoveState MoveState { get; private set; }

	public UnityEvent OnDead = new UnityEvent();
	
	public bool IsAlive => _isAlive;
	public bool AimEnabled => _aimEnabled;
	public bool MovementEnabled => _movementEnabled;

	[Header("State Controls")]
	[SerializeField] private bool _isAlive = true;
	[SerializeField] private bool _aimEnabled = true;
	[SerializeField] private bool _movementEnabled = true;
	[Space]
	[Header("Movement Settings")]
	public NavMeshAgent NavAgent;
	[Header("Shooting Settings")]
	public Shooting Shooting;
	public KeyCode ShootKey = KeyCode.Mouse0;

	public Camera MainCamera => _mainCamera;
	private Camera _mainCamera;

	private void Awake()
	{
		_mainCamera = Camera.main;
		IdleState = new PlayerIdleState(this, this);
		MoveState = new PlayerMoveState(this, this);
	}

	private void Start() =>
		SwitchState(IdleState);

	public void KillSelf()
	{
		_isAlive = false;
		OnDead?.Invoke();
		Destroy(gameObject);
	}
}