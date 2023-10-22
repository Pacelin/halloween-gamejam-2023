using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
	public EnemyStateMachine[] Enemies => _enemies;

	public event Action<int> OnEnemyCountChanged;
	public UnityEvent OnAllEnemiesKilled = new UnityEvent();
	[SerializeField] private EnemyStateMachine[] _enemies;
	private int _enemiesRemaining;
	private void Awake()
	{
		_enemiesRemaining = _enemies.Length;
		foreach (var enemy in _enemies)
			enemy.OnDead.AddListener(OnEnemyKilled);
		OnEnemyCountChanged?.Invoke(_enemiesRemaining);
	}

	private void OnEnemyKilled()
	{
		_enemiesRemaining--;
		OnEnemyCountChanged?.Invoke(_enemiesRemaining);
		if (_enemiesRemaining <= 0)
			OnAllEnemiesKilled.Invoke();
	}
}