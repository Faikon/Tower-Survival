using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTimerBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.WaveTimer += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.WaveTimer -= OnValueChanged;
    }
}
