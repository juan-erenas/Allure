using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScreen : Screen
{
    private PlayerProfile _CurrentPlayer;
    private MatchConfigController _MatchConfigControler;
    public override event Action<Screen> OnTransitionReady;

    [SerializeField]
    private MatchConfigView _MatchConfigView;

    public override void OnEnter()
    {
        base.OnEnter();

        if(_CurrentPlayer == null)
        {
            _CurrentPlayer = Allure.Instance.LoadPlayerProfile();
        }

        if(_MatchConfigControler == null)
        {
            _MatchConfigControler = new MatchConfigController(_MatchConfigView);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    void Update()
    {
        if (!IsUpdate)
        {
            return;
        }
    }
}
