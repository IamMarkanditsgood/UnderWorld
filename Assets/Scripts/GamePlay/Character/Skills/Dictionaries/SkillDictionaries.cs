using System.Collections.Generic;

namespace Skills.Dictionaries
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
            { SkillTypes.SuperGuns, 22.0f },
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
            { SkillTypes.SuperGuns, 22.0f },
            { SkillTypes.Turret, 27.0f },
            { SkillTypes.Vortex, 35.0f },
            { SkillTypes.Teleport, 5.0f },
            { SkillTypes.Shield, 0.0f },
            { SkillTypes.TimeStopper, 0.0f },
            { SkillTypes.SuperKiller, 40.0f }
        };
    }
}