using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFading : MonoBehaviour
{
	public static ImageFading Instance => _instance;
	private static ImageFading _instance;

	[SerializeField] private Image _image;
	[Space]
	[SerializeField] private Color _enabledColor;
	[SerializeField] private Color _disabledColor;
	[Space]
	[SerializeField] private float _fadeInTime;
	[SerializeField] private float _durationTime;
	[SerializeField] private float _fadeOutTime;
	[Space]
	[SerializeField] private bool _isGlobal;

	private void Awake()
	{ 
		if (_isGlobal)
		{
			if (_instance == null)
				_instance = this;
			else
				Destroy(gameObject);
		}
	}

	public void FadeIn(Action inCallback = null, Action durationCallback = null) => StartCoroutine(FadingIn(inCallback, durationCallback));
	public void FadeOut(Func<bool> when, Action outCallback = null) => StartCoroutine(FadingOut(when, outCallback));

	private IEnumerator FadingIn(Action inCallback, Action durationCallback)
	{
		_image.raycastTarget = true;
		for (float t = 0; t < _fadeInTime; t += Time.deltaTime)
		{
			var color = Color.Lerp(_disabledColor, _enabledColor, t / _fadeInTime);
			_image.color = color;
			yield return null;
		}
		_image.color = _enabledColor;
		if (inCallback != null) inCallback();
		yield return new WaitForSecondsRealtime(_durationTime);
		if (durationCallback != null) durationCallback();
	}

	private IEnumerator FadingOut(Func<bool> when, Action outCallback)
	{
		yield return new WaitUntil(when);
		for (float t = 0; t < _fadeOutTime; t += Time.deltaTime)
		{
			var color = Color.Lerp(_enabledColor, _disabledColor, t / _fadeOutTime);
			_image.color = color;
			yield return null;
		}
		_image.color = _disabledColor;
		_image.raycastTarget = false;
		if (outCallback != null) outCallback();
	}
}
