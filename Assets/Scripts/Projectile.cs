using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public bool isUsable = true;
    [SerializeField] GameObject projectilePrefab;

    public void SetIsUsable(bool t){
        isUsable = t;
    }

    public bool GetIsUsable(){
        return isUsable;
    }

    public GameObject GetProjectilePrefab(){
        return projectilePrefab;
    }

    private void OnTriggerEnter(Collider other) {
        SetIsUsable(true);
    }

}
