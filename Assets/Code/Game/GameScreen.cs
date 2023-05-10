using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameScreen : Screen
{
    private WeaponFactory _weaponFactory;
    private EnemySpawner _enemySpawner;
    private ScoreManager _scoreManageer;

    private Weapon _weapon;
    private Diamond _diamond;
    private ScoreDisplay _scoreDisplay;

    [SerializeField] Camera _camera;

    void Start()
    {
        _scoreManageer = new ScoreManager();
        InitWeaponFactory();
        InitDiamond();
        InitEnemySpawner();
        InitScore();
        InitWeapon();
    }

    private void InitWeaponFactory()
    {
        _weaponFactory = new WeaponFactory();
    }

    private void InitWeapon()
    {
        var selectedWeaponType = WeaponType.Axe; //TO DO: pass in later

        var gameObject =  _weaponFactory.GetWeapon(selectedWeaponType);
        gameObject.transform.parent = transform;

        _weapon = gameObject.GetComponent<Weapon>();
        var grabInteractable = gameObject.GetComponent<XRGrabInteractable>();

        grabInteractable.firstSelectEntered.AddListener(BeginGame);
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
        gameObject.SetActive(false);
    }

    private void BeginGame(SelectEnterEventArgs args)
    {
        MakeDiamondAppear();
        BeginSpawningEnemies(_diamond.gameObject.transform.position);
    }

    private void InitScore()
    {
        var gameObject = new GameObject("ScoreDisplay");
        gameObject.transform.parent = transform;
        _scoreDisplay = gameObject.AddComponent<ScoreDisplay>();
        _scoreDisplay.transform.position = _camera.transform.position + (_camera.transform.forward * 30);
    }

    private void InitEnemySpawner()
    {
        var gameObject = new GameObject("EnemySpawner");
        _enemySpawner = gameObject.AddComponent<EnemySpawner>();
        _enemySpawner.OnEnemyDestroyed += EnemyHasBeenDestroyed;
        gameObject.transform.parent = transform;
    }

    private void BeginSpawningEnemies(Vector3 target)
    {
        var spawnPositions = new SpawnPointFactory().Build(_diamond.transform.position, _camera.transform.position, 10, 20);

        _enemySpawner.BeginSpawningEnemies(target, 2f, 2000f, spawnPositions);
    }

    private void MakeDiamondAppear()
    {
        _diamond.gameObject.SetActive(true);
    }

    private void EnemyHasBeenDestroyed(int killWorth)
    {
        _scoreManageer.AddToScore(killWorth);
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsUpdate)
        {
            return;
        }
        
    }

    private void EndGame()
    {

    }





}
