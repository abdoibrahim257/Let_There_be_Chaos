using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static Sprite Fighter1;
    public static Sprite Fighter2;
    public static Sprite Fighter3;
    public static Sprite Fighter4;
    static SpriteRenderer Sr;

    void Start()
    {
        Fighter1 = Resources.Load<Sprite>("Fighter1");
        Fighter2 = Resources.Load<Sprite>("Fighter2");
        Fighter3 = Resources.Load<Sprite>("Fighter3");
        Fighter4 = Resources.Load<Sprite>("Fighter4");
        Sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    //to call the function look at patrol.cs 
    public static void SwitchSprite(string spriteName) //pass the string as in switch cases
    {
        switch (spriteName)
        {
            case "Fighter1":
                Debug.Log("Switched to Fighter1");
                Sr.sprite = Fighter1;
                break;
            case "Fighter2":
                Debug.Log("Switched to Fighter2");
                Sr.sprite = Fighter2;
                break;
            case "Fighter3":
                Debug.Log("Switched to Fighter3");
                Sr.sprite = Fighter3;
                break;
            case "Fighter4":
                Debug.Log("Switched to Fighter4");
                Sr.sprite = Fighter4;
                break;
        }
    }

}