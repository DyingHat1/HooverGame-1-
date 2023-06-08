using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class PlayerSizeChangerSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<PlayerTag, SizeComponent, ModelComponent> _playerFilter = null;

    private List<Vector3> _startSizes;

    public void Init()
    {
        _startSizes = new List<Vector3>();

        foreach (int i in _playerFilter)
        {
            _startSizes.Add(_playerFilter.Get3(i).ModelTransform.localScale);
        }
    }

    public void Run()
    {
        foreach(int i in _playerFilter)
        {
            ref Transform entity = ref _playerFilter.Get3(i).ModelTransform;
            float size = _playerFilter.Get2(i).Size;

            entity.localScale = _startSizes[i] * size;
        }
    }
}
