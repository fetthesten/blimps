using UnityEngine;

public class Pistol : Weapon
{
    public GameObject pickupPrefab;
    public GameObject displayPrefab;

    private void Start()
    {
        _name = "Pistol";
        _pickupPrefab = pickupPrefab;
        _displayPrefab = displayPrefab;
        _cameraTransform = gameObject.GetComponentInChildren<Camera>().GetComponent<Transform>();

        if (_displayPrefab)
        {
            var d = Instantiate(_displayPrefab, transform.position, _cameraTransform.rotation);
            _displayTransform = d.GetComponent<Transform>();
        }
    }

    private void Update()
    {
        _displayTransform.position = _cameraTransform.position;
        _displayTransform.rotation = _cameraTransform.rotation;
    }

    public override void Fire()
    {
        base.Fire();

    }
}