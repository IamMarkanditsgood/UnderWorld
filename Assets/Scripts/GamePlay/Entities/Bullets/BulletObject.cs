using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Character.Skills.Enums;
using UnityEngine;

namespace GamePlay.Entities.Bullets
{
    public class BulletObject : MonoBehaviour
    {
        [SerializeField] private SkillObjectConfig _skillObjectConfig;

        private BaseMover _bulletMover;
        
        
        public void InitBullet(BaseMover mover,SkillObjectConfig skillObjectConfig)
        {
            _bulletMover = mover;
            _skillObjectConfig = skillObjectConfig;

        }
        private void Update()
        {
            _bulletMover.Move(gameObject, _skillObjectConfig.Speed );
        }
    }
}
