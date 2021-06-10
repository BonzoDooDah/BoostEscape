using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour {
    [Header("Thrust Values")]
    [SerializeField] private float mainThrust = 1000f;
    [SerializeField] private float rotationalThrust = 150f;

    [Header("Input Controls")]
    [SerializeField] private InputAction inputRotation;
    [SerializeField] private InputAction inputThrust;

    private Rigidbody _rigidbody = null;

    private void OnEnable() {
        inputRotation.Enable();
        inputThrust.Enable();
    }

    private void OnDisable() {
        inputRotation.Disable();
        inputThrust.Disable();
    }

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        ProcessMainThrustInput();
        ProcessRotationInput();
    }

    private void ProcessMainThrustInput() {
        if (inputThrust.ReadValue<float>() > 0.5f) {
            _rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    private void ProcessRotationInput() {
        float xThrow = inputRotation.ReadValue<float>();
        if (xThrow < 0) {
            ActivateRotation(false);
        } else if (xThrow > 0) {
            ActivateRotation(true);
        }
    }

    private void ActivateRotation(bool clockwise) {
        _rigidbody.freezeRotation = true; // freeze physics rotation

        if (clockwise) {
            transform.Rotate(-Vector3.forward * rotationalThrust * Time.deltaTime);
        } else {
            transform.Rotate(Vector3.forward * rotationalThrust * Time.deltaTime);
        }

        _rigidbody.freezeRotation = false; // un-freeze physics rotation
    }
}
