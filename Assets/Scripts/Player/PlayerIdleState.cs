using UnityEngine;

[CreateAssetMenu]
public class PlayerIdleState : PlayerAimState
{
	public override void OnEnter(StateMachine machine) =>
		_context.NavAgent.ResetPath();

	public override void OnUpdate(StateMachine machine)
	{
		base.OnUpdate(machine);
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (h != 0 || v != 0)
			machine.SwitchState(_context.MoveState);
	}
}