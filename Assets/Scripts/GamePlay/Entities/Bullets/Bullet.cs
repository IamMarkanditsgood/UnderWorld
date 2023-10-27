using GamePlay.Bullets;
using GamePlay.Bullets.Movers;
using UnityEngine;

namespace GamePlay.Entities.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private SkillTypes _skillTypes;
        [SerializeField] private SkillObjectConfig _skillObjectConfig;

        private BaseMover _bulletMover;
        
        
        public void InitBullet(SkillTypes bulletTypes, BaseMover mover,SkillObjectConfig skillObjectConfig)
        {
            _skillTypes = bulletTypes;
            _bulletMover = mover;
            _skillObjectConfig = skillObjectConfig;

        }
        private void Update()
        {     
            _bulletMover.Move(gameObject, _skillObjectConfig.Speed );
        }
    }
}
