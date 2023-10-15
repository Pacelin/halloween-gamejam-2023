using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionCommand : MonoBehaviour
{
    [SerializeField] [Scene] private int _buildIndex;
    [SerializeField] private float _delay;
    private bool _loaded;
    private bool _faded;
    public void ApplyTransition()
    {
        _loaded = false;
        _faded = false;
        StartCoroutine(Applying());
    }

    private IEnumerator Applying()
    {
        yield return new WaitForSecondsRealtime(_delay);
		ImageFading.Instance.FadeIn(
			() => StartCoroutine(Load()),
			() => _faded = true);
		ImageFading.Instance.FadeOut(() => _loaded && _faded, () => Destroy(gameObject));
	}

    private IEnumerator Load()
    {
        var loadTask = SceneManager.LoadSceneAsync(_buildIndex, LoadSceneMode.Single);
		yield return new WaitUntil(() => loadTask.isDone);
        _loaded = true;
	}
}
