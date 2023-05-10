using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{
    public event Action<string> OnHit;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected virtual void TriggerPowerUp()
    {
        OnHit?.Invoke("PowerUp");
    }


}
