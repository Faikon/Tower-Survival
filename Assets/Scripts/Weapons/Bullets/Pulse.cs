using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pulse : Bullet
{
    [SerializeField] private float _expandTime;
    [SerializeField] private float _expandSpeed;

    private SpriteRenderer _spriteRenderer;
    private Color _color;
    private float _expandMaxTime;
    private float _rotationSpeed = 2;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;
        _expandMaxTime = _expandTime;
    }

    private void Update()
    {
        transform.localScale += new Vector3(_expandSpeed, _expandSpeed, 0);
        transform.Rotate(0, 0, _rotationSpeed);
        
        _expandTime -= Time.deltaTime;
        ChangeAlpha();

        if (_expandTime <= 0)
            Destroy(gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
        }
    }

    private void ChangeAlpha()
    {
        _color.a = _expandTime / _expandMaxTime;
        _spriteRenderer.color = _color;
    }
}
