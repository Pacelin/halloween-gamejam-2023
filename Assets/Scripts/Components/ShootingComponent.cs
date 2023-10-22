using System;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
	public event Action OnShoot;
	public event Action OnReloaded;

    [SerializeField] private AimingComponent _aimingComponent;
    [SerializeField] private Arrow _arrowPrefab;
	[SerializeField] private Transform _firePoint;
	[SerializeField] private float _cooldown;

	private float _timer = 0;

	private void Update()
	{
		_timer -= Time.deltaTime;
		if (_timer > 0) return;

		if (_timer + Time.deltaTime > 0)
			OnReloaded?.Invoke();

		if (Input.GetMouseButtonDown(0))
			Shoot();
	}

	private void Shoot()
	{
		_timer = _cooldown;
		var arrow = Instantiate(_arrowPrefab);
		var direction = _aimingComponent.AimPoint - _firePoint.position;
		direction.y += 0.1f;

		arrow.Init(_firePoint.position, direction);
		OnShoot?.Invoke();
	}
}
