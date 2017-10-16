using UnityEngine;

public class Pistol : Weapon
{

    private void Start()
    {
        _name = "Pistol";
        _pickupPrefab = null;
        _displayPrefab = Resources.Load("_pre/pistolTest", typeof(GameObject)) as GameObject;

        _cooldownTime = .3f;

        if (_displayPrefab)
        {
            var d = Instantiate(_displayPrefab, transform.position, transform.rotation);
            _displayTransform = d.GetComponent<Transform>();
            _shotOrigin = _displayTransform.Find("shotorigin").transform;
        }
    }

    public override void Fire()
    {
        //base.Fire();
        Debug.DrawRay(_shotOrigin.position, _shotOrigin.forward, Color.red, _cooldownTime);
    }
}