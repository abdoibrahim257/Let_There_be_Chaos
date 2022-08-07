using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour
{
    [SerializeField] public float PatrolSpeed;
    public Vector2 origin;
    Vector2 movespot;
    [SerializeField] public float moveradius;
    [SerializeField] public float DetectRadius;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //ex on using sprite manager
        SpriteManager.SwitchSprite("Fighter3"); //here it can be fighter1,2,3,4 and it will switch to them
        origin = animator.transform.position;
        movespot = origin + (Random.insideUnitCircle * moveradius);
        Physics2D.queriesStartInColliders = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.up = movespot - (Vector2)animator.transform.position;
        
        if (CheckPath(animator.transform) && Vector2.Distance(animator.transform.position, movespot) > 0.2f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, movespot, PatrolSpeed * Time.deltaTime);
        }
        else
        movespot = origin + (Random.insideUnitCircle * moveradius);

        CheckNearby(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    bool CheckPath(Transform pos)
    {
        float distance = moveradius - Vector2.Distance(pos.position, origin);
        RaycastHit2D hit = Physics2D.Raycast(pos.position, pos.up, distance);
        if (!hit)
        return true;
        else
        {
            Debug.Log(hit.point);
            return false;
        }
    }

    void CheckNearby(Animator animator)
    {
        Collider2D hit = Physics2D.OverlapCircle(animator.transform.position, DetectRadius, LayerMask.GetMask("Kaw"));
        if (hit)
        {
            animator.SetBool("Chase", true);
        }
    }
}
