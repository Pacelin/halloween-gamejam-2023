using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveState : PlayerAimState
{
	private NavMeshPath _path;

	public PlayerMoveState(StateMachine machine, PlayerStateMachine context) : base(machine, context)
	{
		_path = new NavMeshPath();
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		if (h == 0f && v == 0f)
			_machine.SwitchState(_context.IdleState);

		Vector3 dir = new Vector3(h, 0f, v).normalized;

		NavMesh.CalculatePath(_context.transform.position, _context.transform.position + dir, NavMesh.AllAreas, _path);
		_context.NavAgent.SetPath(_path);
	}
}