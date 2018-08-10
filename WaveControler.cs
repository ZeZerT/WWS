using System.Collections.Generic;
using UnityEngine;

public class WaveControler : MonoBehaviour {

    public EnemyControler enemyRed;
    public EnemyControler enemyYellow;
    public EnemyControler enemyGreen;
    public EnemyControler enemyBlue;
    public Transform spawnLocation;

    private EnemyControler newEnemy;
    private int waveNumber, mobID;
    private Dictionary<int, EnemyControler> remainingMobs = new Dictionary<int, EnemyControler>();

	public void Start () {
		waveNumber =0;
        mobID=0;
        Spawn();
	}
	
	public void Update () {        
        if(AllEnemiesDead()) {
            Debug("GO TO NEXT WAVE");
            GoToNextWave();
            Spawn(); 
        } else {
            DisplayRemainingMobs();
        }
	}

    public void Spawn() {
        Debug("Wave #"+waveNumber);
        int amountOfMobsToSpawn = waveNumber;
        for(int i=0; i<amountOfMobsToSpawn; i++) {
            Enums.ColorSelector colorSelector;
            EnemyControler enemy;
            mobID++;

            switch(mobID%4) {
                case 0 : enemy = enemyBlue;     colorSelector = Enums.ColorSelector.Blue;      break;
                case 1 : enemy = enemyGreen;    colorSelector = Enums.ColorSelector.Green;     break;
                case 2 : enemy = enemyYellow;   colorSelector = Enums.ColorSelector.Yellow;    break;
                case 3 : enemy = enemyRed;      colorSelector = Enums.ColorSelector.Red;       break;
                default: enemy = null;          colorSelector = Enums.ColorSelector.Red;       break;
            }

            if(enemy!=null) {
                newEnemy = Instantiate(enemy, spawnLocation.position, spawnLocation.rotation) as EnemyControler;
                newEnemy.MobID= mobID;
                newEnemy.Wave=this;
                newEnemy.colorSelector = colorSelector;
                Debug("Spawned : " +newEnemy.ToString());
                remainingMobs.Add(newEnemy.MobID, newEnemy);
            } else {
                print("Error occured : x %4 was neither 0, 1, 2 or 3 ???");
            }

        }
    }
    
    public void GoToNextWave() {
        Debug("Wave "+waveNumber+" completed.");
        waveNumber++;
    }
    
    public void EnemyDied(int someID) {
        if(remainingMobs.Remove(someID)) {
            Debug("Removed "+someID.ToString());
        } else {
            Debug("Failed to remove " + someID.ToString());
            DisplayRemainingMobs();
        }
    }
    
    public bool AllEnemiesDead() {
        return remainingMobs.Count==0;
    }

    public void DisplayRemainingMobs() {
        string availableKeys="";
        foreach (KeyValuePair<int, EnemyControler> pair in remainingMobs){
            availableKeys+= pair.Key + ", ";
        }
        Debug(remainingMobs.Keys.Count + " are available : " + availableKeys);
    }

    private void Debug(string txt) {
        bool trueToDisplay = false;
        if(trueToDisplay) print(txt);
    }
}
