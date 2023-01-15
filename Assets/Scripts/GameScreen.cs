using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    private EnemySpawner _enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        InitEnemySpawner();
    }

    private void InitEnemySpawner()
    {
        _enemySpawner = new EnemySpawner();
        _enemySpawner.OnEnemyDestroyed += EnemyHasBeenDestroyed;
    }

    private void EnemyHasBeenDestroyed()
    {
        //update the score 
    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
