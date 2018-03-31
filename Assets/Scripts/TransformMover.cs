using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformMover : MonoBehaviour
{
    public GameObject objectPrefab;
    public float separation = 1.2f;
    public int sizeX = 10;
    public int sizeY = 10;
    public int sizeZ = 10;

    protected Transform[] transforms;
    protected Vector3[] movementDirections;

    private void Start()
    {
        SpawnObjects();
    }

    private void Update()
    {
        MoveTransforms(Time.deltaTime);
    }

    private void SpawnObjects()
    {
        int objectCount = sizeX * sizeY * sizeZ;
        transforms = new Transform[objectCount];
        movementDirections = new Vector3[objectCount];

        int objectIndex = 0;
        for(int x = 0; x < sizeX; ++x)
        {
            float xPos = separation * (x - sizeX / 2);
            for(int y = 0;  y < sizeY; ++y)
            {
                float yPos = separation * (y - sizeY / 2);
                for (int z = 0; z < sizeZ; ++z)
                {
                    float zPos = separation * (z - sizeZ / 2); ;
                    Vector3 position = transform.position + new Vector3(xPos,yPos,zPos);
                    GameObject obj = Instantiate<GameObject>(objectPrefab, position, Quaternion.identity);
                    transforms[objectIndex] = obj.transform;
                    movementDirections[objectIndex] = Random.insideUnitSphere.normalized;
                    ++objectIndex;
                }
            }            
        }
    }

    protected abstract void MoveTransforms(float deltaTime);
}
