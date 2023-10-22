using UnityEngine;
using Zenject;

public class PlayerModule : MonoInstaller
{
	[SerializeField] private Player _playerPrefab;
	[SerializeField] private Transform _spawnPoint;

	public override void InstallBindings()
	{
		var player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _spawnPoint.position, Quaternion.identity, null);
		Container.BindInstance(player).AsSingle();
	}
}