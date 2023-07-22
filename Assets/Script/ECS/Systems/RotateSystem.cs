using Leopotam.Ecs;
using UnityEngine;

public class RotateSystem : IEcsRunSystem
{
    private readonly EcsFilter<RotateComponent, ModelComponent> _playerFilter;

    public void Run()
    {
        foreach(int i in _playerFilter)
        {
            RotateComponent rotateComponent = _playerFilter.Get1(i);
            ref ModelComponent modelComponent = ref _playerFilter.Get2(i);
            modelComponent.ModelTransform.rotation = Rotate(rotateComponent.Rotation);
        }
    }

    private Quaternion Rotate(float rotation)
    {
        return Quaternion.Euler(0, rotation,0);
    }
}
