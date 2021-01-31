using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectCategory {Transport, Weapon, Halloween, SciFi, Graveyard, Cutlery, Christmas, Furniture, Light, Wheel, Buoy};
public enum ColourCategory {White, Black, Red, Green, Blue, Orange, Yellow, Brown, Purple, Grey};

public class RetrievableObject : MonoBehaviour
{
    public ObjectCategory objectCategory;
    public ColourCategory colourCategory;
    public string objectName;
    private Material currentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
