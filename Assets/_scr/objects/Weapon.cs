using UnityEngine;
using DG.Tweening;

// weapon base class
public class Weapon:MonoBehaviour
{
    protected string _name;                  // name of the weapon, natch
    protected GameObject _pickupPrefab;      // obj displayed in-world as a pickup
    protected GameObject _displayPrefab;     // obj displayed in hands of player
    protected GameObject _projectile;        // projectile fired from projectile weapons, fx drawn for hitscan weapons
    protected float _chargeTime;             // charging time before weapon actually fires
    protected float _fireTime;               // time spent firing
    protected float _cooldownTime;           // cooldown before next firing cycle can begin
    protected Sequence _chargeTween;         // played when charging
    protected Sequence _fireTween;           // played when firing
    protected Sequence _cooldownTween;       // played when cooldowning
    protected Sequence _changeOutTween;      // played when changing FROM this weapon
    protected Sequence _changeInTween;       // played when changing TO this weapon
    protected string _ammunition;            // which type of ammo the weapon uses
    protected uint _ammoPerShot;             // how many items of ammo the weapon needs in order to fire
    protected bool _active;                  // whether to respond to input or not
    protected Transform _shotOrigin;         // the point on the model where shots originate
    protected GameObject _displayObject;     // instance of display mesh
    protected Transform _displayTransform;   // transform of display mesh
    public Transform displayTransform
    {
        get
        {
            return _displayTransform;
        }
    }

    private void Awake()
    {
        _chargeTween = DOTween.Sequence();
        _fireTween = DOTween.Sequence();
        _cooldownTween = DOTween.Sequence();
        _changeOutTween = DOTween.Sequence();
        _changeInTween = DOTween.Sequence();
    }

    public virtual void Fire()
    {
        Debug.Log(_name + " fired");
    }

    protected virtual void SetDisplayModel()
    {
        // load and then hide display model
        if (_displayPrefab)
        {
            _displayObject = Instantiate(_displayPrefab, transform.position, transform.rotation);
            _displayTransform = _displayObject.GetComponent<Transform>();
            _shotOrigin = _displayTransform.Find("shotorigin").transform;
            SwitchOut();
        }
        else
            Debug.Log("ERROR: failed to load display model of weapon " + _name + "\nobj: " + gameObject.name);
    }

    public virtual void SwitchOut()
    {
        _active = false;
        _displayObject.SetActive(false);
    }

    public virtual void SwitchIn()
    {
        _active = true;
        _displayObject.SetActive(true);
    }
}