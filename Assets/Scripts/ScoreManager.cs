using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private int _score = 0;
    public ScoreManager()
    {

    }

    public int GetScore()
    {
        return _score;
    }

    public void AddToScore(int amountEarned)
    {
        _score += amountEarned;
    }

}
