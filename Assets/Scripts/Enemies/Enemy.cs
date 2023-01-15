using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public event Action<int> OnDestroy;

    protected EnemyMovement? _movement;
    protected int _killWinAmount = 0;

    private void Awake()
    {
        SetKillAmount();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement?.UpdatePosition();
    }

    protected virtual void SetKillAmount()
    {
        _killWinAmount = 1;
    }

    protected virtual void Die()
    {
        OnDestroy?.Invoke(_killWinAmount);
        Destroy(this);
    }

    public virtual void BeginMovingTowards(Vector3 targetPos, float speed)
    {
        _movement = new EnemyMovement(targetPos, transform.position, speed);
    }

}
