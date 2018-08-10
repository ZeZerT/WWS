using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

    public float moveSpeed;
    public GunControler theGun;
    public bool useController;
    public GameObject[] buttons;
    public Button buttonR;
    public Button buttonG;
    public Button buttonB;
    public Button buttonY;

    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

        buttons = GameObject.FindGameObjectsWithTag("buttonColor");
        foreach (GameObject i in buttons){
                 if(i.name == "ButtonRed")      buttonR = i.GetComponent<Button>();
            else if(i.name == "ButtonGreen")    buttonG = i.GetComponent<Button>();
            else if(i.name == "ButtonBlue")     buttonB = i.GetComponent<Button>();
            else if(i.name == "ButtonYellow")   buttonY = i.GetComponent<Button>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Rotate with mouse
        if(!useController){
            Ray cameraRay =  mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if(groundPlane.Raycast(cameraRay, out rayLength)) {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
            
            // 0 left click, 1 right click, ...
            if(Input.GetMouseButtonDown(0)) theGun.isFiring = true;
            if(Input.GetMouseButtonUp(0))   theGun.isFiring = false;
        }

        //Rotate with controller
        if(useController) {
            Vector3 playerDirection = Vector3.right *Input.GetAxisRaw("RHorizontal") + Vector3.forward *-Input.GetAxisRaw("RVertical");
            if(playerDirection.sqrMagnitude > 0.0f) { //if player is facing any direction
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
            
            //xBox One controler settings
                 if(Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetAxisRaw("DPadVertical")   <0)    buttonG.onClick.Invoke();   //A || DPadDown
            else if(Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetAxisRaw("DPadHorizontal") >0)    buttonR.onClick.Invoke();   //B || DPadRight
            else if(Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetAxisRaw("DPadHorizontal") <0)    buttonB.onClick.Invoke();   //X || DPadLeft
            else if(Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetAxisRaw("DPadVertical")   >0)    buttonY.onClick.Invoke();   //Y || DPadUp
            else if(Input.GetKeyDown(KeyCode.Joystick1Button5))  theGun.isFiring =true;  //RB
            else if(Input.GetKeyUp(KeyCode.Joystick1Button5))    theGun.isFiring =false; //RB
        }
	}

    private void FixedUpdate() {
        myRigidbody.velocity = moveVelocity;
    }
}
