﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FPSInput))]
[RequireComponent(typeof(FPSMotor))]
public class PlayerController : MonoBehaviour
{

    FPSInput _input = null;
    FPSMotor _motor = null;
    AudioSource audioSource = null;
    
    public float playerHealth = 5.0f;
    public Slider healthBar;
    public bool alive;

    [SerializeField] float _moveSpeed = 0.1f;
    [SerializeField] float _walkSpeed = 0.1f;
    [SerializeField] float _turnSpeed = 6.0f;
    [SerializeField] float _jumpStrength = 10.0f;


    private void Start()
    {
        alive = true;
    }


    private void Awake()
    {
        _input = GetComponent<FPSInput>();
        _motor = GetComponent<FPSMotor>();
    }

    private void OnEnable()
    {
        _input.MoveInput += OnMove;
        _input.RotateInput += OnRotate;
        _input.JumpInput += OnJump;
    }

    private void OnDisable()
    {
        _input.MoveInput -= OnMove;
        _input.RotateInput -= OnRotate;
        _input.JumpInput -= OnJump;
    }

    void OnMove(Vector3 movement)
    {
        _motor.Move(movement * _moveSpeed);
    }

    void OnRotate(Vector3 rotation)
    {
        _motor.Turn(rotation.y * _turnSpeed);
        _motor.Look(rotation.x * _turnSpeed);
    }

    void OnJump()
    {
        _motor.Jump(_jumpStrength);
    }

    void Update()
    {

        healthBar.value = playerHealth;

    }
}
