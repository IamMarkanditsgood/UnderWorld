using System;
using System.Threading;
using System.Threading.Tasks;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.MainSkills
{
    public class Shield : ISkillUsable, IDisposable
    {
        private GameObject _shield;
        private CancellationTokenSource _cancellationTokenSource = new();
        private bool _inUse = false;
        
        private const int ShieldTime = 5;
        private const int SecondsByMillisecond = 1000;

        public async void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            if (!_inUse)
            {
                _inUse = true;
                _shield = character.GetComponent<Character>().Shield;
                _shield.SetActive(true);

                await ShieldTimer(_cancellationTokenSource.Token);
            }
        }

        private async Task ShieldTimer(CancellationToken cancellationToken)
        {
            var completionSource = new TaskCompletionSource<bool>();
            cancellationToken.Register(() => completionSource.TrySetCanceled());
        
            await Task.Delay(ShieldTime * SecondsByMillisecond);
            _shield.SetActive(false);
            _inUse = false;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
