using Leopotam.Ecs;
using UnityEngine;

public class DistanceToPlayerSystem : IEcsInitSystem
{
    private readonly EcsFilter<BossTag, SizeComponent, ModelComponent> _bossFilter = null;
    private readonly EcsFilter<PlayerTag, SizeComponent, ModelComponent> _playerFilter = null;

    private float _minDistance = 2f;

    public void Init()
    {
        foreach (int i in _playerFilter)
        {
            _minDistance += _playerFilter.Get2(i).Size / 2f;

            foreach (int j in _bossFilter)
            {
                ref ModelComponent bossModel = ref _bossFilter.Get3(j);
                _minDistance += _bossFilter.Get2(j).Size / 2f;

                bossModel.ModelTransform.position = _playerFilter.Get3(i).ModelTransform.position + (Vector3.right * 
                    _minDistance);
            }
        }
    }
}
