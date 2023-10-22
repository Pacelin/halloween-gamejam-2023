using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentSpeedModifierComponent : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private float _offset;
	[SerializeField] private float _increaseTime;
	[SerializeField] private float _decreaseTime;

	private IEnumerator Start()
	{
		var speed = _agent.speed;
		while (true)
		{
			for (float t = 0; t < _increaseTime; t += Time.deltaTime)
			{
				_agent.speed = speed + _offset * t / _increaseTime;
				yield return null;
			}
			for (float t = 0; t < _decreaseTime; t += Time.deltaTime)
			{
				_agent.speed = speed - _offset * t / _decreaseTime;
				yield return null;
			}
		}
	}
}