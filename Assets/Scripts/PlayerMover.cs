using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _maxSpeed;
    [SerializeField][Range(0,1)] private float _maxSpeedTurn;

    private Joystick _joystick;
    private Rigidbody _player;

    private Vector3 _vectorMove = Vector3.zero;
    private Vector3 _vectorDirection;
    private Vector3 _vectorCompinsator = new Vector3(1, 1, 0);

    private void Start()
    {
        _joystick = _gameManager.Joystick;
        _player = _gameManager.Player.Rigidbody;
    }

    private void FixedUpdate()
    {

        _vectorDirection.x = _joystick.Horizontal * _maxSpeed;
        _vectorDirection.y = _joystick.Vertical * _maxSpeed;
        _vectorDirection.z = 0;
        _vectorMove = Vector3.Slerp(_vectorMove,_vectorDirection , Vector3.Distance(_vectorDirection, _vectorMove)/2*_maxSpeed*_maxSpeedTurn);
        _player.velocity = _vectorMove;

        if (_player.velocity != Vector3.zero)
        {
            float enl = Quaternion.LookRotation(_player.velocity).eulerAngles.x;
            _player.rotation = Quaternion.LookRotation(_player.velocity);
        }
    }
}
