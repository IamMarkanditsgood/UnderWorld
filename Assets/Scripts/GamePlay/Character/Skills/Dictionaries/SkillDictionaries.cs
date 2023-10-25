using System.Collections.Generic;
using GamePlay.Bullets;

namespace GamePlay.Character.Skills.Dictionaries
{
    public class SkillDictionaries
    {
        private Dictionary<SkillTypes, float> _skillsDamage = new Dictionary<SkillTypes, float>()
        {
            { SkillTypes.None, 0f},
            { SkillTypes.Arrow, 10.0f },
            { SkillTypes.Fireball, 20.0f },
            { SkillTypes.AimRockets, 15.0f },
            { SkillTypes.Laser, 25.0f },
            { SkillTypes.QuantumBall, 30.0f },
            { SkillTypes.Swords, 12.0f },
            { SkillTypes.Mines, 18.0f },
            { SkillTypes.Turret, 27.0f },
            { SkillTypes.Vortex, 35.0f },
            { SkillTypes.Teleport, 5.0f },
            { SkillTypes.Shield, 0.0f },
            { SkillTypes.TimeStopper, 0.0f },
            { SkillTypes.SuperKiller, 40.0f }
        };
        private Dictionary<SkillTypes, float> _skillsReloadTimer = new Dictionary<SkillTypes, float>()
        {
            { SkillTypes.None, 0f},
            { SkillTypes.Arrow, 10.0f },
            { SkillTypes.Fireball, 20.0f },
            { SkillTypes.AimRockets, 15.0f },
            { SkillTypes.Laser, 25.0f },
            { SkillTypes.QuantumBall, 30.0f },
            { SkillTypes.Swords, 12.0f },
            { SkillTypes.Mines, 18.0f },
            { SkillTypes.Turret, 27.0f },
            { SkillTypes.Vortex, 35.0f },
            { SkillTypes.Teleport, 5.0f },
            { SkillTypes.Shield, 0.0f },
            { SkillTypes.TimeStopper, 0.0f },
            { SkillTypes.SuperKiller, 40.0f }
        };


        public Dictionary<SkillTypes, float> SkillsDamage
        {
            get => _skillsDamage;
            set => _skillsDamage = value;
        }
        public Dictionary<SkillTypes, float> SkillsReloadTimer
        {
            get => _skillsReloadTimer;
            set => _skillsReloadTimer = value;
        }

    }
}
