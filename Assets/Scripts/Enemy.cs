using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMovement? _movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement?.UpdatePosition();
    }

    public virtual void BeginMovingTowards(Vector3 targetPos, float speed)
    {
        _movement = new EnemyMovement(targetPos, transform.position, speed);
    }

}
