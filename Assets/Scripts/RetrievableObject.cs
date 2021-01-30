using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectCategory {Transport, Weapon, Halloween, SciFi, Graveyard, Cutlery, Anything, Christmas, Furniture};
public enum ColourCategory {White, Black, Red, Green, Blue, Orange, Yellow, Brown, Purple, Grey};

public class RetrievableObject : MonoBehaviour
{
    


    public ObjectCategory objectCategory;
    public ColourCategory colourCategory;
    private Material currentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewMethod(ObjectCategory category){

    }

}
