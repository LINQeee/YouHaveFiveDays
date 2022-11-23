using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationManager : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void horizontalCheck()
    {
        switch (Input.GetAxis("Horizontal"))
        {
            case < 0:
                animator.SetInteger("leftRightTrigger", -1);
                break;
            case 0:
                animator.SetInteger("leftRightTrigger", 0);
                break;
            case > 0:
                animator.SetInteger("leftRightTrigger", 1);
                break;
        }
    }
    private void verticalCheck()
    {
        switch (Input.GetAxis("Vertical"))
        {
            case < 0:
                animator.SetInteger("forwardBackTrigger", -1);
                break;
            case 0:
                animator.SetInteger("forwardBackTrigger", 0);
                break;
            case > 0:
                animator.SetInteger("forwardBackTrigger", 1);
                break;
        }
    }
    void Update()
    {

        InvokeRepeating("horizontalCheck", 0, 0.01f);
        InvokeRepeating("verticalCheck", 0, 0.01f);
        /*  if (Input.GetAxis("Horizontal") == 0) animator.SetInteger("leftRightTrigger", 0);

          else if(Input.GetAxis("Horizontal") < 0) animator.SetInteger("leftRightTrigger", -1);

          else animator.SetInteger("leftRightTrigger", 1);

          if (Input.GetAxis("Vertical") == 0) animator.SetInteger("forwardBackTrigger", 0);

          else if (Input.GetAxis("Vertical") < 0) animator.SetInteger("forwardBackTrigger", -1);

          else animator.SetInteger("forwardBackTrigger", 1);*/
    }
}
