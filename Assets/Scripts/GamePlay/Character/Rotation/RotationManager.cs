using Character.Data;
using UnityEngine;

namespace GamePlay.Character.Rotation
{
    public class RotationManager
    {
        public void RotateCharacter(GameObject character,Transform target, float rotationSpeed)
        {
            if (target != null)
            {
                Vector3 position = target.position;
                Vector3 position1 = character.transform.position;
                Vector3 targetPosition = new Vector3(position.x, position1.y, position.z);
                Quaternion targetRotation = Quaternion.LookRotation(targetPosition - position1);
                float step = rotationSpeed * Time.deltaTime;
                character.transform.rotation = Quaternion.Slerp(character.transform.rotation, targetRotation, step);
            }
            
        }
        public void MoveRotationTarget(CharacterData characterData,Vector2 mouseScreenPos)
        {
            if (Camera.main != null)
                characterData.RotationTarget.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x,
                    mouseScreenPos.y, Camera.main.transform.position.y));
        }
    }
}
