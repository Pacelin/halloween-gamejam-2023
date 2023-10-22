using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _playerAgent;

	private NavMeshPath _path;

	private void Awake()
	{
		_path = new NavMeshPath();
	}

	private void FixedUpdate()
	{
		var inputX = Input.GetAxisRaw("Horizontal");
		var inputY = Input.GetAxisRaw("Vertical");

		if (inputX == 0 && inputY == 0)
		{
			_playerAgent.ResetPath();
			return;
		}

		var nextPosition = _playerAgent.transform.position;
		nextPosition.x += inputX;
		nextPosition.z += inputY;

		NavMesh.CalculatePath(_playerAgent.transform.position, nextPosition, NavMesh.AllAreas, _path);
		_playerAgent.SetPath(_path);
	}
}