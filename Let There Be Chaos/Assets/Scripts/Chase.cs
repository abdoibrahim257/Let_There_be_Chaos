using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chase : StateMachineBehaviour
{
    private Transform player;
    [SerializeField] public float ChaseSpeed;
    [SerializeField] public float StopChaseTimer;
    private float timer = 0;
    private float attacktimer = 0;
    [SerializeField] public float ExitDetectRadius;
    private GunShoot Gun;
    private int randomdirection;
    private float randomspeed;
    private int[] arr = {-1, 1};


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpriteManager.SwitchSprite("Fighter3");
        player = GameObject.FindWithTag("Player").transform;
        Gun = animator.GetComponentInChildren<GunShoot>();

        randomspeed = Random.Range(30f, 100f);
        randomdirection = Random.Range(0,2);

        animator.GetComponents<AudioSource>()[0].Play();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.up = player.position - animator.transform.position;

        if (Vector2.Distance(player.position, animator.transform.position) > 30)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, ChaseSpeed * Time.deltaTime);
        }
        else
        {
            animator.transform.RotateAround(player.position, new Vector3(0, 0, 1), arr[randomdirection] * randomspeed * Time.deltaTime);
        }
        Debug.Log(Vector2.Distance(player.position, animator.transform.position));

        
        // Gun.CallTheShots();
        
        StopChase(animator);
        AttackControl();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.GetComponents<AudioSource>()[0].Stop();
    }

    void StopChase(Animator animator)
    {
        Collider2D hit = Physics2D.OverlapCircle(animator.transform.position, ExitDetectRadius, LayerMask.GetMask("Kaw"));
        if (!hit)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        if (timer >= StopChaseTimer)
        {
            timer = 0;
            attacktimer = 0;
            animator.SetBool("Chase", false);
        }
    }


    void AttackControl()
    {
        attacktimer += Time.deltaTime;

        if (attacktimer >= 4)
        {
            Gun.CallTheShots();
            //Attack.Invoke();
            Debug.Log("fire");
            if (attacktimer >= 6)
            {
                // gunc.StopFire();
                attacktimer = 0;
            }
        }
    }
}
