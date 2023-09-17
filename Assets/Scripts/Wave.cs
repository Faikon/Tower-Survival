using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _duration;
    [SerializeField] private int _count;

    public Enemy Enemy => _enemy;
    public float Duration => _duration;
    public int Count => _count;
}
