using Leopotam.Ecs;
using UnityEngine;

public class TimerStopSystem : IEcsRunSystem
{
    private readonly EcsFilter<TimerComponent> _eventsFilter = null;
    private readonly EcsFilter<PlayerTag, SizeComponent> _playerFilter = null;
    private readonly SceneChanger _sceneChanger = null;

    public void Run()
    {
        foreach(int i in _eventsFilter)
        {
            if (_eventsFilter.Get1(i).Value <= 0.01f)
            {
                float playerSize = _playerFilter.Get2(0).Size;
                _eventsFilter.GetEntity(i).Del<TimerComponent>();
                _sceneChanger.StartBossFight(playerSize);
            }
        }
    }
}
