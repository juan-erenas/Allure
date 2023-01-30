using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponFactory
{
    private Dictionary<WeaponType, GameObject> _weaponDict = new Dictionary<WeaponType, GameObject>();

    public WeaponFactory()
    {
        LoadAllWeapons();
    }

    public GameObject GetWeapon(WeaponType weaponType)
    {
        var gameObject = UnityEngine.Object.Instantiate(_weaponDict[weaponType]);
        gameObject.name = "Weapon";

        return gameObject;
    }

    private void LoadAllWeapons()
    {
        foreach (WeaponType type in Enum.GetValues(typeof(WeaponType)))
        {
            _weaponDict.Add(type, GetPrefab(type));
        }
    }

    private GameObject GetPrefab(WeaponType weaponType)
    {
        GameObject weaponGameObject = Resources.Load<GameObject>(weaponType.ToString());
        return weaponGameObject;

    }
}
