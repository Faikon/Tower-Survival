using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _money.text = _tower.Money.ToString();
        _tower.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _tower.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
