using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControler : MonoBehaviour {
    
    public bool isFiring;
    public BulletControler bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    public Transform firePoint;

    private float shotCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isFiring) {
            shotCounter -= Time.deltaTime;
            if(shotCounter <=0) {
                shotCounter = timeBetweenShots; //reset to full value
                BulletControler newBullet;
                newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletControler;
                newBullet.setColor(ButtonColorControler.GetLastPressedColor());
            }
        } else {
            shotCounter = 0;
        }
	}
}
