using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool<T> : MonoBehaviour where T : Enemy
{
    public T Enemy;
    public IObjectPool<T> pool;

    void Start()
    {
        Enemy = GetComponent<T>();
    }

    void OnParticleSystemStopped()
    {
        // Return to the pool
        pool.Release(Enemy);
    }
}
