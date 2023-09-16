using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;

    private Weapon _weapon;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = _weapon.Label;
        _price.text = _weapon.Price.ToString();
        _icon.sprite = _weapon.Icon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}
