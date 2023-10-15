using UnityEngine;

public class EnemyDeathState : State<EnemyStateMachine>
{
	public EnemyDeathState(StateMachine machine, EnemyStateMachine context) : base(machine, context) { }

	public override void OnEnter()
	{
		_context.SelfMeshRenderer.enabled = false;
		_context.SelfCollider.enabled = false;
		_context.DeathParticles.Play(true);
	}

	public override void OnUpdate()
	{
		if (_context.DeathParticles.isPlaying) return;
		Object.Destroy(_context.gameObject);
	}
}