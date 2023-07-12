using UnityEngine;
using IJunior.TypedScenes;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Level.Load();
    }

    public void OpenMainMenu()
    {
        MainMenu.Load();
    }

    public void StartBossFight(float playerSize)
    {
        _levelConfig.SetPlayerSize(playerSize);
        BossFight.Load(_levelConfig);
    }
}
