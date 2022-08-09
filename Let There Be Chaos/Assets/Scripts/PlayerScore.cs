using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float score = 0f;
    public GunShoot gunVars;                    // To access some variables
    public GameObject[] weapons;                // Storing the weapons prefab
    public int index = 0;                      // index of the current weapon
    
    // list containing score levels arranged descendingly
    // w 5alo 2a5er rakam zero 3lshan bst3mlo fy code tany (ScoreBar) xDD
    public float [] scoreIndex = {10000f,5000f, 3500f, 2000f, 400f, 100f, 0f};
    private enum WeaponState 
    {
        // el index htb2a btebda2 mn 0 lel sela7 el awl, w to3od tzeed kol ma nnzl ta7t
        // lw 3amlenha states kda, w geina fl nos n8ayar tarteeb el asle7a aw n7ot wa7ed zyada fl nos
        // hyb2a el ta8yeer ez, msh hn8ayar 7aga 8eir tarteeb el states 7rfyn, wl if conditions bta3t el scores. ez
        Arrow,
        Knife,
        Shuriken,           
        SpaceFire,
        Bomb,
        Rocket,
        Laser,
        Nuke,
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // el scores metrateba descendingly, 3lshan mnedtaresh n3ml check > w <, kfaya > bs
        if (score > scoreIndex[0])
        {
            // Debug.Log(scoreIndex[0]);
            // akwa weapon
            index = (int) WeaponState.Nuke;
            gunVars.attackRate = 3;
            // Debug.Log("3azama"); 
        }
        else if (score >= scoreIndex[1])
        {
            // tany akwa weapon
            index = (int) WeaponState.Laser;
            gunVars.attackRate = 4000;

        }
        else if (score >= scoreIndex[2])
        {
            // talet akwa weapon
            index = (int) WeaponState.Rocket;
            gunVars.attackRate = 2;

        }
        else if (score >= scoreIndex[3])
        {
            // rabe3 akwa weapon
            index = (int) WeaponState.Bomb;
            gunVars.attackRate = 2;

        }
        else if (score >= scoreIndex[4])
        {
            index = (int) WeaponState.SpaceFire;
            gunVars.attackRate = 2;

        }
        else if (score >= scoreIndex[5])
        {
            index = (int) WeaponState.Shuriken;
            gunVars.attackRate = 2;

        }
        else if (score >= scoreIndex[6])
        {
            index = (int) WeaponState.Knife;
            gunVars.attackRate = 2;

        }
        else
        {
            index = (int) WeaponState.Arrow;      // index el Arrow
            gunVars.attackRate = 2;
        }

        if (index > weapons.Length)     // 3lshan mygebsh error lw etla5batna w 7atena enums aktr mn el asle7a asln xD
        {
            index = weapons.Length - 1;
        }

        gunVars.shotType = weapons[index];        // 8ayar el prefab
        
    }
}
