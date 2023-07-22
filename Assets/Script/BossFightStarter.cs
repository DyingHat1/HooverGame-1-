using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using IJunior.TypedScenes;

public class BossFightStarter : MonoBehaviour, ISceneLoadHandler<LevelConfig>
{
    [SerializeField] private DataSaver _dataSaver;
    [SerializeField] private RewardScreen _rewardSreen;

    private EcsWorld _world = null;
    private EcsSystems _systems = null;
    private LevelConfig _levelConfig;

    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.ConvertScene();

        AddInjections();
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

    public void OnSceneLoaded(LevelConfig argument)
    {
        _levelConfig = argument;
    }

    private void AddSystems()
    {
        _systems.Add(new BossSizeScaleSystem());
        _systems.Add(new PlayerSizeScaleSystem());
        _systems.Add(new DistanceToPlayerSystem());
        _systems.Add(new SetCameraPositionSystem());
        _systems.Add(new BossFightSystem());
    }

    private void AddInjections()
    {
        _systems.Inject(_dataSaver);
        _systems.Inject(_levelConfig);
        _systems.Inject(_rewardSreen);
    }
}
