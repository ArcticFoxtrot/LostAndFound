using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI powerText;



    // Start is called before the first frame update
    void Start()
    {
        powerText.text = "Power: 0";
    }


    public void UpdateCanvasText(float f){
        powerText.text = "Power: " + f.ToString("F2");
    }

}
