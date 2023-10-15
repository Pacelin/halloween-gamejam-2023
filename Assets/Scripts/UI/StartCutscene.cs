using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class StartCutscene : MonoBehaviour
{
    public UnityEvent OnCutSceneEnded = new UnityEvent();
    [SerializeField] private VideoPlayer _video;

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
		yield return new WaitWhile(() => _video.isPlaying);
		OnCutSceneEnded.Invoke();
	}
}
