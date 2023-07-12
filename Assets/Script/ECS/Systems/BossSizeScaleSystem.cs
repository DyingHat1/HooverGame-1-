using UnityEngine;
using Leopotam.Ecs;

public class BossSizeScaleSystem : IEcsInitSystem
{
    private readonly EcsFilter<BossTag, SizeComponent, ModelComponent> _bossFilter = null;
    private readonly DataSaver _dataSaver = null;
    private float bossSizeScaler = 1.5f;

    public void Init()
    {
        foreach (int i in _bossFilter)
        {
            ref SizeComponent bossSize = ref _bossFilter.Get2(i);
            ref ModelComponent bossModel = ref _bossFilter.Get3(i);
            bossSize.Size = _dataSaver.GetLevel() * bossSizeScaler;
            bossModel.ModelTransform.Translate(Vector3.up * (bossSize.Size / 2f));
            bossModel.ModelTransform.localScale *= bossSize.Size;
        }
    }
}
