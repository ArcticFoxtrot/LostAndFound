using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    [SerializeField] float maxGrabDistance = 1f;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] bool invertMask;


    private Projectile selectedProjectile;

    public Projectile GetCurrentProjectile(){
        LayerMask layer = ~(invertMask? ~ignoreLayer.value : ignoreLayer.value);

         RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, maxGrabDistance)){
                selectedProjectile = hitInfo.collider.gameObject.GetComponent<Projectile>();
                if(selectedProjectile == null){
                    return null;
                } else {
                    return selectedProjectile;
                }
                
            } else {
                return null;
            }
        
    }

    public void ClearProjectile()
    {

        selectedProjectile = null;
    }
}
