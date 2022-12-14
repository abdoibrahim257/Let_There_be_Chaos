using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float attackRate = 2f;       // y2dr y3ml kam attack fl sanya
    
    float nextAttackTime = 0f;
    public GameObject shotType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GeneralShoot()
    {
        // a-call el IGunType.Shoot();
        var obj = shotType.GetComponent<IGunType>();
        if (obj != null)
        {
            // Debug.Log("byedrab");
            obj.Shoot();
        }
        // Debug.Log(shotType.GetComponent<LineRenderer>());
        if (shotType.GetComponentInChildren<LineRenderer>() != null)
        {
            Debug.Log("Noice");
            // garab ta5od hena bool, w t3ml el check ta7t
            // aw e3ml ta7t !GetButton
            yield return new WaitForSeconds(0.1f);      // waits for a while before continuing
                                                        // 3lshan nel7a2 nshoof el laser
            if(!Input.GetButton("Fire1"))              // el laser hyefdal visible, le7ad ma ysheel 2eedo;
            {
                // Debug.Log("Noice");
                obj.DontShoot();      // kda el laser invisible
            }
        }
    }

    public void CallTheShots()
    {
        if (Time.time >= nextAttackTime)
        {
            StartCoroutine(GeneralShoot());
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}
