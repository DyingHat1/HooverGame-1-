using UnityEngine;
using Leopotam.Ecs;

public class MovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent, MovementComponent, DirectionComponent, AnimatorComponent> 
        _movableFilter = null;

    private const string RunParameterName = "Run";

    public void Run()
    {
        foreach(int i in _movableFilter)
        {
            ref Vector3 direction = ref _movableFilter.Get3(i).Direction;
            ref Transform transform = ref _movableFilter.Get1(i).ModelTransform;
            ref float velocity = ref _movableFilter.Get2(i).Velocity;

            if (direction != Vector3.zero)
            {
                transform.position += direction * velocity * Time.deltaTime;
                _movableFilter.Get4(i).Animator.SetBool(RunParameterName, true);
            }
            else
            {
                _movableFilter.Get4(i).Animator.SetBool(RunParameterName, false);
            }
        }
    }
}
