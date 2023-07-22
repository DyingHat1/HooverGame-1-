using UnityEngine;
using Leopotam.Ecs;

public class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerInputComponent,DirectionComponent, RotateComponent> 
        _directionFilter = null;

    private Vector3 _direction;
    private float _rotation;

    public void Run()
    {
        foreach (int i in _directionFilter)
        {
            Vector3 direction = _directionFilter.Get1(i).PlayerController.Direction;
            SetDirection(direction);
            
            if (direction != Vector3.zero)
            {
                SetRotation();
                _directionFilter.Get3(i).Rotation = _rotation;
            }

            _directionFilter.Get2(i).Direction = _direction;
        }
    }

    private void SetDirection(Vector3 direction)
    {
        _direction.x = direction.x;
        _direction.z = direction.y;
    }

    private void SetRotation()
    {
        _rotation = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
    }
}
