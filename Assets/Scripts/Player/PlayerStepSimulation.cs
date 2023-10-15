using UnityEngine;
using UnityEngine.Events;

public class PlayerStepSimulation : MonoBehaviour
{
	public UnityEvent OnStep = new UnityEvent();
	[SerializeField] private Transform _player;
	[SerializeField] private float _stepLength;

	private float _currentLength;
	private Vector3 _lastPosition;

	private void Awake()
	{
		_currentLength = 0;
		_lastPosition = _player.position;
	}

	private void Update()
	{
		_currentLength += Vector3.Distance(_lastPosition, _player.position);
		_lastPosition = _player.position;

		if (_currentLength >= _stepLength)
		{
			_currentLength = 0;
			OnStep.Invoke();
		}
	}
}