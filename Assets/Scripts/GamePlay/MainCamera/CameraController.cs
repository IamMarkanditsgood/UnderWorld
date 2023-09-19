using UnityEngine;

namespace MainCamera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private float _smoothSpeed = 5f;
    
        private Transform _target;
    
        private void Awake()
        {
            _target = _cameraData.Player;
        }

        private void LateUpdate()
        {
            if (_target != null)
            {
                Vector3 targetPosition = _target.position;
                var position = transform.position;
                Vector3 newPosition = new Vector3(targetPosition.x, position.y, targetPosition.z);
                transform.position = Vector3.Lerp(position, newPosition, _smoothSpeed * Time.deltaTime);
            
            }
        }
    }
}
