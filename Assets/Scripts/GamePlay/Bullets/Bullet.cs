using System;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private SkillTypes _skillTypes;
        [SerializeField] private SkillObjectConfig _skillObjectConfig;

        private IBulletMovable _bulletMover;
        
        
        public void InitBullet(SkillTypes bulletTypes, IBulletMovable mover,SkillObjectConfig skillObjectConfig)
        {
            _skillTypes = bulletTypes;
            _bulletMover = mover;
            _skillObjectConfig = skillObjectConfig;

        }
        private void FixedUpdate()
        {     
            _bulletMover.Move(gameObject, _skillObjectConfig.Speed );
        }
    }
}
