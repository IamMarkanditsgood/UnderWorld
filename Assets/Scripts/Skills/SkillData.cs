namespace Skills
{
    public class SkillData 
    {
        private SkillsScriptableObject _skillsScriptableObject;
        private SkillTypes _skillType;
        private ISkillUsable _skill;

        public SkillsScriptableObject SkillsScriptableObject
        {
            get => _skillsScriptableObject;
            set => _skillsScriptableObject = value;
        }

        public SkillTypes SkillTypes
        {
            get => _skillType;
            set => _skillType = value;
        }

        public ISkillUsable Skill
        {
            get => _skill;
            set => _skill = value;
        }
    }
}
