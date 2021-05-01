using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private enum State {Idle, Running, Jumping, Falling}
    private State _state = State.Idle;
    private Collider2D _collider2D;
    [SerializeField] private LayerMask _ground;
    private AudioSource[] _jumpSound;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _jumpSound = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard keyboard = InputSystem.GetDevice<Keyboard>();
        
        if (keyboard.spaceKey.wasPressedThisFrame && (_state != State.Jumping) && (_state != State.Falling))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 9f);
            _state = State.Jumping;
        }
        else if (keyboard.rightArrowKey.isPressed)
        {
            _rigidbody.velocity = new Vector2(4, _rigidbody.velocity.y);
            //transform.localScale = new Vector2(1, 1);
        }
        else if (keyboard.leftArrowKey.isPressed)
        {
            _rigidbody.velocity = new Vector2(-4, _rigidbody.velocity.y);
            //transform.localScale = new Vector2(-1, 1);
        }

        //_state = State.Idle;
        /*var direction = Input.GetAxis("Horizontal");
        if (direction > 0)
        {
            _rigidbody.velocity = new Vector2(4, _rigidbody.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if (direction < 0)
        {
            _rigidbody.velocity = new Vector2(-4, _rigidbody.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        
        if (Input.GetButtonDown("Jump") && _collider2D.IsTouchingLayers(_ground))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 9f);
            _state = State.Jumping;
        }*/
        
        StateChange();
        _animator.SetInteger("State", (int)_state);
    }

    private void StateChange()
    {
        if (_state == State.Jumping)
        {
            if (_rigidbody.velocity.y < .1f)
            {
                _state = State.Falling;
            }
        }
        else if (_state == State.Falling)
        {
            if (_collider2D.IsTouchingLayers(_ground))
            {
                _state = State.Idle;
            }
        }
        else if (Math.Abs(_rigidbody.velocity.x) > 1f)
        {
            _state = State.Running;
        }
        else
        {
            _state = State.Idle;
        }
    }

    private void JumpSound()
    {
        _jumpSound[0].Play();
    }

    private void WalkSound()
    {
        _jumpSound[1].Play();
    }
}
