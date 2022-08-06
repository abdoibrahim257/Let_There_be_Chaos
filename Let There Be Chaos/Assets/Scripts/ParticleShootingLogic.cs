using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShootingLogic : MonoBehaviour, IGunType
{
    // public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;         // sor3et el bullet
    // 1.25 for enemies, 2 for player
    
    // public float damage = 5f;                 // dyh lel player bs
    // bta3t el enemy m7toota gowa el EnemyParticleShot.cs (gowa el particle nafsaha)


    public int numBullets = 3;                // htedrab kam bullet fl mara
    Vector3 disposition = new Vector3(0f,5f,0f);
    // momkn a3mlha for loop ez gowa el Shoot(), kol mara y-spawn wa7da fy makan shifted 3n el ableeha b value mo3yna / 3adadhom
    // kda kol ma 3adadhom yzeed, el value dyh ht2el, l2n el denominator b2a akbar
    // kinda like, float value = 18/NumBullets mthln;
    // 5ly awl bullet fl nos kda w kda, b3dein spawn fo2eeha bl msafa, b3dein t7teeha bl msafa, b3dein fo2eeha, w hakaza
    // e.g, lw el msafa = satr

    // 4            (dlw2ty ba2et arb3 stoor le ta7t)
    // 2            (dlw2ty ba2et satrein le ta7t)
    // 1            (dlw2ty el msafa ba2et = satr le fo2)
    // 3            (dlw2ty ba2et tlat stoor le fo2)
    // 5            (w hakaza ba2a, el mra el gya hatla3 6 le fo2)

    // la7ez en kol mara, el msafa btzeed 3n el ableeha b satr wa7ed bs, fa el implementation sahl y3ny

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        // Debug.Log("Enemy byedrab");
        // Debug.Log(this.GetComponent<Transform>().position);
        // Debug.Log(firePoint.position);
        int sign = 1;       // 3lshan yb2a mara fo2 w mara ta7t
        for (int i = 0; i < numBullets; i++)
        {
            sign *= -1;         // change sign of disposition
            GameObject bullet = Instantiate(bulletPrefab, this.GetComponent<Transform>().position + (sign * i * disposition / numBullets), this.GetComponent<Transform>().rotation);
            // bn3ml object mn el bulletPrefab el 7atenaha, fl position dh, bl rotation dyh
            // w bn5azeno fy variable
            
            // bs e7na 3ayzeen n-access el rigidbody bta3 el bullet, fa hnst3ml getcomponent
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();    // bn5azen el rigidbody
            // hndeelo force b2a
            rb.AddForce(this.GetComponent<Transform>().right * bulletForce, ForceMode2D.Impulse);
            // ba7aded el direction w no3 el force
        }
            
    }
    public void DontShoot() {}
}