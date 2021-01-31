using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaTriggerHandler : MonoBehaviour
{

    [SerializeField] Collider llamaCollider;
    [SerializeField] SpeechBubbleManager speechBubbleManager;
    [SerializeField] LlamaSpawner llamaSpawnerPrefab;
    [SerializeField] LlamaSpawner llamaSpawnerInScene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (CompareDictValue(other.GetComponent<RetrievableObject>().objectCategory.ToString())
        || CompareDictValue(other.GetComponent<RetrievableObject>().colourCategory.ToString())
        || CompareDictValue(other.name))
        {
            //accepted answer
            //Debug.Log("Correct!");
            //thanks message?
            //MUST DO return Llama to position x, spawn new llama
        }
        else {
            //Debug.Log("False!");
            //MUST DO return Llama to position x, spawn new llama
        }

        //LlamaSpawner newLlama = Instantiate(llamaSpawnerPrefab, llamaSpawnerPrefab.transform.position, Quaternion.identity);
        
        //newLlama.needsToWait = false;
        llamaSpawnerInScene.LoadRandomParts();
        llamaSpawnerInScene.NoWaiter();
        other.gameObject.GetComponent<Projectile>().SetIsUsable(false);
        other.gameObject.SetActive(false);
        
        
    }

    private bool CompareDictValue(string compareString){
        string acceptedValue = speechBubbleManager.GetAcceptedValueFromSBM();
        if(acceptedValue == compareString){
            return true;
        } else {
            return false;
        }
    }

}
