using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _tower.HealthChanged -= OnValueChanged;
    }
}
