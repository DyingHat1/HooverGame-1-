using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Create Level Config")]
public class LevelConfig : ScriptableObject
{
    private float _playerSize = 0;

    public void SetPlayerSize(float playerSize)
    {
        if (_playerSize == 0 && playerSize > 0)
            _playerSize = playerSize;
    }

    public float GetPlayerSize()
    {
        float value = _playerSize;

        if (value <= 0)
            value = 1;

        _playerSize = 0;
        return value;
    }
}
