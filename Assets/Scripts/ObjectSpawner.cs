using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ObjectsSpawnedHandler();

public class ObjectSpawner : MonoBehaviour
{


    [SerializeField] private List<GameObject> spawnableObjects = new List<GameObject>(); //all possible spawnable objects
    private List<GameObject> objectsToSpawn = new List<GameObject>();
    public List<GameObject> objectsInScene = new List<GameObject>(); 
    [SerializeField] int numberOfObjectsToSpawn = 10;
    [SerializeField] Transform bottomLeftLimit;
    [SerializeField] Transform topLeftLimit;
    [SerializeField] Transform bottomRightLimit;
    [SerializeField] Transform topRightLimit;
    [SerializeField] Transform sceneObjectParent;

    public static event ObjectsSpawnedHandler ObjectsSpawned;

    // Start is called before the first frame update
    private void Awake(){
        List<GameObject> spawnableObjectsCopy = new List<GameObject>(spawnableObjects); //make copy of spawnable objects
        //get objects to spawn
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            GameObject obj = GetRandomSpawnableObject(spawnableObjectsCopy);
            objectsToSpawn.Add(obj);
            spawnableObjectsCopy.Remove(obj);
        }

        //spawnPoint = RandomPoint(bottomLeftLimit.position, topLeftLimit.position);
        foreach(GameObject obj in objectsToSpawn){
            Vector3 spawnPoint = GetRandomSpawnPoint();
            Quaternion quaternion = GetRandomRotation();
            Instantiate(obj, spawnPoint, quaternion, sceneObjectParent);
            objectsInScene.Add(obj);
        }
        //raise event that objects are spawned
        if(ObjectsSpawned != null){
            ObjectsSpawned();
        }
        
    }

    private Quaternion GetRandomRotation()
    {
        Quaternion q = Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        return q;
    }

    private GameObject GetRandomSpawnableObject(List<GameObject> spawnableObjects)
    {
        int index = Random.Range(0, spawnableObjects.Count);
        return spawnableObjects[index];

    }

    public void CheckObjectsInScene(){
        List<GameObject> listOfObjects = new List<GameObject>();
        Projectile[] projectileArray = FindObjectsOfType<Projectile>();
        foreach(Projectile projectile in projectileArray){
            if(projectile.GetIsUsable() == true && projectile.gameObject.activeSelf == true){
                listOfObjects.Add(projectile.gameObject);
            } else {
                continue;
            }
        }
        
        objectsInScene = listOfObjects;
    }

    public List<GameObject> GetObjectsInScene(){
        return objectsInScene;
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
