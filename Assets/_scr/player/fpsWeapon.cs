using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsWeapon : MonoBehaviour 
{
    public float cooldown = .3f;

    private Camera _camera;
    private float _nextShot;
    private Weapon _currentWeapon;

	void Start () 
	{
        _camera = gameObject.GetComponentInChildren<Camera>();
        _nextShot = Time.fixedTime;
        _currentWeapon = gameObject.GetComponent<Weapon>();
	}
	
	void Update () 
	{
        if (Input.GetButton("Fire1"))
            _currentWeapon.Fire();
	}

    void Fire()
    {
        if (Time.fixedTime >= _nextShot)
        {
            //Debug.DrawRay(transform.position + Vector3.up, _camera.transform.forward, Color.red, cooldown);

            _nextShot = Time.fixedTime + cooldown;
        }
    }
}
