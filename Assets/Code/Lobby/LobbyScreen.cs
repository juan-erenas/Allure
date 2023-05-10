using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScreen : Screen
{
    private PlayerProfile _CurrentPlayer;

    public override void OnEnter()
    {
        if(_CurrentPlayer == null)
        {
            _CurrentPlayer = Allure.Instance.LoadPlayerProfile();
        }
    }

    void Update()
    {
        if (!IsUpdate)
        {
            return;
        }

    }
}
