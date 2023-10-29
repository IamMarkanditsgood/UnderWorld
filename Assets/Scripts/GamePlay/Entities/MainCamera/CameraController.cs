using UnityEngine;

namespace GamePlay.Entities.MainCamera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _character;
        [SerializeField] private float _smoothSpeed = 5f;
        
        private void LateUpdate()
        {
            FollowToPlayer();
        }

        private void FollowToPlayer()
        {
            if (_character != null)
            {
                Vector3 targetPosition = _character.position;
                var position = transform.position;
                Vector3 newPosition = new Vector3(targetPosition.x, position.y, targetPosition.z);
                transform.position = Vector3.Lerp(position, newPosition, _smoothSpeed * Time.deltaTime);
            }
        }
    }
}
