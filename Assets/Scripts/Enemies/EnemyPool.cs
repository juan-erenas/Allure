using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool<T> : MonoBehaviour where T : Enemy
{

    private IObjectPool<T> _enemyPool;
    private int _capacity = 100;
    private int _maxSize = 10000;

    private void Start()
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
        enemy.OnDestroy += returnToPool.OnEnemyDestroyed;

        Instantiate(enemy, transform);

        return enemy;
    }

    private void OnTakeEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        
    }

    private void OnReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
