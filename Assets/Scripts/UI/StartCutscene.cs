using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class StartCutscene : MonoBehaviour
{
    public UnityEvent OnCutSceneEnded = new UnityEvent();
    [SerializeField] private VideoPlayer _video;
	[SerializeField] private KeyCode _skipKey = KeyCode.Space;

	public void Awake()
	{
		_video.Prepare();
		_video.enabled = false;
	}

	public void Play()
	{
		_video.enabled = true;
		StartCoroutine(Playing());
	}

	private IEnumerator Playing()
	{
		_video.Play();
		while (_video.isPlaying)
		{
			if (Input.GetKeyDown(_skipKey))
				break;
			yield return null;
		}
		OnCutSceneEnded.Invoke();
	}
}
