using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject.SpaceFighter;

public abstract class Projectile : MonoBehaviour
{
	[SerializeField] private float _maxLifetime;
	[SerializeField] private bool _friendly;

	protected Vector3 _direction;
	protected Vector3 _firePoint;

	public void Init(Vector3 firePoint, Vector3 direction)
	{
		_firePoint = firePoint;
		_direction = direction;
		Fire();
		StartCoroutine(Lifetime());
	}

	protected bool ApplyDamageFor(Collision collision)
	{
		if (_friendly)
		{
			if (collision.gameObject.TryGetComponent<EnemyStateMachine>(out var enemy))
			{
				enemy.KillSelf();
				return true;
			}
		}
		else
		{
			if (collision.gameObject.TryGetComponent<PlayerStateMachine>(out var player))
			{
				player.KillSelf();
				return true;
			}
		}
		return false;
	}

	protected abstract void Fire();

	private IEnumerator Lifetime()
	{
		yield return new WaitForSeconds(_maxLifetime);
		Destroy(gameObject);
	}
}