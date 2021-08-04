using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
    [SerializeField] private Vector3 amplitude;
    [SerializeField] private float period = 2f;

    private Vector3 _startPosition;

    private void Start() {
        _startPosition = transform.position;
    }

    private void Update() {
        const float tau = Mathf.PI * 2;

        float cycle = Time.time / period;
        float rawSinWave = Mathf.Sin(cycle * tau);

        Vector3 offset = amplitude * rawSinWave;
        transform.position = _startPosition + offset;
    }
}
