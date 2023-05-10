using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darter : Enemy
{

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public override void BeginMovingTowards(Vector3 targetPos, float speed)
    {
        _movement = new EnemyMovement(targetPos, transform.position, speed);
    }
}
