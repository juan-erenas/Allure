using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
{
    [SerializeField] List<Enemy> _enemiesToSpawn;

    public Enemy SpawnEnemy()
    {
        return _enemiesToSpawn[ Random.Range(0, _enemiesToSpawn.Count) ];
    }



}
