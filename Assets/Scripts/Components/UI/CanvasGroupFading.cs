using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacelin
{
	[RequireComponent(typeof(CanvasGroup))]
	public class CanvasGroupFading : MonoBehaviour
	{
		[SerializeField] private float _fadeInTime;
		[SerializeField] private float _fadeOutTime;

		private CanvasGroup _canvasGroup;

		private void Awake() =>
			_canvasGroup = GetComponent<CanvasGroup>();

		public void FadeIn(Action callback) => StartCoroutine(FadingIn(callback));
		public void FadeOut(Action callback) => StopCoroutine(FadingOut(callback));

		private IEnumerator FadingIn(Action callback)
		{
			for (float t = 0; t < _fadeInTime; t += Time.deltaTime)
			{
				_canvasGroup.alpha = t / _fadeInTime;
				yield return null;
			}
			_canvasGroup.alpha = 1;
			callback();
		}

		private IEnumerator FadingOut(Action callback)
		{
			for (float t = 0; t < _fadeOutTime; t += Time.deltaTime)
			{
				_canvasGroup.alpha = t / _fadeOutTime;
				yield return null;
			}
			_canvasGroup.alpha = 0;
			callback();
		}
	}
}