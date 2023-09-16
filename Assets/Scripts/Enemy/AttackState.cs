using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Tower target)
    {
        target.ApplyDamage(_damage);
    }
}
