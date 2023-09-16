using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MultishotTurret : Weapon
{
    [SerializeField] private int _bulletsNumber;

    private Transform[] _targets;

    protected override void Update()
    {
        base.Update();

        FindTargets();

        if (_currentCooldown <= 0 && _targets != null)
        {
            Shoot();
        }
    }

    private void FindTargets()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, Range, (Vector2)transform.position, 0f, EnemyMask);

        if (hits.Length > 0)
        {
            _targets = new Transform[_bulletsNumber];

            for (int i = 0; i < hits.Length && i < _targets.Length; i++)
            {
                _targets[i] = hits[i].transform;
            }
        }
        else
        {
            _targets = null;
        }
    }

    private void Shoot()
    {
        _currentCooldown = CooldownDuration;

        for (int i = 0; i < _targets.Length && _targets[i] != null; i++)
        {
            Vector3 direction = (_targets[i].position - transform.position).normalized;
            Projectile bullet = Instantiate((Projectile)Bullet, transform.position, Quaternion.identity);
            bullet.Launch(direction);
        }
    }
}
