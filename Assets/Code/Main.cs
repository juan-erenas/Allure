using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private List<Screen> _Screens;

    private Screen _CurrentScreen, _PreviousScreen;

    private void Awake()
    {
        for(int i = 0; i < _Screens.Count; i++)
        {
            _Screens[i].OnTransitionReady += HandelTransition;
        }

        _CurrentScreen = _Screens[0];
    }

    private void HandelTransition(Screen screen)
    {
        _PreviousScreen = _CurrentScreen;

        if (screen is LobbyScreen)
        {
            _CurrentScreen = _Screens[1];
        }
        else if (screen is GameScreen)
        {
            _CurrentScreen = _Screens[0];
        }

        _PreviousScreen.IsUpdate = false;
        _CurrentScreen.IsUpdate = true;
    }
}
