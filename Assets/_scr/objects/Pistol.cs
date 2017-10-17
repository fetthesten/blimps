﻿using UnityEngine;
using DG.Tweening;

public class Pistol : Weapon
{

    private void Awake()
    {
        _name = "Pistol";
        _pickupPrefab = null;
        _displayPrefab = Resources.Load("_pre/pistolTest", typeof(GameObject)) as GameObject;

        _cooldownTime = .3f;

        SetDisplayModel();

        _changeInTween.Append(_displayTransform.DOLocalMove(new Vector3(1.0f, -1.0f, .0f), .5f))
            .Insert(.0f, _displayTransform.DOLocalRotate(new Vector3(45.0f, .0f, .0f), .5f));
    }

    public override void Fire()
    {
        //base.Fire();
        if (_active)
            Debug.DrawRay(_shotOrigin.position, _shotOrigin.forward, Color.red, _cooldownTime);
    }
}