using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.MainSkills
{
    public class Teleport : ISkillUsable
    {
        private Rigidbody _rigidBody;
        
        private const float TeleportDistance = 5f;
        
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillsConfig skillConfig)
        {
            _rigidBody = character.GetComponent<Rigidbody>();
            
            Vector3 moveDirection = _rigidBody.velocity.normalized;
            Vector3 newPosition = _rigidBody.position + moveDirection * TeleportDistance;
            _rigidBody.MovePosition(newPosition);
        }
    }
}
