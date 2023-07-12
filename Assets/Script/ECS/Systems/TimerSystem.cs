using UnityEngine;
using Leopotam.Ecs;

public class TimerSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<TimerComponent> _timerFilter = null;

    public void Init()
    {
        foreach(int i in _timerFilter)
        {
            _timerFilter.Get1(i).View.text = _timerFilter.Get1(i).Value.ToString("F");
        }
    }

    public void Run()
    {
        foreach (int i in _timerFilter)
        {
            ref float timerValue = ref _timerFilter.Get1(i).Value;

            if (timerValue - Time.deltaTime >= 0)
            {
                timerValue -= Time.deltaTime;
                _timerFilter.Get1(i).View.text = timerValue.ToString("F");
            }
        }
    }
}
