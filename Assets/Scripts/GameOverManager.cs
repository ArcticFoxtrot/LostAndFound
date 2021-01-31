using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    private SceneLoader SceneLoader;
    private int playableObjectCount;
    public ObjectSpawner objectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playableObjectCount = objectSpawner.GetObjectsInScene().Count;
        if(playableObjectCount <= 0){
            FindObjectOfType<SceneLoader>().LoadMenuScene();
        }
    }
}
