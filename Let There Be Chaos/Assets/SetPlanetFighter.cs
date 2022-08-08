using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlanetFighter : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Planet", animator.GetComponentInParent<Planet>().PlanetIndex);
    }
}
