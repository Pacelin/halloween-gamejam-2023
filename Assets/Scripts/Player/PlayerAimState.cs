using UnityEngine;

public abstract class PlayerAimState : State<PlayerStateMachine>
{
	public override void OnUpdate(StateMachine machine)
	{
		if (_context.AimEnabled)
		{
			_context.NavAgent.angularSpeed = 0; 
		}
		else
		{
			_context.NavAgent.angularSpeed = 360;
			return;
		}

		var playerPos = _context.transform.position;
		playerPos.y = 0;
		var playerOnScreen = _context.MainCamera.WorldToScreenPoint(playerPos);
		playerOnScreen.z = 0;
		var lookDirection = (Input.mousePosition - playerOnScreen).normalized;
		lookDirection.z = lookDirection.y;
		lookDirection.y = 0;

		_context.transform.forward = lookDirection;

		/*
        Ray ray = _context.MainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			_context.transform.LookAt(new Vector3(hit.point.x, _context.transform.position.y, hit.point.z));
		*/
	}
}