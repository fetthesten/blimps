using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsWeapon : MonoBehaviour 
{
    private Transform _cameraTransform;
    private Weapon[] _weapons;
    private uint _currentWeapon;

	void Start () 
	{
        _cameraTransform = gameObject.GetComponentInChildren<Camera>().transform;
        _currentWeapon = 0;
        SetUpWeapons();
	}
	
	void Update () 
	{
        var w = CurrentWeapon();
        w.displayTransform.position = _cameraTransform.position;
        w.displayTransform.rotation = _cameraTransform.rotation;
        if (Input.GetButton("Fire1"))
            CurrentWeapon().Fire();
	}

    Weapon CurrentWeapon()
    {
        return _weapons[_currentWeapon];
    }

    void SetUpWeapons()
    {
        _weapons = gameObject.GetComponents<Weapon>();
        for (uint i = 0; i < _weapons.Length; ++i)
            _weapons[i].gameObject.SetActive(false);

        _weapons[0].gameObject.SetActive(true);
    }
}
