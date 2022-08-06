using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, IGunType
{
    public LayerMask layerMask;
    public float Range = 50f;
    public Camera cam;
    public Transform Eye1;
    public Transform Eye2;
    public Transform FirePoint;
    public LineRenderer lineRenderer1;
    public GameObject LaserImpact1;
    public LineRenderer lineRenderer2;
    public GameObject LaserImpact2;
    //public GameObject LaserImpact2;
    float enemyDamage;
    // bool TemporaryUpgrade;
    // float TimeSinceUpgrade;.
    
    void Start()
    {
        // enemyDamage = 0.15f;
        lineRenderer1.widthMultiplier = 0.5f;
        lineRenderer2.widthMultiplier = 0.5f;
    }
    private void Update()
    {
        // if (Input.GetMouseButton(0))
        //     Shoot();
        // if(Input.GetMouseButtonUp(0))
        //     DontShoot();
        // if(GetTemp() && (Time.time - TimeSinceUpgrade >= 5f))
        // {
        //     //revert changes
        //     lineRenderer.widthMultiplier=0.5f;
        //     DecreaseEnemyDamage();
        // }
    }
    public void Shoot()
    {
        //Debug.Log("LASER INCOMMING");
        // Debug.Log(lineRenderer.widthMultiplier);
    
        lineRenderer1.enabled = true;
        lineRenderer2.enabled = true;

        //here i made another transform which is a general one to determine mouse position
        var mousePosition = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)FirePoint.position;
        //Debug.Log(direction.magnitude);

        //these following lines is for making laser shoot from the first eye
        lineRenderer1.SetPosition(0, Eye1.position);
        lineRenderer1.SetPosition(1, (Vector2)Eye1.position+ direction.normalized * Range);
        RaycastHit2D hit1 = Physics2D.CircleCast(Eye1.position, lineRenderer1.widthMultiplier / 2, direction, Range, layerMask); //check if something hit first laser

        // now to make the cow shoot from the other eye
        lineRenderer2.SetPosition(0, Eye2.position);
        lineRenderer2.SetPosition(1, (Vector2)Eye2.position+ direction.normalized * Range);
        RaycastHit2D hit2 = Physics2D.CircleCast(Eye2.position, lineRenderer2.widthMultiplier / 2, direction, Range, layerMask); //check if something hit second laser
        // RaycastHit2D hit1 = hit2;
        //now suppose that there are two laser rays are coming from th eyes let us check if something hit either of them

        if(hit1 || hit2)
        {
            //here means either of the lines got hit now to make there size till the object that got hit
            if(hit1 && !hit2)
            {
                lineRenderer1.SetPosition(1, hit1.point);
                //playe animation of particle system
                LaserImpact1.GetComponent<ParticleSystem>().Play();
                LaserImpact1.transform.position = lineRenderer1.GetPosition(1);
                //apply damage
                if(hit1.collider.GetComponent<HealthSystem>())
                {
                    hit1.collider.GetComponent<HealthSystem>().health-=0.35f;
                }
            }
            else if(!hit1 && hit2)
            {
                lineRenderer2.SetPosition(1,hit2.point);
                //play the animation of particle hit
                LaserImpact2.GetComponent<ParticleSystem>().Play();
                LaserImpact2.transform.position = lineRenderer2.GetPosition(1);
                //apply damage
                if(hit2.collider.GetComponent<HealthSystem>())
                {
                    hit2.collider.GetComponent<HealthSystem>().health-=0.35f;
                }
            }
            else if(hit1 && hit2)
            {
                lineRenderer1.SetPosition(1, hit1.point);
                lineRenderer2.SetPosition(1,hit2.point);
                //playe both line renderer animation
                LaserImpact1.GetComponent<ParticleSystem>().Play();
                LaserImpact1.transform.position = lineRenderer1.GetPosition(1);
                LaserImpact2.GetComponent<ParticleSystem>().Play();
                LaserImpact2.transform.position = lineRenderer2.GetPosition(1);
                //apply damage
                if(hit1.collider.GetComponent<HealthSystem>())
                {
                    hit1.collider.GetComponent<HealthSystem>().health-=0.35f;
                }
            }

        }
    }

    public void DontShoot()
    {
        lineRenderer1.enabled = false;
        lineRenderer2.enabled = false;
        Debug.Log("no Laser");
    }

    //these following lines is for making weapon upgrades


    // public void IncreaseEnemyDamage()
    // {
    //     enemyDamage*=10;
    // }
    // void DecreaseEnemyDamage()
    // {
    //     enemyDamage=0.15f;
    // }
    // public void Temp(bool temp)
    // {
    //     TemporaryUpgrade = temp;
    // }
    // bool GetTemp()
    // {
    //     return TemporaryUpgrade;
    // }
    // public void SetTimeSinceUpgrade(float time)
    // {
    //     TimeSinceUpgrade = time;
    // }
}

    //these lines is for backup reasons

        // if (hit)
        // {
        //     // Debug.Log(hit.collider.tag);
        //     if(hit.collider.CompareTag("wall"))
        //     { 
        //         //do nothing
        //         LaserImpact.GetComponent<ParticleSystem>().Play();
        //         lineRenderer.SetPosition(1, hit.point);
        //         LaserImpact.transform.position = lineRenderer.GetPosition(1);
        //         // Debug.Log("Hit a wall");
        //     }
        //     else if(hit.collider.CompareTag("Enemy"))
        //     {
        //         //Debug.Log(hit.collider.tag);
        //         LaserImpact.GetComponent<ParticleSystem>().Play();
        //         lineRenderer.SetPosition(1, hit.point);
        //         LaserImpact.transform.position = lineRenderer.GetPosition(1);
        //         if(hit.collider.GetComponent<HealthScript>()) //IF SCRIPT EXITS ON THE ENEMY
        //         {
        //             Debug.Log(enemyDamage);
        //             hit.collider.GetComponent<HealthScript>().TakeDamage(enemyDamage);
        //         }
        //     }
        // }
        // else
        // {
        //     Debug.Log("Not Hit");
        // }