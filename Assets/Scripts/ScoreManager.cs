using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public ScoreManager()
    {

    }

    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public void AddToScore(int amountEarned)
    {
        _score += amountEarned;
    }

}
