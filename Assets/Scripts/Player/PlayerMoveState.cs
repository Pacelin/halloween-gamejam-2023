using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class PlayerMoveState : PlayerAimState 
{
	private NavMeshPath _path;
	public override void OnEnter(StateMachine machine) =>
		_path = new NavMeshPath();

	public override void OnUpdate(StateMachine machine)
	{
		base.OnUpdate(machine);
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