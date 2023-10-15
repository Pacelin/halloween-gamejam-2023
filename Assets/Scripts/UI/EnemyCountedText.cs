using TMPro;
using UnityEngine;

public class EnemyCountedText : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private EnemyCounter _counter;
	private void OnEnable() =>
		_counter.OnEnemyCountChanged += OnEnemyCountChanged;

	private void OnDisable() =>
		_counter.OnEnemyCountChanged -= OnEnemyCountChanged;

	private void OnEnemyCountChanged(int obj)
	{
		_text.text = obj.ToString();
	}
}
