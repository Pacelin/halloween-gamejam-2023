using UnityEngine;

[CreateAssetMenu]
public class EnemyDeathState : State<EnemyStateMachine>
{
	public override void OnEnter(StateMachine machine)
	{
		_context.EnemyMeshRenderer.enabled = false;
		_context.DeathParticles.Play(true);
	}
	public override void OnUpdate(StateMachine machine)
	{
		if (_context.DeathParticles.isPlaying) return;
		Destroy(_context.gameObject);
	}
}