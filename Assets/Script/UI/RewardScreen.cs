using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardScreen : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private TMP_Text _rewardView;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private DataSaver _dataSaver;
    [SerializeField] private int _minReward;
    [SerializeField] private int _bonusFromBoss;

    private int _reward;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
    }

    public void ActivateWindow(bool isPlayerWon)
    {
        int level = _dataSaver.GetLevel();
        _reward = _minReward;

        if (isPlayerWon)
        {
            _reward += _bonusFromBoss;
            _reward *= level;
            level++;
        }

        SetRewardView();
        gameObject.SetActive(true);
        SaveData(level);
    }

    private void OnContinueButtonClick()
    {
        _sceneChanger.OpenMainMenu();
    }

    private void SetRewardView()
    {
        _rewardView.text = _reward.ToString();
    }

    private void SaveData(int level)
    {
        _reward += _dataSaver.GetMoney();
        _dataSaver.SetMoney(_reward);
        _dataSaver.SetLevel(level);
    }
}
