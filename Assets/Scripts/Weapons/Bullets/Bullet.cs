using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float Damage;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Destroyer destroyer))
            Destroy(gameObject);
    }
}
