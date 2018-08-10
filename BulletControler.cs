using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour {

    public float speed;
    public float lifetime;
    public int damateToGive;
    public Enums.ColorSelector colorSelector;

    MeshRenderer meshRenderer;

    // Use this for initialization
    void Start () {
	}

    internal void setColor(Enums.ColorSelector colorSelector) {
        this.colorSelector=colorSelector;
    }

    // Update is called once per frame
    void Update () {
        
        meshRenderer = GetComponent<MeshRenderer>();
        Color selectedColor = new Color();
        switch(colorSelector) {
            case Enums.ColorSelector.Blue   : selectedColor = Color.blue;   break;
            case Enums.ColorSelector.Green  : selectedColor = Color.green;  break;
            case Enums.ColorSelector.Yellow : selectedColor = Color.yellow; break;
            case Enums.ColorSelector.Red    : selectedColor = Color.red;    break;
            default                         : selectedColor = Color.red;    break;
        }
        meshRenderer.material.color = selectedColor;

	    transform.Translate(Vector3.forward *speed *Time.deltaTime);

        lifetime -= Time.deltaTime;
        if(lifetime <=0) Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy") {
            if(other.gameObject.GetComponent<EnemyControler>().GetColor() == ButtonColorControler.GetLastPressedColor()){
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damateToGive);
            }
            Destroy(gameObject);
        }
    }
}