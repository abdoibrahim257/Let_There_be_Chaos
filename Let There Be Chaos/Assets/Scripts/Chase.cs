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


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindWithTag("Player").transform;
       Gun = animator.GetComponentInChildren<GunShoot>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.up = player.position - animator.transform.position;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, ChaseSpeed * Time.deltaTime);

        
        // Gun.CallTheShots();
        
        StopChase(animator);
        AttackControl();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
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
