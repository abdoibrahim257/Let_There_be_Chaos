using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWeapon : MonoBehaviour
{
    public PlayerScore playerVars;
    private Sprite nextWeapon;
    public Sprite laserSprite;
    static Image Sr;
    // Start is called before the first frame update
    void Start()
    {
        Sr = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"index: {playerVars.index}, weapon length: {playerVars.weapons.Length}");
        if(playerVars.index + 1 >= playerVars.weapons.Length)   // y3ny wesel 2a5er weapon 5las
        {
            if (playerVars.weapons[playerVars.index].GetComponent<ParticleShootingLogic>() != null) // lw howa particle
            {
                Debug.Log("La2eit particle 1");
                nextWeapon = playerVars.weapons[playerVars.index].GetComponent<ParticleShootingLogic>().bulletPrefab.GetComponent<SpriteRenderer>().sprite;   
            }
            else
            {
                Debug.Log("La2eit laser 1");
                nextWeapon = laserSprite;
            }

        }
        else        // hat sprite el level el b3do
        {
            if (playerVars.weapons[playerVars.index + 1].GetComponent<ParticleShootingLogic>() != null) // lw howa particle
            {
                Debug.Log("La2eit particle 2");
                nextWeapon = playerVars.weapons[playerVars.index + 1].GetComponent<ParticleShootingLogic>().bulletPrefab.GetComponent<SpriteRenderer>().sprite;           
            }
            else
            {
                Debug.Log("La2eit laser 2");
                nextWeapon = laserSprite;
            }
        }
        Sr.sprite = nextWeapon;

    }
}
