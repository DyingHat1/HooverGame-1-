using UnityEngine;
using Leopotam.Ecs;

public class BossFightSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<BossTag, SizeComponent> _bossFilter = null;
    private readonly EcsFilter<PlayerTag, SizeComponent> _playerFilter = null;
    private readonly RewardScreen _rewardScreen = null;
    private bool _isPlayerWon;
    private float _timer = 5f;

    public void Init()
    {
        _isPlayerWon = _playerFilter.Get2(0).Size >= _bossFilter.Get2(0).Size;
    }

    public void Run()
    {
        foreach (int i in _bossFilter)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _bossFilter.GetEntity(i).Destroy();
                _rewardScreen.ActivateWindow(_isPlayerWon);
            }
        }
    }
}
