using UnityEngine;

namespace GamePlay.Entities.Enemies.EnemySkills.Skills
{
    public class SwordAttack: EnemyBaseSkill
    {
        public override void UseSkill()
        {
            Debug.Log("Sword");
        }
    }
}