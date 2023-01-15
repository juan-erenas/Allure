using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;

    void Start()
    {
        
    }

    void Update()
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
