using UnityEngine;
using Leopotam.Ecs;

public class MovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent, MovementComponent, DirectionComponent> _movableFilter = null;

    public void Run()
    {
        foreach(int i in _movableFilter)
        {
            ref Vector3 direction = ref _movableFilter.Get3(i).Direction;
            ref Transform transform = ref _movableFilter.Get1(i).ModelTransform;
            ref float velocity = ref _movableFilter.Get2(i).Velocity;

            transform.position += direction * velocity * Time.deltaTime;
        }
    }
}
