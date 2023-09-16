using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;

    [SerializeField] protected float Range;
    [SerializeField] protected LayerMask EnemyMask;
    [SerializeField] protected float CooldownDuration;
    [SerializeField] protected Bullet Bullet;

    protected float _currentCooldown;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;

    protected virtual void Start()
    {
        _currentCooldown = CooldownDuration;
    }

    protected virtual void Update()
    {
        _currentCooldown -= Time.deltaTime;
    }
}
