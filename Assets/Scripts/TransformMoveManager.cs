using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

public struct TransformMoveJob : IJobParallelForTransform
{
    public float time;
    public float deltaTime;
    [ReadOnly]
    public NativeArray<MoveData> moveData;

    public void Execute(int index, TransformAccess transform)
    {
        transform.position +=
         moveData[index].movementDir *
         moveData[index].movementFrequency *
         moveData[index].movementAmplitude *
         Mathf.Cos(time + moveData[index].phaseOffset) * deltaTime;
        transform.rotation *= Quaternion.AngleAxis(moveData[index].angularSpeed * deltaTime, moveData[index].movementDir);

    }
}

public class TransformMoveManager : MonoBehaviour
{
    public ObjectSpawner spawner;    
    TransformAccessArray transformAccessArray;
    NativeArray<MoveData> moveData;
    JobHandle handle;

	void Awake ()
    {
        var trans = spawner.SpawnObjects();
        transformAccessArray = new TransformAccessArray(trans);
        MoveData[] tempData = new MoveData[trans.Length];
        for(int i = 0; i < trans.Length; ++i)
        {
            tempData[i].movementAmplitude = Random.Range(1.0f, 3.0f);
            tempData[i].movementFrequency = 2 * Mathf.PI * Random.Range(1.0f, 3.0f);
            tempData[i].phaseOffset = Mathf.PI * Random.Range(0.0f, 2.0f);
            tempData[i].movementDir = Random.insideUnitSphere.normalized;
            tempData[i].angularSpeed = Random.Range(20.0f, 50.0f);
        }
        moveData = new NativeArray<MoveData>(tempData, Allocator.Persistent);
	}

    private void Update()
    {
        var job = new TransformMoveJob
        {
            time = Time.time,
            deltaTime = Time.deltaTime,
            moveData = moveData
        };

        handle = job.Schedule(transformAccessArray);
    }

    private void LateUpdate()
    {
        handle.Complete();
    }

    private void OnDestroy()
    {
        transformAccessArray.Dispose();
        moveData.Dispose();
    }
}
