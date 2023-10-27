using System;
using System.Threading;
using System.Threading.Tasks;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.MainSkills
{
    public class Shield : ISkillUsable, IDisposable
    {
        private GameObject _shield;
        private bool _isUse;
        
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillsConfig skillConfig)
        {
            if (!_isUse)
            {
                _isUse = true;
                _shield = character.GetComponent<Character>().Shield;
                _shield.SetActive(true);

                 ShieldTimer(_cancellationTokenSource.Token);
            }
        }

        private async Task ShieldTimer(CancellationToken cancellationToken)
        {
            var completionSource = new TaskCompletionSource<bool>();
            cancellationToken.Register(() => completionSource.TrySetCanceled());
        
            await Task.Delay(Constants.ShieldTime * Constants.SecondsByMillisecond);
            _shield.SetActive(false);
            _isUse = false;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
