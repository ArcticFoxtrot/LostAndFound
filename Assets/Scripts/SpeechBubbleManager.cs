using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class SpeechBubbleManager : MonoBehaviour
{

    [SerializeField] TextMeshPro bubbleText;
    [SerializeField] DialogueManager dialogueManager;

    GameObject camera;
    Transform myTransform;
    private string acceptedValue;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        
        transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
        myTransform.LookAt(camera.transform);
    }

    public void UpdateText() {
        string textInput = dialogueManager.PickLine();
        acceptedValue = dialogueManager.GetAcceptedValue();
        Debug.Log("UpdateText has been called!");
        //GameObject textBox = transform.Find("Speech Bubble/Speech Text").gameObject;
        //TextMeshPro tmp = textBox.GetComponent<TextMeshPro>();
        bubbleText.text = textInput;
        //tmp.SetText(textInput);
    }

    public string GetAcceptedValueFromSBM(){
        return acceptedValue;
    }
}
