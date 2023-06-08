using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private EcsWorld _world = null;
    private EcsSystems _systems = null;

    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();

        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems?.Destroy();
        _systems = null;
        _world?.Destroy();
        _world = null;
    }

    private void AddSystems()
    {
        _systems.Add(new PlayerInputSystem());
        _systems.Add(new CollectItemsSystem());
        _systems.Add(new MovementSystem());
        _systems.Add(new RotateSystem());
        _systems.Add(new CameraMovementSystem());
        _systems.Add(new PlayerSizeChangerSystem());
    }

    private void AddInjections()
    {

    }

    private void AddOneFrames()
    {

    }
}
