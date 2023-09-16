using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Bullet
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Launch(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _speed);
    }
}
