using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public bool isUsable = true;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Sprite previewSprite;

    public void SetIsUsable(bool t){
        isUsable = t;
    }

    public bool GetIsUsable(){
        return isUsable;
    }

    public GameObject GetProjectilePrefab(){
        return projectilePrefab;
    }

    public Sprite GetPreviewSprite(){
        return previewSprite;
    }

    private void OnTriggerEnter(Collider other) {
        SetIsUsable(true);
    }

}
