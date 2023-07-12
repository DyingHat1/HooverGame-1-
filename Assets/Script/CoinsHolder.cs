using System;
using UnityEngine;
using TMPro;

public class CoinsHolder : MonoBehaviour
{
    [SerializeField] private DataSaver _dataSaver;
    [SerializeField] private TMP_Text _moneyView;

    private int _value = 0;

    private void Start()
    {
        ReloadCoinsView();
    }

    public void ReloadCoinsView()
    {
        _value = _dataSaver.GetMoney();
        _moneyView.text = _value.ToString();
    }
}
