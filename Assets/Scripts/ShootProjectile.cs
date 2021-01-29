using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public Projectile projectile;
    private Grabber grabber;
    private Projectile loadedProjectile;

    // Start is called before the first frame update
    void Start()
    {
        grabber = GetComponent<Grabber>();
        if(grabber == null){
            Debug.LogWarning("ShootProjectile was unable to locate grabber!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            projectile = GetProjectile();
        }

        if(Input.GetKeyDown(KeyCode.E)){
            LoadShooter();
        }

        if(Input.GetMouseButtonDown(0)){
            LaunchProjectile();
        }

    }

    private void LaunchProjectile()
    {
        throw new NotImplementedException();
    }

    private Projectile GetProjectile(){
        if(grabber.GetCurrentProjectile() != null){
            Projectile projectile = grabber.GetCurrentProjectile();
            return projectile;
        } else {
            return null;
        }
    }

    private void LoadShooter(){
        loadedProjectile = projectile;
    }

}
