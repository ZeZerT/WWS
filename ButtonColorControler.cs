using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColorControler : MonoBehaviour {
    
    public BulletControler bullet;
    public Enums.ColorSelector colorSelector;
    static Enums.ColorSelector lastPressed;

    void Start() {
        Debug("My color is "+colorSelector);
    }

    public void ButtonInterract() {
        bullet.colorSelector = colorSelector;
        lastPressed = colorSelector;
        Debug("Bullet's color set to "+colorSelector);
    }

    public static Enums.ColorSelector GetLastPressedColor() {
        return lastPressed;
    }
    /*
    public static void SetLastPressedColor(Enums.ColorSelector color) {
        lastPressed = color;
    }*/

    private void Debug(string txt) {
        bool trueToDisplay = false;
        if(trueToDisplay) print(txt);
    }
}
