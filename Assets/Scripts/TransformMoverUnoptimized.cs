using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMoverUnoptimized : TransformMover
{
    protected override void MoveTransforms(float deltaTime)
    {
        for (int i = 0; i < transforms.Length; ++i)
        {
            transforms[i].position += 2.5f * Mathf.Cos(Time.time) * movementDirections[i] * deltaTime; 
        }
    }
}
