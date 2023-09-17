using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : Weapon
{
    private Transform _target;

    protected override void Update()
    {
        base.Update();

        if (_target == null)
        {
            FindTarget();
            return;
        }

        if (CurrentCooldown <= 0)
        {
            Shoot();
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, Range, (Vector2)transform.position, 0f, EnemyMask);

        if (hits.Length > 0)
        {
            int targetIndex = Random.Range(0, hits.Length);
            _target = hits[targetIndex].transform;
        }
    }

    private void Shoot()
    {
        CurrentCooldown = CooldownDuration;

        Vector3 direction = (_target.position - transform.position).normalized;
        Projectile bullet = Instantiate((Projectile)Bullet, transform.position, Quaternion.identity);
        bullet.Launch(direction);
    }
}
