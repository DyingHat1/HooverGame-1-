using Leopotam.Ecs;
using UnityEngine;

public class CameraMovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<ModelComponent,
        FollowComponent> _cameraFilter = null;

    public void Run()
    {
        foreach (int i in _cameraFilter)
        {
            FollowComponent followComponent = _cameraFilter.Get2(i);
            Vector3 distanceToTarget = followComponent.DistanceToTarget;
            Transform target = followComponent.Target;
            ref Transform transform = ref _cameraFilter.Get1(i).ModelTransform;

            transform.position = target.position - distanceToTarget;
        }
    }
}
