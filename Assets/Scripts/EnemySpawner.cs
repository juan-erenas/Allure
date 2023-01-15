using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public event Action<int> OnEnemyDestroyed;

    [SerializeField] private List<Enemy> _enemiesToSpawn;

    private bool _isSpawningEnemies = false;
    private Vector3 _target;
    private float _enemySpeed;

    private void Start()
    {
        _enemiesToSpawn = InitEnemies();
        AssignEnemies();
    }

    private void Update()
    {
        
    }

    private List<Enemy> InitEnemies()
    {
        List<Enemy> enemies = new List<Enemy>();

        enemies.Add(new Enemy());
        enemies.Add(new Enemy());

        return enemies;
    }

    private void AssignEnemies()
    {
        for (int i = 0; i < _enemiesToSpawn.Count; i ++)
        {
            _enemiesToSpawn[i].OnDestroy += EnemyHasBeenDestroyed;
        }
    }

    private void EnemyHasBeenDestroyed(int killWorth)
    {
        OnEnemyDestroyed?.Invoke(killWorth);
    }

    public void BeginSpawningEnemies(Vector3 target, float speed)
    {
        _target = target;
        _enemySpeed = speed;
        _isSpawningEnemies = true;
    }

    public void StopSpawning()
    {
        _isSpawningEnemies = false;
    }

    public void SpawnEnemy()
    {
        Enemy newEnemy = _enemiesToSpawn[ UnityEngine.Random.Range(0, _enemiesToSpawn.Count) ];

        Instantiate(newEnemy, GetEnemySpawnPos(newEnemy), Quaternion.identity);

        newEnemy.BeginMovingTowards(_target, _enemySpeed);
    }

    private Vector3 GetEnemySpawnPos(Enemy enemy)
    {
        return new Vector3(0, 0, 0);
    }




}
