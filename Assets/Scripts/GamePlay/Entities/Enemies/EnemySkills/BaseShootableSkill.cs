using GamePlay.Entities.Bullets.Movers;

namespace GamePlay.Entities.Enemies.EnemySkills
{
    public class BaseShootableSkill : EnemyBaseSkill
    {
        private BaseMover _mover;
        public BaseShootableSkill(BaseMover mover)
        {
            _mover = mover;
        }
        public override void UseSkill()
        {
            Shoot(_mover);
        }

        private void Shoot(BaseMover mover) //TODO Make one class for enemy and character for shooting
        {
            
        }
    }
}