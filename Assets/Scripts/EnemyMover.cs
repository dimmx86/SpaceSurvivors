using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _thisRB;
    [SerializeField]
    private float _maxSpeed = 1;
    [SerializeField]
    private float _maxSpeedTurn = 1;
    [SerializeField]
    private float _forceEng = 1;
    [SerializeField]
    private float _inertialDampers = 1;
    

    private Transform _target;
    private Transform _rootTransform;
    private Vector3 _directionMove = Vector3.zero;
    private Vector3 _curentForce = Vector3.zero;
    private Vector3 _force = Vector3.zero;

    public void SetTarget(Transform target, Transform transform)
    {
        _target = target;
        _rootTransform = transform;
        _directionMove = _target.position - _rootTransform.position;
        _directionMove.z = 0;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            _directionMove = _target.position - _rootTransform.position;
            _directionMove = _directionMove.normalized;
            //_rootTransform.rotation = Quaternion.LookRotation(_directionMove + _target.position);
            if (_directionMove != Vector3.zero)
            {
                _force = Vector3.Slerp(_force, _directionMove, _maxSpeedTurn);

                _thisRB.rotation = Quaternion.LookRotation(_force);

                _curentForce = Vector3.Slerp(_curentForce, _curentForce + _force * _forceEng, _maxSpeedTurn) * _inertialDampers;
                if (_curentForce.magnitude > _maxSpeed)
                {
                    _curentForce = _curentForce.normalized * _maxSpeed;
                }
                _thisRB.velocity = _curentForce;
            }
            else
            {
                _curentForce = _curentForce * _inertialDampers;
                _thisRB.velocity = _curentForce;
            }
        }
    }
}
