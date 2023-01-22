using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private ScoreManager _scoreManageer;
    private Diamond _diamond;

    [SerializeField] Camera _camera;

    void Start()
    {
        _scoreManageer = new ScoreManager();
        InitDiamond();
        InitEnemySpawner(_diamond.gameObject.transform.position);
    }

    private void InitDiamond()
    {
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.transform.parent = transform;
        gameObject.name = "Diamond";
        _diamond = gameObject.AddComponent<Diamond>();
        

        _diamond.OnDeath += EndGame;

        gameObject.transform.position = _camera.transform.position + _camera.transform.forward * 3;
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    private void InitEnemySpawner(Vector3 target)
    {
        var gameObject = new GameObject("EnemySpawner");
        _enemySpawner = gameObject.AddComponent<EnemySpawner>();
        _enemySpawner.OnEnemyDestroyed += EnemyHasBeenDestroyed;
        gameObject.transform.parent = transform;

        var spawnPositions = new SpawnPointFactory().Build(_diamond.transform.position, _camera.transform.position, 10, 20);

        _enemySpawner.BeginSpawningEnemies(target, 2f, 3f, spawnPositions);
    }

    private void EnemyHasBeenDestroyed(int killWorth)
    {
        _scoreManageer.AddToScore(killWorth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndGame()
    {

    }





}
