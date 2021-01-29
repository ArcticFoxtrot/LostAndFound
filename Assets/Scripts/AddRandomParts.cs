using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomParts : MonoBehaviour
{
    //Sprite objects
    GameObject eye;
    GameObject leftEar;
    GameObject rightEar;
    GameObject hair;

    public GameObject alpaca;
    public GameObject partsStorage;
    //Sprite positions
    public GameObject eyePosition;
    public GameObject earRPosition;
    public GameObject earLPosition;
    public GameObject hairPosition;

    // Start is called before the first frame update
    void Start()
    {

        //Find the different parts
        eye = GameObject.Find("Llalpaca_Eye1");
        leftEar = GameObject.Find("Llalpaca_Ear1_L");
        rightEar = GameObject.Find("Llalpaca_Ear1_R");
        hair = GameObject.Find("Llalpaca_Hair1");

        //Find the alpaca and storage for faster reference
        alpaca = GameObject.FindWithTag("AlpacaBody");
        partsStorage = GameObject.FindWithTag("PartsStorage");

        //Find the positions for the parts
        eyePosition = GameObject.Find("EyePosition").gameObject;
        earRPosition = GameObject.Find("EarRPosition");
        earLPosition = GameObject.Find("EarLPosition");
        hairPosition = GameObject.Find("HairPosition");

        UpdatePartPositions();

        
    }

    public void onClick() {
        LoadRandomParts();
    }

    /*Loads random parts for the Alpaca by first moving the part away into PartsStorage,
     * and then moving a new part into place on the Alpaca.
     */
    public void LoadRandomParts() {
        //Move the old ear away
        if (leftEar) {
            leftEar.transform.position = partsStorage.transform.position;
        }
        rightEar.transform.position = partsStorage.transform.position;

        //Randomize the ear number
        int earInt = Random.Range(1, 4);
        
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
        string eyeString = "Llalpaca_Eye" + Random.Range(1, 5);
        eye = GameObject.Find(eyeString);

        //Move old hair into storage
        hair.transform.position = partsStorage.transform.position;

        //Randomize the hair number, set the new hair
        string hairString = "Llalpaca_Hair" + Random.Range(1, 5);
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

        if (leftEar) {
            leftEar.transform.position = earLPosition.transform.position;
        }
        rightEar.transform.position = earRPosition.transform.position;
        hair.transform.position = hairPosition.transform.position;
    }
}
