using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Character.Skills;
using GamePlay.Entities.Character.Skills.Enums;
using GamePlay.Entities.Enemies.EnemySkills;
using GamePlay.Entities.Enemies.EnemySkills.Skills;
using GamePlay.Entities.Enemies.ScriptableObject;
using GamePlay.Entities.Skills;
using GamePlay.Entities.Skills.CharacterSkills;
using Sirenix.OdinInspector.Editor;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Entities.Enemies.EnemiesBrains
{
    public class PaladinBrain: BaseBrain
    {
        private float _distanceToPlayer;
        private EnemyBaseSkill _enemyFarSkill ;
        private EnemyBaseSkill _enemyCloseSkill;
        

        public PaladinBrain(Transform playerPosition ,ISpawner<BulletObject> bulletSpawner) : base(playerPosition,bulletSpawner)
        {
            
        }

        public override void InitializeSkills()
        {
            _enemyFarSkill = new MagicShoot(BulletSpawner, ShootingSkillPosition);
            _enemyCloseSkill = new SwordAttack();
            SkillFinder skillFinderFinder = new SkillFinder();
            SkillConfig farSkill = skillFinderFinder.GetSkillConfig(EnemyConfig.EnemySkills, SkillTypes.Fireball);
            SkillConfig closeSkill = skillFinderFinder.GetSkillConfig(EnemyConfig.EnemySkills, SkillTypes.Swords);
            _enemyFarSkill.Init(farSkill);
            _enemyCloseSkill.Init(closeSkill);
        }
        public override void CheckDistance(Transform positionOfEnemy)
        {
            _distanceToPlayer = Vector3.Distance(positionOfEnemy.position, PlayerPosition.position);
            base.SetDestination();
            base.Stop();
            if (_distanceToPlayer >= CloseAttackDistance && _distanceToPlayer <= FarAttackDistance)
            {
                base.Move();
                base.Attack(_enemyFarSkill);
            }
            else if (_distanceToPlayer >= CloseAttackDistance && _distanceToPlayer <= WaitDistance)
            {
                base.Move();
            }
            else if (_distanceToPlayer <= CloseAttackDistance && _distanceToPlayer <= FarAttackDistance)
            {
                
                base.Attack(_enemyCloseSkill);
                base.Stop();
            }
            else
            {
                base.Stop();
            }
        }

        
    }
}