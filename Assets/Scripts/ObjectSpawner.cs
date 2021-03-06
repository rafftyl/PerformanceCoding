﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float separation = 1.2f;
    public int sizeX = 10;
    public int sizeY = 10;
    public int sizeZ = 10;
    public bool spawnOnStart = true;

    private void Start()
    {
        if(spawnOnStart)
        {
            SpawnObjects();
        }        
    }

    public Transform[] SpawnObjects()
    {
        Transform[] result = new Transform[sizeX * sizeY * sizeZ];
        int index = 0;
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
                    result[index] = obj.transform;
                    ++index;
                }
            }            
        }
        return result;
    }
}
