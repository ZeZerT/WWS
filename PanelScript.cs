using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {

    public GameObject Panel;
    bool onoff;

	// Use this for initialization
    void Start(){
        onoff = false;
        Panel.SetActive(onoff);
    }

    void Update(){
        if(Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button9)) {
            DecideShowHide();
        } 
    }
    private void DecideShowHide() {
        if (!Panel.activeInHierarchy) PauseGame();
        else ContinueGame();
        Panel.SetActive(onoff); 
    }


    private void PauseGame(){
        Time.timeScale = 0.0F;
        onoff=true;
        //Disable scripts that still work while timescale is set to 0
    } 
    private void ContinueGame(){
        Time.timeScale = 1.0F;
        onoff = false;
        //enable the scripts again
    }

	public void ShowhidePanel() {
        onoff = !onoff;
        DecideShowHide();
    }
}
