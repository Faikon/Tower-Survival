using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    public event UnityAction<float, float> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    [SerializeField] private float _maxHealth;
    [SerializeField] private LoseScreen _loseScreen;

    private float _currentHealth;    

    public float MaxHealth => _maxHealth;
    public int Money { get; private set; }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0 )
        {
            _loseScreen.gameObject.SetActive(true);
            Destroy(gameObject);         
            Time.timeScale = 0;
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        Instantiate(weapon, transform);
    }
}
