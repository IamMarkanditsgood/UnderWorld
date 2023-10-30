using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.SupportSkills
{
    public class Swords : BaseSkillUsable, IDisposable
    {
        private bool _inUse;
        
        private readonly GameObject _swords;
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        private const int SwordsTime = 2;
        private const int SecondsByMillisecond = 1000;

        public Swords(GameObject swords)
        {
            _swords = swords;
        }
        public override async void UseSkill()
        {
            if (!_inUse)
            {
                _inUse = true;
                _swords.SetActive(true);
        
                await ShieldTimer(_cancellationTokenSource.Token);
            }
        }

        private async Task ShieldTimer(CancellationToken cancellationToken)
        {
            TaskCompletionSource<bool> completionSource = new();
            cancellationToken.Register(() => completionSource.TrySetCanceled());
        
            await Task.Delay(SwordsTime * SecondsByMillisecond, cancellationToken);
            _swords.SetActive(false);
            _inUse = false;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
