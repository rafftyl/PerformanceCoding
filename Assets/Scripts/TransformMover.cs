using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMover : MonoBehaviour
{
    float movementFrequency;
    float movementAmplitude;
    float phaseOffset;
    Vector3 movementDir;

    private void Start()
    {
        movementAmplitude = Random.Range(1.0f, 3.0f);
        movementFrequency = 2 * Mathf.PI * Random.Range(1.0f, 3.0f);
        phaseOffset = Mathf.PI * Random.Range(0.0f, 2.0f);
        movementDir = Random.insideUnitSphere.normalized;
    }

    void Update ()
    {
        transform.position +=
            movementDir *
            movementFrequency *
            Mathf.Cos(Time.time + phaseOffset) * Time.deltaTime;
	}
}
