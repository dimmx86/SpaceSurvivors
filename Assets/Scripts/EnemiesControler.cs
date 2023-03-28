using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControler : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;


    private Transform _target;

    private HashSet<Enemy> _activeEnemies;

    private void Start()
    {
        _target = _gameManager.Player.transform;
        _activeEnemies = new HashSet<Enemy>();
        var enemies = transform.GetComponentsInChildren<Enemy>();
        print(enemies.Length);
        foreach (var item in enemies)
        {
            item.SetTarget(_target);
            _activeEnemies.Add(item);
        }
    }
}
