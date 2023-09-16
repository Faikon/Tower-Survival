using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentFromMaxHealth : CurrentFromMaxValue
{
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.HealthChanged += OnValueChanged;
        CurrentFromMaxValueText.text = _tower.MaxHealth.ToString() + " / " + _tower.MaxHealth.ToString();
    }

    private void OnDisable()
    {
        _tower.HealthChanged -= OnValueChanged;
    }
}
