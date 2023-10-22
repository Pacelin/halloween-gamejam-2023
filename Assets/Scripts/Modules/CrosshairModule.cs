using UnityEngine;
using Zenject;

public class CrosshairModule : MonoInstaller
{ 
	[SerializeField] private Texture2D _texture;
	[SerializeField] private Vector2 _hotspot;
	[SerializeField] private CursorMode _mode;

	public override void InstallBindings()
	{
		var hotspot = new Vector2(_texture.width * _hotspot.x, _texture.height * _hotspot.y);
		Cursor.SetCursor(_texture, hotspot, _mode);
	}
}