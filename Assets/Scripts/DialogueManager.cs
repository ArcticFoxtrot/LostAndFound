using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject controller;
    public ObjectSpawner objectSpawner;
    private List<GameObject> objectsInScene;
    [SerializeField] int maxLoops = 5;
    public List<string> possibleCategories;
    public List<string> possibleColours;
    public List<string> possibleNames;
    public string currentCategory;
    public List<string> possibleStarts;
    public List<string> possibleEnds;
    public List<string> possibleLines;
    public Dictionary<string, string> possibleLineItemPairs;

    private string acceptedValue;



    // Start is called before the first frame update
    void Start()
    {
        possibleLineItemPairs = new Dictionary<string, string>();
    }

    private void PopulateLines()
    {
        possibleLines.Clear();
        possibleLineItemPairs.Clear();
        possibleStarts.Add("I lost my ");
        possibleStarts.Add("Have you seen my ");
        possibleStarts.Add("Yo! I think I dropped my ");
        possibleStarts.Add("Hello there! Someone stole my ");
        possibleStarts.Add("Help me! I have a party coming up and I need a ");

        possibleEnds.Add(". Halp!");
        possibleEnds.Add(". Toss it here!");
        possibleEnds.Add(". Do me a solid!");
        possibleEnds.Add(". I need it!");
        possibleEnds.Add(". Throw, I'll catch!");

        for (int i = 0; i < possibleStarts.Count; i++)
        {
            string lineStart = possibleStarts[Random.Range(0, possibleStarts.Count)];
            string name = GetRandomName();
            string lineEnd = possibleEnds[Random.Range(0, possibleEnds.Count)];
            possibleLines.Add(lineStart + name + lineEnd);

            string keyValue = null;
            possibleLineItemPairs.TryGetValue(lineStart + name + lineEnd, out keyValue);
            if(keyValue != null){
                continue;
            }

            possibleLineItemPairs.Add(lineStart + name + lineEnd, name);
        }

        for (int i = 0; i < maxLoops; i++)
        {
            string colour = GetRandomColour();
            string line = "Helloo! I think I lost something...uhhh..." + colour + possibleEnds[Random.Range(0, possibleEnds.Count)];
            possibleLines.Add(line);
            //possibleLineItemPairs.Add(line, colour);
            string keyValue = null;
            possibleLineItemPairs.TryGetValue(line, out keyValue);
            if(keyValue != null){
                continue;
            }

            possibleLineItemPairs.Add(line, colour);
        }

        for (int i = 0; i < maxLoops; i++)
        {
            string category = GetRandomCategory();
            string line = "You have a..." + category + possibleEnds[Random.Range(0, possibleEnds.Count)];
            possibleLines.Add(line);
            //possibleLineItemPairs.Add(line, category);
            string keyValue = null;
            possibleLineItemPairs.TryGetValue(line, out keyValue);
            if(keyValue != null){
                continue;
            }

            possibleLineItemPairs.Add(line, category);
        }
        
        string randomName = GetRandomName();
        string randomline = "Help! My grandson is trying to kill me! I need a " + randomName + ", quickly!";
        possibleLines.Add(randomline);
        possibleLineItemPairs.Add(randomline, randomName);
        possibleLines.Add("Uhhh. Grandma isn't looking too well. Can you toss me a coffin?");
        possibleLineItemPairs.Add("Uhhh. Grandma isn't looking too well. Can you toss me a coffin?", "Coffin");
        
    }

    public string PickLine(){
        PopulateLines();
        string line = possibleLines[Random.Range(0, possibleLines.Count)];
        possibleLineItemPairs.TryGetValue(line, out acceptedValue);

        return line;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetObjectsInScene(){
        objectsInScene = objectSpawner.GetObjectsInScene();
    }

    public void GetPossibleCategories(){
        GetObjectsInScene();
        possibleCategories.Clear();
        foreach(GameObject obj in objectsInScene){
            ObjectCategory categoryEnumValue = obj.GetComponent<RetrievableObject>().objectCategory;
            possibleCategories.Add(categoryEnumValue.ToString());
        }
    }

    public void GetPossibleColours()
    {
        GetObjectsInScene();
        possibleColours.Clear();
        foreach(GameObject obj in objectsInScene){
            Debug.Log("foreach run lap");
            ColourCategory colourEnumValue = obj.GetComponent<RetrievableObject>().colourCategory;
            possibleColours.Add(colourEnumValue.ToString());
        }
    }

    public void GetPossibleNames()
    {
        GetObjectsInScene();
        possibleNames.Clear();
        foreach(GameObject obj in objectsInScene){
            string name = obj.GetComponent<RetrievableObject>().objectName;
            possibleNames.Add(name);
        }
    }

    public string GetRandomCategory(){
        GetPossibleCategories();
        string category = possibleCategories[Random.Range(0, possibleCategories.Count)];
        return category;
    }

    public string GetRandomColour(){
        GetPossibleColours();
        string colour = possibleColours[Random.Range(0, possibleColours.Count)];
        return colour;
    }

    public string GetRandomName(){
        GetPossibleNames();
        string name = possibleNames[Random.Range(0, possibleNames.Count)];
        return name;
    }

    public string GetAcceptedValue(){
        return acceptedValue;
    }

/*
    public void FormSpecificRequest() {
        SpeechBubbleManager sbm = controller.GetComponent<SpeechBubbleManager>();
        sbm.UpdateText(PickLine());

    }
    */
}
