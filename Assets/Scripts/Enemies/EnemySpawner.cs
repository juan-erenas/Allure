using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public event Action<int> OnEnemyDestroyed;

    private EnemyPool<Enemy> _enemyPool = new EnemyPool<Enemy>();


    private Dictionary<EnemyType, int> _enemyProbability;
    private int _totalProbability = 0;

    private bool _isSpawningEnemies = false;
    private Vector3 _target;
    private float _enemySpeed;

    private System.Random RNG = new System.Random();

    private void Start()
    {
        InitEnemyProbabilities();
        SpawnEnemy();
    }

    private void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        EnemyType type = SelectEnemyToSpawn();
        Enemy selectedEnemy = GetEnemyOfType(type);
        selectedEnemy.transform.position = GetSpawnPosition();

        selectedEnemy.BeginMovingTowards(_target, _enemySpeed);
    }

    private Vector3 GetSpawnPosition()
    {
        return new Vector3(0, 19, 3);
    }

    private Enemy GetEnemyOfType(EnemyType type)
    {
        return type switch
        {
            EnemyType.Normal => _enemyPool.Get(),
            _ => throw new Exception("Enemy type of type " + type.ToString() + " not accounted for.")
        };
    }

    private EnemyType SelectEnemyToSpawn()
    {
        int randNum = RNG.Next(_totalProbability + 1);

        int currentSum = 0;
        foreach (KeyValuePair<EnemyType, int> entry in _enemyProbability)
        {
            currentSum += _enemyProbability[entry.Key];
            if (currentSum >= randNum)
            {
                return entry.Key;
            }
        }

        throw new Exception("Total probability is larger than sum of enemy probability dict entries.");
    }

    private void InitEnemyProbabilities()
    {
        _enemyProbability = new Dictionary<EnemyType, int>();
        _enemyProbability.Add(EnemyType.Normal, 100);


        _totalProbability = _enemyProbability.Select(x => x.Value).Sum();
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

    private Vector3 GetEnemySpawnPos(Enemy enemy)
    {
        return new Vector3(0, 0, 0);
    }




}
