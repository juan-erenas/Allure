using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDestroy;

    protected EnemyMovement? _movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement?.UpdatePosition();
    }

    protected virtual void Die()
    {
        OnDestroy?.Invoke(this);
        GameObject.Destroy(this);
    }

    public virtual void BeginMovingTowards(Vector3 targetPos, float speed)
    {
        _movement = new EnemyMovement(targetPos, transform.position, speed);
    }

}
