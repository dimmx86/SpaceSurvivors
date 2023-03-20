using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Transform _defultTarget;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minSize = 10;
    [SerializeField] private float _maxSize = 50;
    

    private Transform _transform;
    private Transform _target;
    private Transform _camTransform;
    private Vector3 _targetPosition;
    private Camera _camera;
    private float _deltaSize;

    private void Start()
    {
        _transform = this.transform;
        _target = _defultTarget;
        _camTransform = this.transform;
        _camera = Camera.main;
        _deltaSize = _maxSize - _minSize;
    }

    private void LateUpdate()
    {
        _targetPosition = _target.position;
        _targetPosition.z = _transform.position.z;
        float distance = Vector3.Distance(_targetPosition, _camTransform.position);
        float ratioDistance = distance / _maxDistance;
        _camTransform.position = Vector3.Slerp(_camTransform.position, _targetPosition, ratioDistance * Time.deltaTime);
        _camera.orthographicSize = _minSize + _deltaSize * ratioDistance;
    }
}
