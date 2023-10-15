using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
	public UnityEvent OnAllEnemiesKilled = new UnityEvent();
	[SerializeField] private EnemyStateMachine[] _enemies;
	private int _enemiesRemaining;
	private void Awake()
	{
		_enemiesRemaining = _enemies.Length;
		foreach (var enemy in _enemies)
			enemy.OnDead.AddListener(OnEnemyKilled);
	}

	private void OnEnemyKilled()
	{
		_enemiesRemaining--;
		if (_enemiesRemaining <= 0)
			OnAllEnemiesKilled.Invoke();
	}
}