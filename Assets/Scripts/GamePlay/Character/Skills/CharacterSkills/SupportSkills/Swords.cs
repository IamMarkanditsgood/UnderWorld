using System.Threading;
using System.Threading.Tasks;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.SupportSkills
{
    public class Swords : ISkillUsable
    {
        private GameObject _swords;
        private CancellationTokenSource _cancellationTokenSource = new();
        private bool _inUse = false;

        private const int SwordsTime = 2;
        private const int SecondsByMillisecond = 1000;

        public async void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillsConfig skillConfig)
        {
            if (!_inUse)
            {
                _inUse = true;
                _swords = character.GetComponent<Character>().Swords;
                _swords.SetActive(true);
        
                await ShieldTimer(_cancellationTokenSource.Token);
            }
        }

        private async Task ShieldTimer(CancellationToken cancellationToken)
        {
            var completionSource = new TaskCompletionSource<bool>();
            cancellationToken.Register(() => completionSource.TrySetCanceled());
        
            await Task.Delay(SwordsTime * SecondsByMillisecond);
            _swords.SetActive(false);
            _inUse = false;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
