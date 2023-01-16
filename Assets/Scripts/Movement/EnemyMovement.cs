using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement
{
    protected Vector3 _targetPos;
    protected Vector3 _currentPos;
    protected float _speed;
    public EnemyMovement(Vector3 targetPos, Vector3 currentPos, float speed)
    {
        _targetPos = targetPos;
        _currentPos = currentPos;
        _speed = speed;
    }
    public virtual Vector3 UpdatePosition()
    {
        var step = _speed * Time.deltaTime;
        Vector3 newPos = Vector3.MoveTowards(_currentPos, _targetPos, step);
        _currentPos = newPos;

        return _currentPos;
    }

    public void UpdateSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }


}
