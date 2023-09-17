using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseTower : Weapon
{
    protected override void Update()
    {
        base.Update();

        if (CurrentCooldown <= 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            CurrentCooldown = CooldownDuration;
        }
    }
}
