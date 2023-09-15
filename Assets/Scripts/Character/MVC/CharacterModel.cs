using Character.Data;
using UnityEngine;

namespace Character.MVC
{
    public class CharacterModel
    {
        private void SetInitialSkillsData(CharacterData characterData)
        {
            characterData.MainSkillData.SkillTypes = SkillTypes.Teleport;
            characterData.MainSkillData.Skill = new Teleport();
            characterData.MainSkillData.SkillsScriptableObject = characterData.MainSkillScriptableObject;
            
            characterData.ShootskillData.SkillTypes = SkillTypes.Arrow;
            characterData.ShootskillData.Skill = new Arrow();
            characterData.ShootskillData.SkillsScriptableObject = characterData.ShootSkillScriptableObject;
            
            characterData.SupportkillData.SkillTypes = SkillTypes.Swords;
            characterData.SupportkillData.Skill = new Swords();
            characterData.SupportkillData.SkillsScriptableObject = characterData.SupportSkillScriptableObject;
        }
        
        public void SetInitialData(CharacterData characterData)
        {
            SetInitialSkillsData(characterData);
        }
        public void MoveCharacter(Vector2 moveDirectionData, Rigidbody rigidbody, float moveSpeed, float maxSpeed)
        {
            Vector3 moveDirection = new Vector3(moveDirectionData.x, 0, moveDirectionData.y).normalized;
            Vector3 moveVelocity = moveDirection * moveSpeed;

            rigidbody.AddForce(moveVelocity, ForceMode.Acceleration);
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
        }
        public void RotateCharacter(GameObject character,Transform target, float rotationSpeed)
        {
            if (target != null)
            {
                var position = target.position;
                var position1 = character.transform.position;
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

        public void UseSkill(ISkillUsable skill)
        {
            skill.UseSkill();
        }

        public void InteractWithEnvironment(GameObject interactableObject)
        {
            interactableObject.GetComponent<IInteractable>().InteractWithCharacter();
        }

    }
}