using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	[SerializeField] private UnityEvent OnDead;
	public void Kill()
	{
		OnDead.Invoke();
		gameObject.SetActive(false);
	}
}