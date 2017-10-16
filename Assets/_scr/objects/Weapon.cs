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
    protected Tween _chargeTween;            // played when charging
    protected Tween _fireTween;              // played when firing
    protected Tween _cooldownTween;          // played when cooldowning
    protected Tween _changeOutTween;         // played when changing FROM this weapon
    protected Tween _changeInTween;          // played when changing TO this weapon
    protected string _ammunition;            // which type of ammo the weapon uses
    protected uint _ammoPerShot;             // how many items of ammo the weapon needs in order to fire
    protected Transform _displayTransform;   // transform of display mesh
    public Transform displayTransform
    {
        get
        {
            return _displayTransform;
        }
    }
    protected Transform _shotOrigin;         // the point on the model where shots originate
    protected bool _active; 

    public virtual void Fire()
    {
        Debug.Log(_name + " fired");
    }
}