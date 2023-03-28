using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;
    private Transform _target;

    public void SetTarget(Transform target)
    {
        _mover.SetTarget(target, transform);
        _target = target;
    }
}
