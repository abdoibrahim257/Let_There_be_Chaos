using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
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
        if (shotType.GetComponent<LineRenderer>() != null)
        {
            // garab ta5od hena bool, w t3ml el check ta7t
            // aw e3ml ta7t !GetButton
            yield return new WaitForSeconds(0.1f);      // waits for a while before continuing
                                                        // 3lshan nel7a2 nshoof el laser
            if(!Input.GetButton("Fire1"))              // el laser hyefdal visible, le7ad ma ysheel 2eedo;
            {
                // Debug.Log("Noice");
            shotType.GetComponent<LineRenderer>().enabled = false;       // kda el laser invisible
            }
        }
    }

    public void CallTheShots()
    {
        StartCoroutine(GeneralShoot());
    }
}
