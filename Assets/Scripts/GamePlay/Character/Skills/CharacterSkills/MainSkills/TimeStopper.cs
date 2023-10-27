using System;
using System.Threading;
using System.Threading.Tasks;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.MainSkills
{
    public class TimeStopper : ISkillUsable, IDisposable
    {
        private const int StopperTime = 5;
        private const int SecondsByMillisecond = 1000;
    
        private CancellationTokenSource _cancellationTokenSource = new();
        public async void UseSkill(GameObject character, SkillDictionaries skillDictionaries, SkillsConfig skillConfig)
        {
            Time.timeScale = 0.2f;
            await ShieldTimer(_cancellationTokenSource.Token);
        }

        private async Task ShieldTimer(CancellationToken cancellationToken)
        {
            var completionSource = new TaskCompletionSource<bool>();
            cancellationToken.Register(() => completionSource.TrySetCanceled());
        
            await Task.Delay(StopperTime * SecondsByMillisecond);
            Time.timeScale = 1;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
