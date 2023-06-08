using Leopotam.Ecs;
using UnityEngine;

public class CollectItemsSystem :  IEcsRunSystem
{
    private readonly EcsFilter<CollectableItemTag, ModelComponent, SizeComponent> 
        _itemsFilter = null;

    private readonly EcsFilter<ItemsCollectorComponent, ModelComponent, SizeComponent> 
        _playerFilter = null;

    private float _substractValue = 2f;
    public void Run()
    {
        foreach(int i in _playerFilter)
        {
            Transform collector = _playerFilter.Get2(i).ModelTransform;
            ref float distance = ref _playerFilter.Get1(i).CollectDistance;
            ref int collectedItems = ref _playerFilter.Get1(i).ItemsCollected;
            ref float collectorSize = ref _playerFilter.Get3(i).Size;

            foreach (int j in _itemsFilter)
            {
                Transform item = _itemsFilter.Get2(j).ModelTransform;
                float itemSize = _itemsFilter.Get3(j).Size;

                if (GetDistance(collector, item) <= distance)
                {
                    if (collectorSize > itemSize)
                    {
                        collectedItems++;
                        collectorSize += itemSize / _substractValue;
                        distance += itemSize / _substractValue;
                        _itemsFilter.GetEntity(j).Destroy();
                        Object.Destroy(item.gameObject);
                    }
                }
            }
        }
    }

    private float GetDistance(Transform collector, Transform item)
    {
        return Vector3.Distance(collector.position, item.position);
    }
}
