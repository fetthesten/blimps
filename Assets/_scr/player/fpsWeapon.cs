using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsWeapon : MonoBehaviour 
{
    private Transform _cameraTransform;
    private Weapon[] _weapons;
    private uint _currentWeapon;
    private Vector3 _prevWeaponPos;
    private Quaternion _prevWeaponRot;

	void Start () 
	{
        _cameraTransform = gameObject.GetComponentInChildren<Camera>().transform;
        _currentWeapon = 0;
        SetUpWeapons();
        _prevWeaponPos = transform.position;
        _prevWeaponRot = transform.rotation;

        _weapons[0].SwitchIn();
    }
	
	void Update () 
	{
        // weapon switch
        // todo: make this suck less ass

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchWeapon(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchWeapon(1);

        var w = CurrentWeapon();
        w.displayTransform.position = Vector3.Lerp(_prevWeaponPos, _cameraTransform.position, .5f);
        w.displayTransform.rotation = Quaternion.Lerp(_prevWeaponRot, _cameraTransform.rotation, .5f);
        _prevWeaponPos = w.displayTransform.position;
        _prevWeaponRot = w.displayTransform.rotation;
        if (Input.GetButton("Fire1"))
            w.Fire();

	}

    Weapon CurrentWeapon()
    {
        return _weapons[_currentWeapon];
    }

    void SwitchWeapon(uint newWeapon)
    {
        _weapons[_currentWeapon].SwitchOut();
        _weapons[newWeapon].SwitchIn();
        _currentWeapon = newWeapon;
    }

    void SetUpWeapons()
    {
        _weapons = gameObject.GetComponents<Weapon>();

    }
}
