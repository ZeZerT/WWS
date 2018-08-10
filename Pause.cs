using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour{
    [SerializeField] private GameObject pausePanel;

    void Start(){
        pausePanel.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button9)) {
            if (!pausePanel.activeInHierarchy)  PauseGame();
            if (pausePanel.activeInHierarchy)   ContinueGame();   
        } 
     }
    private void PauseGame(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    } 
    private void ContinueGame(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}
