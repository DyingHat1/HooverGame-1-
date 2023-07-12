using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private Button _clearButton;
    [SerializeField] private DataSaver _dataSaver;
    [SerializeField] private CoinsHolder _coins;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _clearButton.onClick.AddListener(OnClearButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _clearButton.onClick.RemoveListener(OnClearButtonClick);
    }

    private void OnStartButtonClick()
    {
        _sceneChanger.StartGame();
    }

    private void OnExitButtonClick()
    {
        _sceneChanger.ExitGame();
    }

    private void OnClearButtonClick()
    {
        _dataSaver.Clear();
        _coins.ReloadCoinsView();
    }
}
