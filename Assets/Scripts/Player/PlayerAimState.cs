using UnityEngine;

public abstract class PlayerAimState : PlayerAliveState
{
	protected PlayerAimState(StateMachine machine, PlayerStateMachine context) : base(machine, context) { }

	public override void OnUpdate()
	{
		if (_context.AimEnabled)
		{
			_context.NavAgent.angularSpeed = 0;
			UpdateAim();
		}
		else
		{
			_context.NavAgent.angularSpeed = 360;
		}

		HandleShooting();
	}

	private void UpdateAim()
	{
		var playerPos = _context.transform.position;
		playerPos.y = 0;
		var playerOnScreen = _context.MainCamera.WorldToScreenPoint(playerPos);
		playerOnScreen.z = 0;
		var lookDirection = (Input.mousePosition - playerOnScreen).normalized;
		lookDirection.z = lookDirection.y;
		lookDirection.y = 0;

		_context.transform.forward = lookDirection;
	}

	private void HandleShooting()
	{
		if (Input.GetKeyDown(_context.ShootKey))
			_context.Shooting.Shoot();
	}
}