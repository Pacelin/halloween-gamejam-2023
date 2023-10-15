using UnityEngine;

namespace Game
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 cameraOffset;

        [SerializeField] private Transform clampMin;
        [SerializeField] private Transform clampMax;
        [SerializeField] private bool clamp;

        [SerializeField] private float smoothSpeed;
        
        private Camera camera;
        private Vector2 size;

        private void Awake()
        {
            camera = GetComponent<Camera>();
            size.y = camera.orthographicSize * 2f;
            size.x = size.y * Screen.width / Screen.height;
        }
        
        private void LateUpdate()
        {
            if (target == null) return;
            Vector3 targetPosition = target.position + cameraOffset;
            if (clamp)
                targetPosition = ClampCameraPosition(targetPosition) + cameraOffset;
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }

        private Vector3 ClampCameraPosition(Vector3 targetPosition)
        {
            return new Vector3(
                Mathf.Clamp(targetPosition.x, clampMin.position.x + size.x * .5f, clampMax.position.x - size.x * .5f),
                Mathf.Clamp(targetPosition.y, clampMin.position.y + size.y * .5f, clampMax.position.y - size.y * .5f),
                targetPosition.z);
        }

        public void SetClampBoundaries(Vector3 min, Vector3 max)
        {
            clamp = true;
            clampMin.position = min;
            clampMax.position = max;
        }

        public void ResetBoundaries()
        {
            clamp = false;
        }
    }
}