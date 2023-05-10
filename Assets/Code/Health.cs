using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public event Action OnHealthReachZero;

    private int _currentHealth;
    private int _maxHealth;

    public Health(int totalHealth)
    {
        _currentHealth = totalHealth;
        _maxHealth = totalHealth;
    }

    public void DecreaseHealth()
    {
        Debug.Log("Health was decreased!");
        _currentHealth -= 1;
        if (_currentHealth == 0)
        {
            _currentHealth = 0;

            OnHealthReachZero?.Invoke();
        }
    }
    public void IncreaseHealth(int amountToIncrease)
    {
        _currentHealth += amountToIncrease;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

}
