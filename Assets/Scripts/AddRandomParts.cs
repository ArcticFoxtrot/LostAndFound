using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomParts : MonoBehaviour
{
    GameObject eye;
    GameObject leftEar;
    GameObject rightEar;
    GameObject hair;

    // Start is called before the first frame update
    void Start()
    {
        eye = GameObject.Find("Llalpaca_Eye1");
        leftEar = GameObject.Find("Llalpaca_Ear1_L");
        rightEar = GameObject.Find("Llalpaca_Ear1_R");
        hair = GameObject.Find("Llalpaca_Hair1");

        eye.transform.position = GameObject.Find("EyePosition").transform.position;
        leftEar.transform.position = GameObject.Find("LeftEarPosition").transform.position;
        rightEar.transform.position = GameObject.Find("RightEarPosition").transform.position;
        hair.transform.position = GameObject.Find("hairPosition").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNewParts() {

    }
}
