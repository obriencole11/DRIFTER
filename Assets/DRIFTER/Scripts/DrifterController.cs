﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrifterController : MonoBehaviour {

    [SerializeField]
    private bool canJump = true;

    public float speed;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;

    Vector3 movement;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }

    void Start () {
		
	}
	
	void Update () {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxis("Vertical");
		
	// f = a
	// f = v2 - v1
	Vector3 target_velocity = new Vector3(xInput, 0.0, yInput).normalized * speed;
	Vector3 current_velocity = _rigidbody.velocity;
	movement = target_velocity - current_velocity;
		
        // movement = (xInput * transform.right + yInput * transform.forward).normalized;
	}	

    private void FixedUpdate(){
        // _rigidbody.velocity = movement * speed * Time.deltaTime;
    	// Switched to add force, should handle collisions better, but may 'feel' different?
    	// I also may have got the forcemode wrong
    	_rigidbody.addForce(movement, ForceMode.Impulse);
    }
}
