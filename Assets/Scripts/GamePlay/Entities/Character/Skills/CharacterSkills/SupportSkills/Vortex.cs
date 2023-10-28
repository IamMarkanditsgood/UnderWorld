using System.Threading;
using System.Threading.Tasks;
using GamePlay.Entities.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.SupportSkills
{
    public class Vortex : BaseSkillUsable
    {
        private bool _isUse;

        private readonly GameObject _vortex;
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public Vortex(GameObject vortex)
        {
            _vortex = vortex;
        }

        public override async void UseSkill()
        {
            if (!_isUse)
            {
                _isUse = true;
                _vortex.SetActive(true);

                await VortexTimer(_cancellationTokenSource.Token);
            }
        }

        private async Task VortexTimer(CancellationToken cancellationToken)
        {
            TaskCompletionSource<bool> completionSource = new();
            cancellationToken.Register(() => completionSource.TrySetCanceled());

            await Task.Delay(Constants.VortexTime * Constants.SecondsByMillisecond, cancellationToken);
            _vortex.SetActive(false);
            _isUse = false;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}