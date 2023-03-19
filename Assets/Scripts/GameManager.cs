using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Player _player;

    public Joystick Joystick => _joystick;
    public Player Player => _player;
}
