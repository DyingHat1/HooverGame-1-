using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class BossFightSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<BossTag, SizeComponent, AnimatorComponent> _bossFilter = null;
    private readonly EcsFilter<PlayerTag, SizeComponent, AnimatorComponent> _playerFilter = null;
    private readonly RewardScreen _rewardScreen = null;
    private const string AttackParameterName = "Attack";
    private const string DieParameterName = "Die";
    private bool _isPlayerWon;
    private float _timer = 5f;

    public void Init()
    {
        _isPlayerWon = _playerFilter.Get2(0).Size >= _bossFilter.Get2(0).Size;

        foreach(int i in _bossFilter)
        {
            _bossFilter.Get3(i).Animator.SetBool(AttackParameterName, true);
        }

        foreach (int i in _playerFilter)
        {
            _playerFilter.Get3(i).Animator.SetBool(AttackParameterName, true);
        }
    }

    public void Run()
    {
        foreach (int i in _playerFilter)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                StopAttack(i);
                EndFight(i);
                _playerFilter.GetEntity(i).Destroy();
                _rewardScreen.ActivateWindow(_isPlayerWon);
            }
        }
    }

    private void StopAttack(int i)
    {
        _playerFilter.Get3(i).Animator.SetBool(AttackParameterName, false);

        foreach (int j in _bossFilter)
        {
            _bossFilter.Get3(j).Animator.SetBool(AttackParameterName, false);
        }
    }

    private void EndFight(int i)
    {
        if (_isPlayerWon)
        {
            foreach (int j in _bossFilter)
            {
                _bossFilter.Get3(j).Animator.SetTrigger(DieParameterName);
            }
        }
        else
        {
            _playerFilter.Get3(i).Animator.SetTrigger(DieParameterName);
        }
    }
}
