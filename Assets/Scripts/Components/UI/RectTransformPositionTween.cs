using System.Collections;
using UnityEngine;

public class RectTransformPositionTween : MonoBehaviour
{
	[SerializeField] private Vector2 _fromPos;
	[SerializeField] private Vector2 _toPos;
	[SerializeField] private float _time;

	public void OnEnable() => StartCoroutine(Play());

	private IEnumerator Play()
	{
		var tr = transform as RectTransform;
		tr.position = _fromPos;
		yield return null;
		for (float t = 0; t < _time; t += Time.deltaTime)
		{
			var x = t / _time;
			tr.anchoredPosition = Vector3.Lerp(_fromPos, _toPos, Mathf.Pow(x, 1f/3));
			yield return null;
		}
		tr.anchoredPosition = _toPos;
	}
}