using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    [Header("Input Controls")]
    [SerializeField] private InputAction inputStart;

    [Header("Crossfade Transition")]
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionDelay = 3f;

    private void OnEnable() {
        inputStart.Enable();
    }

    private void OnDisable() {
        inputStart.Disable();
    }

    private void Start() {
        Cursor.visible = false;
    }

    private void Update() {
        if (inputStart.ReadValue<float>() > 0.5f) {
            //start game
        }
    }
}
