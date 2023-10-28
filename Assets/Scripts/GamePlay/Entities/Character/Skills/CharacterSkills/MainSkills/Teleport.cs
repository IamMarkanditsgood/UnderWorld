using GamePlay.Entities.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.MainSkills
{
    public class Teleport : BaseSkillUsable
    {
        private readonly Rigidbody _rigidBody;
        
        private const float TeleportDistance = 5f;

        public Teleport(Rigidbody rigidbody)
        {
            _rigidBody = rigidbody;
        }
        public override void UseSkill()
        {
            Vector3 moveDirection = _rigidBody.velocity.normalized;
            Vector3 newPosition = _rigidBody.position + moveDirection * TeleportDistance;
            _rigidBody.MovePosition(newPosition);
        }
    }
}
