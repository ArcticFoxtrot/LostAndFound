using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ObjectsSpawnedHandler();

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnableObjects;
    [SerializeField] Transform bottomLeftLimit;
    [SerializeField] Transform topLeftLimit;
    [SerializeField] Transform bottomRightLimit;
    [SerializeField] Transform topRightLimit;

    public event ObjectsSpawnedHandler ObjectsSpawned;

    // Start is called before the first frame update
    private void Awake(){
        //spawnPoint = RandomPoint(bottomLeftLimit.position, topLeftLimit.position);
        foreach(GameObject obj in spawnableObjects){
            Vector3 spawnPoint = GetRandomSpawnPoint();
            Instantiate(obj, spawnPoint, Quaternion.identity);
        }
        //raise event that objects are spawned
        if(ObjectsSpawned != null){
            ObjectsSpawned();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetRandomSpawnPoint(){
        Vector3 pointA = RandomPoint(bottomLeftLimit.position, bottomRightLimit.position);
        Vector3 pointB = RandomPoint(topLeftLimit.position, topRightLimit.position);
        Vector3 spawnPoint = RandomPoint(pointA, pointB);
        //Vector3 spawnPoint = Vector3.Lerp(pointA, pointB, Random.Range(0f, Vector3.Distance(pointA, pointB)));
        return spawnPoint;
    }


    private Vector3 RandomPoint(Vector3 v1, Vector3 v2){
        float x = Random.Range(v1.x, v2.x);
        float y = Random.Range(v1.y, v2.y);
        float z = Random.Range(v1.z, v2.z);
        return new Vector3(x, y, z);
    }
}
