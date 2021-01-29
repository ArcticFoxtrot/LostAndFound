using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    private Projectile selectedProjectile;

    public Projectile GetCurrentProjectile(){
         RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo)){
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



}
