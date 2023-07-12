using UnityEngine;

public class DataSaver : MonoBehaviour
{
    private const string MoneyKey = "SavedMoney";
    private const string LevelKey = "SavedLevel";
    private int _money = 0;
    private int _level = 1;

    private void Awake()
    {
        TryLoadData();
    }

    public void SetMoney(int money)
    {
        _money = money;
        SaveData();
    }

    public void SetLevel(int level)
    {
        _level = level;
        SaveData();
    }

    public int GetMoney()
    {
        return _money;
    }

    public int GetLevel()
    {
        return _level;
    }

    public void Clear()
    {
        PlayerPrefs.DeleteAll();
        _money = 0;
        _level = 1;
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(MoneyKey, _money);
        PlayerPrefs.SetInt(LevelKey, _level);
        PlayerPrefs.Save();
    }

    private bool TryLoadData()
    {
        if (PlayerPrefs.HasKey(MoneyKey))
        {
            _money = PlayerPrefs.GetInt(MoneyKey);
            _level = PlayerPrefs.GetInt(LevelKey);
            return true;
        }

        return false;
    }
}
