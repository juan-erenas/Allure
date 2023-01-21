using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public event Action<int> OnDestroy;
    public event Action<Enemy> OnRelease;

    protected EnemyMovement? _movement;
    protected int _killWinAmount = 0;

    private void Awake()
    {
        SetKillAmount();
        SetObjectName();
    }

    private void SetObjectName()
    {
        name = "Enemy"; //used in collisions
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_movement != null)
        {
            transform.position = _movement!.UpdatePosition();
        }
    }

    protected virtual void SetKillAmount()
    {
        _killWinAmount = 1;
    }

    protected virtual void Die()
    {
        OnDestroy?.Invoke(_killWinAmount);
        OnRelease?.Invoke(this);
    }

    public virtual void BeginMovingTowards(Vector3 targetPos, float speed)
    {
        _movement = new EnemyMovement(targetPos, transform.position, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Weapon" || collision.gameObject.name == "Diamond")
        {
            Die();
        }
    }

}
