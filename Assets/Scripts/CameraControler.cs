using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Transform _defultTarget;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;
    

    private Transform _transform;
    private Transform _target;
    private Transform _camTransform;
    private Vector3 _targetPosition;

    private void Start()
    {
        _transform = this.transform;
        _target = _defultTarget;
        _camTransform = this.transform;
    }

    private void LateUpdate()
    {
        _targetPosition = _target.position;
        _targetPosition.z = _transform.position.z;
        float distance = Vector3.Distance(_targetPosition, _camTransform.position);
        _camTransform.position = Vector3.Lerp(_camTransform.position, _targetPosition, distance/_maxDistance);
    }
}
