using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleManager : MonoBehaviour
{

    GameObject camera;
    Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        
        transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
        myTransform.LookAt(camera.transform);
    }
}
