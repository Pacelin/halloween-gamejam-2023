using UnityEngine;

public class AimingComponent : MonoBehaviour
{
	public Vector3 AimPoint { get; private set; }

	[SerializeField] private Transform _playerTransform;
	[SerializeField] private Collider _raycastCollider;
	[SerializeField] private Camera _mainCamera;

	private void FixedUpdate()
	{
		RaycastHit hit;
		var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
		if (_raycastCollider.Raycast(ray, out hit, float.MaxValue))
		{
			AimPoint = hit.point;
			_playerTransform.LookAt(hit.point);
		}
	}
}
