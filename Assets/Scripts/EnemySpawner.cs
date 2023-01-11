using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    

    [SerializeField] List<Enemy> _enemiesToSpawn;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Enemy newEnemy = _enemiesToSpawn[ Random.Range(0, _enemiesToSpawn.Count) ];
        Instantiate(newEnemy, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
    }



}
