using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject controller;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FormSpecificRequest(string attribute) {
        SpeechBubbleManager sbm = controller.GetComponent<SpeechBubbleManager>();
        sbm.UpdateText("This text has come from the DialogueManager!");

    }
}
