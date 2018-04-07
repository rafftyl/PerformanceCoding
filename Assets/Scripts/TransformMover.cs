using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveData
{
    public float movementFrequency;
    public float movementAmplitude;
    public float phaseOffset;
    public Vector3 movementDir;
    public float angularSpeed;
}

public class TransformMover : MonoBehaviour
{
    MoveData data;
    private void Start()
    {
        data.movementAmplitude = Random.Range(1.0f, 3.0f);
        data.movementFrequency = 2 * Mathf.PI * Random.Range(1.0f, 3.0f);
        data.phaseOffset = Mathf.PI * Random.Range(0.0f, 2.0f);
        data.movementDir = Random.insideUnitSphere.normalized;
        data.angularSpeed = Random.Range(20.0f, 50.0f);
    }

    void Update ()
    {
        transform.position +=
            data.movementDir *
            data.movementFrequency *
            data.movementAmplitude *
            Mathf.Cos(Time.time + data.phaseOffset) * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(data.angularSpeed * Time.deltaTime, data.movementDir);
	}
}
