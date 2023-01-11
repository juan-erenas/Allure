using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemiesToSpawn;

    private bool _isSpawningEnemies = false;
    private Vector3 _target;
    private float _enemySpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        
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
        Enemy newEnemy = _enemiesToSpawn[ Random.Range(0, _enemiesToSpawn.Count) ];

        Instantiate(newEnemy, GetEnemySpawnPos(newEnemy), Quaternion.identity);

        newEnemy.BeginMovingTowards(_target, _enemySpeed);
    }

    private Vector3 GetEnemySpawnPos(Enemy enemy)
    {
        return new Vector3(0, 0, 0);
    }




}
