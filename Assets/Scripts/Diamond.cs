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

    public void AddHealthOfAmount(int amountToAdd)
    {
        _health.IncreaseHealth(amountToAdd);
    }

    public void DecreaseHealth()
    {
        _health.DecreaseHealth();
    }

    private void InitHealthAt(int maxHealth)
    {
        _health = new Health(maxHealth);
        _health.OnHealthReachZero += Die;
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            DecreaseHealth();
        }
    }

}
