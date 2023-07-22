using Leopotam.Ecs;
using UnityEngine;
public class SetCameraPositionSystem : IEcsInitSystem
{
    private readonly EcsFilter<CameraTag, ModelComponent> _cameraFilter = null;
    private readonly EcsFilter<PlayerTag, SizeComponent, ModelComponent> _playerFilter = null;
    private readonly EcsFilter<BossTag, SizeComponent, ModelComponent> _bossFilter = null;

    private Vector3 _cameraPosition = new Vector3();
    private float _minZPosition = -2f;
    private float _minYPosition = 1f;
    private float _maxSize;

    public void Init()
    {
        _cameraPosition.x = 0;
        _cameraPosition.z = _minZPosition;
        _cameraPosition.y = _minYPosition;

        foreach (int i in _cameraFilter)
        {
            foreach (int j in _playerFilter)
            {
                foreach (int h in _bossFilter)
                {
                    float distance = Vector3.Distance(_playerFilter.Get3(j).ModelTransform.position,
                        _bossFilter.Get3(h).ModelTransform.position);

                    float bossSize = _bossFilter.Get2(h).Size;
                    float playerSize = _playerFilter.Get2(j).Size;

                    SetMaxSize(bossSize, playerSize);
                    _cameraPosition.x = _playerFilter.Get3(i).ModelTransform.position.x + (distance / 2f);
                    _cameraFilter.Get2(i).ModelTransform.position = _cameraPosition;
                }
            }
        }
    }

    private void SetMaxSize(float bossSize, float playerSize)
    {
        if (bossSize > playerSize)
            _maxSize = bossSize;
        else
            _maxSize = playerSize;

        _cameraPosition.z *= _maxSize;
        _cameraPosition.y *= _maxSize;
    }
}
