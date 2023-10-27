using System.Threading;
using System.Threading.Tasks;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.SupportSkills
{
    public class Vortex : ISkillUsable
    {
        private GameObject _vortex;
        private bool _isUse;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            if (!_isUse)
            {
                _isUse = true;
                _vortex = character.GetComponent<Character>().Vortex;
                _vortex.SetActive(true);
        
                 VortexTimer(_cancellationTokenSource.Token);
            }
        }

        private async Task VortexTimer(CancellationToken cancellationToken)
        {
            var completionSource = new TaskCompletionSource<bool>();
            cancellationToken.Register(() => completionSource.TrySetCanceled());
        
            await Task.Delay(Constants.VortexTime * Constants.SecondsByMillisecond);
            _vortex.SetActive(false);
            _isUse = false;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
