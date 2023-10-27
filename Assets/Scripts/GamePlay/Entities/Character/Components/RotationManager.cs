using System;
using Unity.VisualScripting;
using UnityEngine;

namespace GamePlay.Character.Components
{
    [Serializable]
    public class RotationManager
    {
        [SerializeField] private Transform _rotationTarget;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] public float _smoothSpeed = 5.0f;

        private Transform _character;
        
        public void InitData(Transform character)
        {
            _character = character;
        }
        
        public void RotateCharacter()
        {
            if (_rotationTarget != null)
            {
                Vector3 targetPosition = _rotationTarget.position;
                Vector3 characterPosition = _character.transform.position;
                Vector3 newTargetPosition = new Vector3(targetPosition.x, characterPosition.y, targetPosition.z);
                Quaternion targetRotation = Quaternion.LookRotation(newTargetPosition - characterPosition);
                float step = _rotationSpeed * Time.deltaTime;
                _character.transform.rotation = Quaternion.Slerp(_character.transform.rotation, targetRotation, step);
            }
            
        }
        public void MoveRotationTarget()
        {
            Vector2 mouseScreenPos = Input.mousePosition;
            if (Camera.main != null)
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Camera.main.transform.position.y));
                _rotationTarget.position = Vector3.Lerp(_rotationTarget.position, mouseWorldPos, _smoothSpeed * Time.deltaTime);
            }
        }
    }
}
