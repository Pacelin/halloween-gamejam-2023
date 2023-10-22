using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerReloadComponent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private ShootingComponent _shooting;
    [SerializeField] private float _slowMultiplier;

	private void OnEnable()
	{
		_shooting.OnShoot += OnShoot;
		_shooting.OnReloaded += OnReloaded;
	}
	private void OnDisable()
	{
		_shooting.OnShoot -= OnShoot;
		_shooting.OnReloaded -= OnReloaded;
	}

	private void OnReloaded() => _agent.speed /= _slowMultiplier;
	private void OnShoot() => _agent.speed *= _slowMultiplier;
}
