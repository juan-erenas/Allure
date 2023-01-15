using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Diamond : MonoBehaviour
{
    public event Action OnDeath;

    private Health _health;
    void Start()
    {
        InitHealthAt(3);
    }


    void Update()
    {
        
    }

    private void InitHealthAt(int maxHealth)
    {
        _health = new Health(maxHealth);
        _health.OnHealthReachZero += Die;
    }

    private void Die()
    {
        OnDeath?.Invoke();
        GameObject.Destroy(this);
    }

}
