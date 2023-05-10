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

    private Vector3 _target;
    private float _enemySpeed;
    private Timer _spawnTimer = new Timer();
    private float _spawnRate = 0f;
    private Dictionary<PointType, List<Vector3>> _spawnPositions;

    private System.Random RNG = new System.Random();

    private void Start()
    {
        InitEnemyProbabilities();
        _spawnTimer.OnTimerComplete += SpawnEnemy;
    }

    private void Update()
    {
        _spawnTimer.Update();
    }

    private void SpawnEnemy()
    {
        EnemyType type = SelectEnemyToSpawn();
        Enemy selectedEnemy = GetEnemyOfType(type);
        selectedEnemy.transform.position = GetSpawnPosition();
        selectedEnemy.OnDestroy += EnemyHasBeenDestroyed;

        selectedEnemy.BeginMovingTowards(_target, _enemySpeed);

        _spawnTimer.Start(_spawnRate);
    }

    private Vector3 GetSpawnPosition()
    {
        PointType[] values = (PointType[])Enum.GetValues(typeof(PointType));
        var randPointType = values[RNG.Next(values.Length)];

        var positions = _spawnPositions[randPointType];
        return positions[RNG.Next(positions.Count)];
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

    public void BeginSpawningEnemies(Vector3 target, float speed, float spawnRate, Dictionary<PointType, List<Vector3>> spawnPos)
    {
        _target = target;
        _enemySpeed = speed;
        _spawnRate = spawnRate;
        _spawnPositions = spawnPos;

        _spawnTimer.Start(_spawnRate);
    }

    public void StopSpawning()
    {
        _spawnTimer.Stop();
    }




}
