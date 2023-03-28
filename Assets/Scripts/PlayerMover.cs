using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _maxSpeed;
    [SerializeField][Range(0,1)] private float _maxSpeedTurn;
    [SerializeField][Range(0,1)] private float _inertialDampers;
    [SerializeField] private float _forceEng;

    private Joystick _joystick;
    private Rigidbody _player;

    [SerializeField]
    private Vector3 _vectorCompinsator = new Vector3(1, 1, 0);

    private Vector3 _curentForce = Vector3.zero;
    private Vector3 _force = Vector3.zero;
    private Vector3 _direction = Vector3.zero;

    private void Start()
    {
        _joystick = _gameManager.Joystick;
        _player = _gameManager.Player.Rigidbody;
    }

    private void FixedUpdate()
    {

        _direction.x = _joystick.Horizontal;
        _direction.y = _joystick.Vertical;
        _direction.z = 0;

        if (_direction != Vector3.zero)
        {
            _force = Vector3.Slerp(_force, _direction, _maxSpeedTurn);
           
            _player.rotation = Quaternion.LookRotation(_force, _vectorCompinsator);

            _curentForce = Vector3.Slerp(_curentForce, _curentForce + _force * _forceEng, _maxSpeedTurn) * _inertialDampers;
            if (_curentForce.magnitude > _maxSpeed)
            {
                _curentForce = _curentForce.normalized * _maxSpeed;
            }
            _player.velocity = _curentForce;
        }
        else
        {
            _curentForce = _curentForce * _inertialDampers;
            _player.velocity = _curentForce;
        }
    }
}
