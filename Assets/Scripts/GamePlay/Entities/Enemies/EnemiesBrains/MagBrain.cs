using GamePlay.Entities.Bullets;
using GamePlay.Entities.Character.Skills;
using GamePlay.Entities.Character.Skills.Enums;
using GamePlay.Entities.Enemies.EnemySkills;
using GamePlay.Entities.Enemies.EnemySkills.Skills;
using GamePlay.Entities.Skills;
using GamePlay.Entities.Skills.CharacterSkills;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Entities.Enemies.EnemiesBrains
{
    public class MagBrain: BaseBrain
    {
        private float _distanceToPlayer;
        private EnemyBaseSkill _enemyFarSkill ;
        public MagBrain(Transform playerPosition,ISpawner<BulletObject> bulletSpawner) : base(playerPosition,bulletSpawner)
        {
        }
        
        public override void CheckDistance(Transform positionOfEnemy)
        {
            _distanceToPlayer = Vector3.Distance(positionOfEnemy.position, PlayerPosition.position);
            base.SetDestination();
            base.Stop();
            if (_distanceToPlayer >= WaitDistance)
            {
                base.Stop();
            }
            else if (_distanceToPlayer <= WaitDistance && _distanceToPlayer >= FarAttackDistance)
            {
                base.Move();
            }
            else if (_distanceToPlayer <= FarAttackDistance)
            {
                base.Attack(_enemyFarSkill);
                base.Stop();
            }
        }

        public override void InitializeSkills()
        {
            _enemyFarSkill = new MagicShoot(BulletSpawner, ShootingSkillPosition);
            SkillFinder skillFinderFinder = new SkillFinder();
            SkillConfig farSkill = skillFinderFinder.GetSkillConfig(EnemyConfig.EnemySkills, SkillTypes.Fireball);
            _enemyFarSkill.Init(farSkill);
        }
    }
}