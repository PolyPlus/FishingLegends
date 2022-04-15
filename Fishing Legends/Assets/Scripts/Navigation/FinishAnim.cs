using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishAnim : StateMachineBehaviour
{
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("toRoute",false);
        Camera.main.transform.position = new Vector3(105 , 81, 51);
        Camera.main.transform.rotation = Quaternion.Euler(83, -90, 0);
        GameObject.Find("FlechaBote").SetActive(false);
        GameObject.Find("FlechaCasa").SetActive(false);
        GameObject.Find("ExitButton").SetActive(false);
        GameObject.Find("Grid").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("FlechaAbajo").GetComponent<Image>().enabled = true;
        GameObject.Find("FlechaDerecha").GetComponent<Image>().enabled = true;
        GameObject.Find("FlechaIzda").GetComponent<Image>().enabled = true;
        GameObject.Find("FlechaArriba").GetComponent<Image>().enabled = true;
        GameObject er = GameObject.Find("EmpezarRuta");
        GameObject dr = GameObject.Find("DeshacerRuta");
        GameObject br = GameObject.Find("InterfazResistencia");
        GameObject ba = GameObject.Find("BotonAtras");
        er.GetComponent<Image>().enabled = true;
        er.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        dr.GetComponent<Image>().enabled = true;
        dr.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        br.GetComponent<Image>().enabled = true;
        br.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        ba.GetComponent<Image>().enabled = true;
        ba.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
