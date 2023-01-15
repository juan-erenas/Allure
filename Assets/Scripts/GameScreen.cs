using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private ScoreManager _scoreManageer;
    private Diamond _diamond;

    // Start is called before the first frame update
    void Start()
    {
        InitEnemySpawner();
        InitDiamond();
    }

    private void InitDiamond()
    {
        _diamond = new Diamond();
        _diamond.OnDeath += EndGame;
    }

    private void EndGame()
    {
        
    }

    private void InitEnemySpawner()
    {
        _enemySpawner = new EnemySpawner();
        _enemySpawner.OnEnemyDestroyed += EnemyHasBeenDestroyed;
    }

    private void EnemyHasBeenDestroyed(int killWorth)
    {
        _scoreManageer.AddToScore(killWorth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
