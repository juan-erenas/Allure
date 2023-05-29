using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaTimeActiveCallback : Updatable
{
    public bool _IsActive { get; set; }

    public void Update()
    {
        if (_IsActive)
        {
            ActivateWhenReady();
        }
    }

    public void SetActiveTime(float time)
    {
        _ActiveTime = time;
    }

    public void Start()
    {
        _IsActive = true;
        _CurrentActiveTime = _ActiveTime;
    }

    private float _ActiveTime, _CurrentActiveTime;
    private Action _Callback;
    public DeltaTimeActiveCallback(float activeTime, Action callback)
    {
        _ActiveTime = activeTime;
        _Callback = callback;
    }

    private void ActivateWhenReady()
    {
        if (_CurrentActiveTime >= 0)
        {
            _CurrentActiveTime -= Time.deltaTime;

            if (_CurrentActiveTime <= 0)
            {
                _IsActive = false;
                _Callback?.Invoke();
            }
        }
    }
}
