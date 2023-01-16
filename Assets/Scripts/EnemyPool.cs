using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool<T> where T : Enemy
{

    private IObjectPool<T> _enemyPool;
    private int _capacity = 100;
    private int _maxSize = 10000;

    public EnemyPool()
    {
        BuildPool();
    }

    public T Get()
    {
        return _enemyPool.Get();
    }

    private void BuildPool()
    {
        _enemyPool = new ObjectPool<T>(CreateEnemy, OnTakeEnemy, OnReleaseEnemy, OnDestroyEnemy, true, _capacity, _maxSize);
    }
    private T CreateEnemy()
    {
        var enemyGameObject = new GameObject("Enemy");
        var enemy = enemyGameObject.AddComponent<T>();
        var returnToPool = enemyGameObject.AddComponent<ReturnToPool<T>>();
        returnToPool.pool = _enemyPool;

        return enemy;
    }

    private void OnTakeEnemy(Enemy enemy)
    {

    }

    private void OnReleaseEnemy(Enemy enemy)
    {

    }

    private void OnDestroyEnemy(Enemy enemy)
    {

    }
}
