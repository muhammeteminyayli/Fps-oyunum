using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inGame;
    private bool check;
    
    void Start(){
        pauseMenu.SetActive(false);
        inGame.SetActive(true);
        check=false;
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        inGame.SetActive(true);
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        check=false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)){
            check=!check;
            Cursor.visible=check;
            switch(check){
                case true:
                Cursor.lockState=CursorLockMode.None;
                break;
                case false:
                Cursor.lockState=CursorLockMode.Locked;
                break;
            }
            pauseMenu.SetActive(check);
            inGame.SetActive(!check);
        }
    }
}
