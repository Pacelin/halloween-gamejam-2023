using UnityEngine;
using UnityEngine.AI;

public class PlayerRunningComponent : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private float _runMultiplier;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
			_agent.speed *= _runMultiplier;
		else if (Input.GetKeyUp(KeyCode.LeftShift))
			_agent.speed /= _runMultiplier;
	}
}