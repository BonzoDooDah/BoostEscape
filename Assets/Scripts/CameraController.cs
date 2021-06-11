using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform objectToFollow;

    private Vector3 offsetPosition;

    private void Start() {
        offsetPosition = transform.position;
    }

    private void Update() {
        if (objectToFollow) transform.position = objectToFollow.position + offsetPosition;
    }
}
