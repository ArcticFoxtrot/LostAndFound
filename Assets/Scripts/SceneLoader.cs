using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public int menuScene;
    public int gameScene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void LoadMenuScene(){
        SceneManager.LoadScene(menuScene);
    }

    public void LoadGameScene(){
        SceneManager.LoadScene(gameScene);
    }
}
