using System;
using System.Threading;
using System.Threading.Tasks;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.MainSkills
{
    public class Shield : BaseSkillUsable, IDisposable
    {
        private bool _isUse;
        
        private readonly GameObject _shield;
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        

        public Shield(GameObject shield)
        {
            _shield = shield;
        }
        public override async void UseSkill()
        {
            if (!_isUse)
            {
                _isUse = true;
                _shield.SetActive(true);

                await ShieldTimer(_cancellationTokenSource.Token);
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
