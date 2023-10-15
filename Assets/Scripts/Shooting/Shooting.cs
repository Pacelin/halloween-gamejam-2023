using UnityEngine;

public class Shooting : MonoBehaviour
{
	[SerializeField] private Transform _firePoint;
	[SerializeField] private Projectile _projectilePrefab;
	[SerializeField] private float _cooldown;

	private float _timer;

	private void Update() => _timer += Time.deltaTime;

	public void Shoot()
	{
		if (_timer < _cooldown) return;
		
		_timer = 0;

		var projectile = Instantiate(_projectilePrefab);
		projectile.Init(_firePoint.position, _firePoint.forward);
	}
}