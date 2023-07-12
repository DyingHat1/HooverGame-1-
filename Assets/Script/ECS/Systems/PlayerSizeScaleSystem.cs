using Leopotam.Ecs;

public class PlayerSizeScaleSystem : IEcsInitSystem
{
    private readonly EcsFilter<PlayerTag, SizeComponent, ModelComponent> _playerFilter = null;
    private readonly LevelConfig _levelConfig = null;

    public void Init()
    {
        foreach(int i in _playerFilter)
        {
            ref SizeComponent playerSize = ref _playerFilter.Get2(i);
            ref ModelComponent playerModel = ref _playerFilter.Get3(i);

            playerSize.Size = _levelConfig.GetPlayerSize();
            playerModel.ModelTransform.localScale *= playerSize.Size;
        }
    }
}
