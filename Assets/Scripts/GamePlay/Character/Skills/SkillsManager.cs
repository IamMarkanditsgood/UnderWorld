using Character.Data;

namespace GamePlay.Character.Skills
{
    public class SkillsManager
    {
        public void SetInitialSkillsData(CharacterData characterData)
        {
            characterData.MainSkillData.SkillTypes = SkillTypes.Teleport;
            characterData.MainSkillData.Skill = new Teleport();
            characterData.MainSkillData.SkillsConfig = characterData.MainSkillScriptableObject;
            
            characterData.ShootskillData.SkillTypes = SkillTypes.Arrow;
            characterData.ShootskillData.Skill = new Arrow();
            characterData.ShootskillData.SkillsConfig = characterData.ShootSkillScriptableObject;
            
            characterData.SupportkillData.SkillTypes = SkillTypes.Swords;
            characterData.SupportkillData.Skill = new Swords();
            characterData.SupportkillData.SkillsConfig = characterData.SupportSkillScriptableObject;
        }
        public void UseSkill(ISkillUsable skill)
        {
            skill.UseSkill();
        }
    }
}
