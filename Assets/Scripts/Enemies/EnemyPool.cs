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
        var enemyGameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemyGameObject.name = "Enemy";

        var enemy = enemyGameObject.AddComponent<T>();

        enemy.OnRelease += ReleaseEnemy;

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
        Object.Destroy(enemy.gameObject);
    }

    private void ReleaseEnemy(Enemy enemy)
    {
        _enemyPool.Release((T)enemy);
    }
}
