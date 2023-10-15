using System.Collections;
using UnityEngine;

public class Arrow : Projectile
{
	[SerializeField] private Collider _selfCollider;
	[SerializeField] private Rigidbody _selfRigidbody;
	[SerializeField] private float _speed;

	private bool _targetAchieved;

	protected override void Fire()
	{
		transform.position = _firePoint;
		_direction.y += 0.1f;
		_direction = _direction.normalized;

		transform.up = _direction;
		_selfRigidbody.velocity = _direction * _speed;
		_targetAchieved = false;
	}

	private void Update()
	{
		if (_targetAchieved) return;
		transform.up = _selfRigidbody.velocity.normalized;
	}

	private IEnumerator OnCollisionEnter(Collision collision)
	{
		if (_friendly && collision.gameObject.TryGetComponent<PlayerStateMachine>(out _))
			yield break;
		
		_targetAchieved = true;
		_selfCollider.enabled = false;
		_selfRigidbody.velocity = _direction * _speed;
		yield return new WaitForSeconds(0.5f / _speed);
		_selfRigidbody.velocity = Vector3.zero;
		_selfRigidbody.isKinematic = true;
		transform.parent = collision.transform;
		
		yield return new WaitForSeconds(0.2f);
		if (ApplyDamageFor(collision))
		{
			transform.parent = null;
			_selfCollider.enabled = true;
			_selfRigidbody.isKinematic = false;
			_selfRigidbody.freezeRotation = false;
		}

		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}

}