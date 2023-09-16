using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class CurrentFromMaxValue : MonoBehaviour
{
    [SerializeField] protected TMP_Text CurrentFromMaxValueText;

    public void OnValueChanged(float value, float maxValue)
    {
        CurrentFromMaxValueText.text = value + " / " + maxValue;
    }
}
