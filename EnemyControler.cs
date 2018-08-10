using System;
using UnityEngine;

public class EnemyControler : MonoBehaviour {

    public float moveSpeed;
    public PlayerControler thePlayer;
    public int MobID { get; set; }
    public Enums.ColorSelector colorSelector;

    public WaveControler Wave { get; set; }
    private Rigidbody myRB;

    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerControler>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(thePlayer.transform.position);
	}

    private void FixedUpdate() {
        myRB.velocity = (transform.forward *moveSpeed);
    }
    
    private void OnDestroy() {
        Wave.EnemyDied(MobID);
    }

    public override string ToString(){
        return String.Format("ID : "+ MobID + " -- Color : "+colorSelector);
    }

    public Enums.ColorSelector GetColor() {
        return colorSelector;
    }
}