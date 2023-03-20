using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Rigidbody _rigidbody;

    public PlayerMover Mover => _mover;
    public Rigidbody Rigidbody => _rigidbody;

}
