using UnityEngine;

public class PlayerAliveState : State<PlayerStateMachine>
{
	public PlayerAliveState(StateMachine machine, PlayerStateMachine context) : base(machine, context) { }

	public override void OnUpdate()
	{
		base.OnUpdate();
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (h != 0 || v != 0)
			_machine.SwitchState(_context.MoveState);
	}
}