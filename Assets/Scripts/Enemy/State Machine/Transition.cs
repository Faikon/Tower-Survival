using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Tower Target { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    public void Init(Tower target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
