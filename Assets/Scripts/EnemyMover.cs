using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //[SerializeField] 
    private float _speed = 1;
    [SerializeField]
    private float _maxRadiansDelta = 1;
    [SerializeField]
    private float _maxMagnitudeDelta = 1;

    private Transform _target;
    private Transform _rootTransform;
    private Vector3 _directionMove = Vector3.zero;

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
            //_directionMove = _target.position - _rootTransform.position;
            //_directionMove.z = 0;
            //_directionMove = Vector3.RotateTowards(_directionMove, _target.position, _maxRadiansDelta, _maxMagnitudeDelta);
            _directionMove = _target.position - _rootTransform.position;

            _rootTransform.rotation = Quaternion.LookRotation(_directionMove + _target.position);
            //_rootTransform.position = Vector3.Lerp(_target.position, _rootTransform.position, _speed * Time.deltaTime);
            //if (_directionMove != Vector3.zero)
            //{
            //    var vTemp = _rootTransform.position;
            //    vTemp.z = 0;
            //    _rootTransform.position = vTemp;
            //    _rootTransform.position = _directionMove.normalized * _speed * Time.deltaTime;                
            //}
        }
    }
}
