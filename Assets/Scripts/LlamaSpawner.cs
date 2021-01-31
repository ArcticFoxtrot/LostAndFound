using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaSpawner : MonoBehaviour
{

    //Sprite objects
    GameObject eye;
    GameObject leftEar;
    GameObject rightEar;
    GameObject hair;

    public float movementSpeed = 0.1f;
    public bool needsToWait = true;
    private float startTime;
    private float distance;

    public GameObject llama;
    public GameObject partsStorage;
    public SpeechBubbleManager bubble;
    //Sprite positions
    public GameObject eyePosition;
    public GameObject earRPosition;
    public GameObject earLPosition;
    public GameObject hairPosition;

    private Boolean isMovable = false;
    private Boolean isReturning = false;
    private Boolean hasReachedEnd = false;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform dialogPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        //check for parts
        //if hars parts, move to partsstorage


        spawnPoint = transform.GetChild(0);
        endPoint = transform.GetChild(1);
        dialogPoint = transform.GetChild(2);



        //Find the different parts
        eye = GameObject.Find("Llalpaca_Eye1");
        leftEar = GameObject.Find("Llalpaca_Ear1_L");
        rightEar = GameObject.Find("Llalpaca_Ear1_R");
        hair = GameObject.Find("Llalpaca_Hair1");

        
        

        //Find the alpaca and storage for faster reference
        llama = GameObject.FindWithTag("AlpacaBody");
        partsStorage = GameObject.FindWithTag("PartsStorage");

        //eye.transform.parent = partsStorage.transform;
        eye.transform.position = partsStorage.transform.position;
        //Find the positions for the parts
        eyePosition = GameObject.Find("EyePosition").gameObject;
        earRPosition = GameObject.Find("EarRPosition");
        earLPosition = GameObject.Find("EarLPosition");
        hairPosition = GameObject.Find("HairPosition");


        bubble.gameObject.SetActive(false);
        
        bubble.transform.position = dialogPoint.transform.position;
        distance = Vector3.Distance(spawnPoint.transform.position, endPoint.transform.position);

        llama.transform.position = spawnPoint.position;
        UpdatePartPositions();

        LoadRandomParts();

        if(needsToWait){
            StartCoroutine(Waiter());
        } else {
            NoWaiter();
        }
        

    }

    void Update() {
        if (isMovable) {
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfTravel = distCovered / distance;
            llama.transform.position = Vector3.Lerp(spawnPoint.position, endPoint.position, fractionOfTravel);
        }
        if (Vector3.Distance(llama.transform.position, endPoint.transform.position) <= 0.1f) {
            bubble.gameObject.SetActive(true);
        }

            if (isReturning) {
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfTravel = distCovered / distance;
            llama.transform.position = Vector3.Lerp(endPoint.position, spawnPoint.position, fractionOfTravel);
        }
    }

    IEnumerator Waiter() {
        if (isMovable) {
            isMovable = false;
        }
        yield return new WaitForSeconds(5);
        isMovable = true;
        startTime = Time.time;
    }

    public void NoWaiter(){
        if (isMovable) {
            isMovable = false;
        }
        isMovable = true;
        startTime = Time.time;
    }



    /*Loads random parts for the Alpaca by first moving the part away into PartsStorage,
     * and then moving a new part into place on the Alpaca.
     */
    public void LoadRandomParts() {
        //Move the old ear away
        bubble.UpdateText();
        if (leftEar) {
            leftEar.transform.position = partsStorage.transform.position;
        }
        rightEar.transform.position = partsStorage.transform.position;

        //Randomize the ear number
        int earInt = UnityEngine.Random.Range(1, 4);
        
        //Choose new ears
        if (earInt == 2) {
            rightEar = GameObject.Find("Llalpaca_Ear2");
            leftEar = null; //leftEar is null in this case as the sprites only have one ear for this set
        }else {
            SetEars(earInt);
        }

        //Move old eye to storage
        eye.transform.position = partsStorage.transform.position;

        //Randomize the eye number, set the new eye
        string eyeString = "Llalpaca_Eye" + UnityEngine.Random.Range(1, 5);
        eye = GameObject.Find(eyeString);

        //Move old hair into storage
        hair.transform.position = partsStorage.transform.position;

        //Randomize the hair number, set the new hair
        string hairString = "Llalpaca_Hair" + UnityEngine.Random.Range(1, 5);
        hair = GameObject.Find(hairString);

        UpdatePartPositions();
    }

    void SetEars(int num) {

        //Generate the strings first as GameObject.Find cannot parse the strings in the parameters
        string leftString = "Llalpaca_Ear" + num + "_L";
        string rightString = "Llalpaca_Ear" + num + "_R";
        leftEar = GameObject.Find(leftString);
        rightEar = GameObject.Find(rightString);

        Debug.Log("Found: " + leftEar + "\n" + "Found: " + rightEar);
    }

    void UpdatePartPositions() {
        eye.transform.position = eyePosition.transform.position;
        eye.transform.rotation = eyePosition.transform.rotation;
        eye.transform.parent = eyePosition.transform;

        if (leftEar) {
            leftEar.transform.position = earLPosition.transform.position;
            leftEar.transform.rotation = earLPosition.transform.rotation;
            leftEar.transform.parent = earLPosition.transform;
        }
        rightEar.transform.position = earRPosition.transform.position;
        rightEar.transform.rotation = earRPosition.transform.rotation;
        rightEar.transform.parent = earLPosition.transform;

        hair.transform.position = hairPosition.transform.position;
        hair.transform.rotation = hairPosition.transform.rotation;
        hair.transform.parent = hairPosition.transform;
    }
}
