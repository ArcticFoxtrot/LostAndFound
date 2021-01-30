using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public Projectile projectile;
    private Grabber grabber;
    public Projectile loadedProjectile;
    private bool isShooterLoaded = false;
    private float originalLaunchProjectilePower;
    private UIHandler uIHandler;

    [SerializeField] Transform shootFromPoint;
    [SerializeField] float launchProjectilePower;
    [SerializeField] float powerIncreaseIncrement = 0.1f;
    [SerializeField] float powerIncreaseIncrementTime = 0.1f;
    [SerializeField] Transform projectileParent;
    [SerializeField] GameObject UICanvas;

    
        // Start is called before the first frame update
    void Start()
    {
        grabber = GetComponent<Grabber>();
        if(grabber == null){
            Debug.LogWarning("ShootProjectile was unable to locate grabber!");
        }

        uIHandler = UICanvas.GetComponent<UIHandler>();
        if(uIHandler == null){
            Debug.LogWarning("ShootProjectile was unable to locate a UIHandler!");
        }

        originalLaunchProjectilePower = launchProjectilePower;

    }

    // Update is called once per frame
    void Update()
    {
        if(uIHandler){
            uIHandler.UpdateCanvasText(launchProjectilePower);
        }
        
        if(Input.GetMouseButtonDown(1)){
            projectile = GetProjectile();
        }

        if(Input.GetKeyDown(KeyCode.E)){
            //remove object from world
            if(projectile && projectile.GetIsUsable() == true){
                LoadShooter();
            }
            
        }

        if(Input.GetMouseButton(0)){
            StartCoroutine("IncreaseForce");
        } else if(Input.GetMouseButtonUp(0)){
            LaunchProjectile();
            projectile = null;
            StopCoroutine("IncreaseForce");
            launchProjectilePower = originalLaunchProjectilePower;
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            UnLoadShooter();
            SetProjectileObjectActive(true);
        }

    }

    private IEnumerator IncreaseForce(){
        while (true){
            yield return new WaitForSeconds(powerIncreaseIncrementTime);
            launchProjectilePower = launchProjectilePower + powerIncreaseIncrement;
        }
    }

    private void LaunchProjectile()
    {
        if(isShooterLoaded){
            //get aim at direction
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 direction = ray.direction;
            //get power from input?
            //instantiate projectile object
            GameObject p = Instantiate(projectile.GetProjectilePrefab(), shootFromPoint.transform.position, Quaternion.identity, projectileParent);
            p.SetActive(true);
            //add force to rigidbody
            Rigidbody projectileRB = p.GetComponent<Rigidbody>();
            projectileRB.AddForce(direction.normalized * launchProjectilePower);
            p.GetComponent<Projectile>().SetIsUsable(false);
            grabber.ClearProjectile();
        }
        UnLoadShooter();
    }

    private Projectile GetProjectile(){
        if(grabber.GetCurrentProjectile() != null){
            Projectile p = grabber.GetCurrentProjectile();
            return p;
        } else {
            return null;
        }
    }

    private void LoadShooter(){
        loadedProjectile = projectile;
        if(loadedProjectile){
            SetProjectileObjectActive(false);
            isShooterLoaded = true;
        }

    }

    private void UnLoadShooter(){
        if(loadedProjectile){
            loadedProjectile = null;
            isShooterLoaded = false;
        }
    }

    private void SetProjectileObjectActive(bool t)
    {
        projectile.gameObject.SetActive(t);
    }

}
