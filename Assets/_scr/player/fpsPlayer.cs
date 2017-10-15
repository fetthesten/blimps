using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class fpsPlayer : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float acceleration = 0.2f;
    public float deceleration = 0.3f;
    public float jumpSpeed = 8.0f;
    public float gravity = 18.2f;
    public float fallDamageThreshold = -20.0f;
    public bool invertMouse = true;
    public float lookSpeed = 1.5f;

    private CharacterController _characterController;
    private Camera _camera;
    private float _movementSpeed;
    private float _moveY;

	void Start ()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _camera = gameObject.GetComponentInChildren<Camera>();
        _movementSpeed = walkSpeed;
        _moveY = .0f;
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(new Vector2(.0f, .0f), new Vector2(32.0f, 32.0f)), _characterController.isGrounded.ToString());
    }

    void Update ()
    {
        // this only works properly for mouse look atm, controller aiming feels off
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Look X") * lookSpeed);
        _camera.transform.Rotate(Vector3.right * (invertMouse ? Input.GetAxisRaw("Look Y") : -Input.GetAxisRaw("Look Y")) * lookSpeed);

        Move();
	}

    void Move()
    {
        // smooth out movement speed based on whether or not the player wants to run
        float toSpeed = walkSpeed;
        float t = deceleration;
        if (Input.GetButton("Run"))
        {
            toSpeed = runSpeed;
            t = acceleration;
        }
        _movementSpeed = Mathf.Lerp(_movementSpeed, toSpeed, t);
        if (_characterController.isGrounded)
        {
            // check if player is falling too quickly before grounding them
            if (_moveY < fallDamageThreshold)
            {
                // todo: actually damage the player when that becomes an issue
                Debug.Log("damage! " + _moveY.ToString());
            }
            _moveY = .0f;
            // do a jump maybe
            if (Input.GetButtonDown("Jump"))
            {
                _moveY = jumpSpeed;
            }
        }
        // only apply movement speed to horizontal plane movements
        // todo: store movement vector when jumping/falling and reduce input strength when in-air
        var move = new Vector3(Input.GetAxisRaw("Move X"), .0f, Input.GetAxisRaw("Move Y")) * _movementSpeed;
        move = transform.rotation * move;
        // apply gravity separately
        _moveY -= gravity * Time.deltaTime;
        move.y = _moveY;
        _characterController.Move(move * Time.deltaTime);
        // if the player bumps their head, make them fall down instantly instead of waiting for the gravity delta to take them down
        if ((_characterController.collisionFlags & CollisionFlags.Above) != 0 && _moveY > .0f)
        {
            _moveY = -gravity * Time.deltaTime;
        }
    }
}
