using TMPro;
using UnityEngine;

public class TitleTween : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Vector2 _scaleRange;
	[SerializeField] private float _scaleFadeTime;
    [SerializeField] private Color[] _colors;
	[SerializeField] private float _colorFadeTime;

	private float _timer;

	private void Update()
	{
		_timer += Time.deltaTime;
		UpdateScale();
		UpdateColor();
	}

	private void UpdateScale()
	{
		var sin = (Mathf.Sin(_timer / _scaleFadeTime) + 1) / 2f;
		var result = Mathf.Lerp(_scaleRange.x, _scaleRange.y, sin);
		_text.transform.localScale = new Vector3(result, result, 1);
	}

	private void UpdateColor()
	{
		var value = (_timer / _colorFadeTime) % _colors.Length;
		var index = Mathf.FloorToInt(value);
		var t = value - index;
		_text.color = Color.Lerp(_colors[index], _colors[(index + 1) % _colors.Length], t);
	}
}