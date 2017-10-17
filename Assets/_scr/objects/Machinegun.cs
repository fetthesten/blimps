using UnityEngine;
using DG.Tweening;

public class Machinegun : Weapon
{

    private void Awake()
    {
        _name = "Machinegun";
        _pickupPrefab = null;
        _displayPrefab = Resources.Load("_pre/machinegunTest", typeof(GameObject)) as GameObject;

        _cooldownTime = .1f;

        SetDisplayModel();
    }

    public override void Fire()
    {
        //base.Fire();
        if (_active)
            Debug.DrawRay(_shotOrigin.position, _shotOrigin.forward, Color.red, _cooldownTime);
    }
}