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
		Vector3 dir = new Vector3(h, 0f, v).normalized;

		if (dir.magnitude >= 0.1f)
		{
			NavMesh.CalculatePath(_context.transform.position, _context.transform.position + dir * 0.1f, NavMesh.AllAreas, _path);
			_context.NavAgent.SetPath(_path);
		}
	}
}