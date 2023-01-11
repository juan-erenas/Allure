using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMovement _movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement.UpdatePosition();
    }

    protected virtual void SetMovementScript()
    {
        _movement = new EnemyMovement();
    }

}
