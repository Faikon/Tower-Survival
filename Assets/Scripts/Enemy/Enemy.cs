using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;
    [SerializeField] private GameObject _deathParticle;

    private Tower _target;
    private float _deathParticleLifetime = 2f;

    public int Reward => _reward;
    public Tower Target => _target;

    public event UnityAction<Enemy> Dying;

    public void Init(Tower target)
    {
        _target = target;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);

            var deathParticle = Instantiate(_deathParticle, transform.position, transform.rotation);
            Destroy(deathParticle, _deathParticleLifetime);
        }
    }
}
