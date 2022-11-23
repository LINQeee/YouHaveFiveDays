using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]

public class playerMovement : MonoBehaviour
{
    public static bool isInHouse = false;
    [SerializeField] private float speed = 3;
    [SerializeField] private GameObject player;
    Animator animator;
    [SerializeField] private AudioClip stepSound0, stepSound1, stepSound2;
    [SerializeField] private AudioClip floorStepSound;
    [SerializeField] float a;
    [SerializeField] float b;
    private Vector3 moveDefaultValue;
    private Vector3 move;
    private List<AudioClip> listOfRoadSteps;
    private float cooldownForSound = 0.5f;
    private bool isShifting = false;


    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        listOfRoadSteps = new List<AudioClip>
    {
        stepSound0, stepSound1, stepSound2
    };
    }

    private void Update()
    {
        a = animator.GetInteger("forwardBackTrigger");
        b = animator.GetInteger("leftRightTrigger");
        Vector3 currentPos = transform.position;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isShifting = true;
            speed = 6; cooldownForSound = 0.35f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isShifting = false;
            speed = 3; cooldownForSound = 0.5f;
        }


        moveDefaultValue = new Vector3(0, -speed, 0);
        float posX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float posZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        move = new Vector3(posX, -speed, posZ);

        move = Vector3.ClampMagnitude(move, speed);

        move = transform.TransformDirection(move);

        characterController.Move(move);

        

        if (move != moveDefaultValue && currentPos != transform.position)
        {
            if (isShifting)
            {
                animator.SetFloat("animSpeed", 1);
            }
            else animator.SetFloat("animSpeed", 0.5f);
            


              cooldownForSound -= Time.deltaTime;


            if (cooldownForSound < 0)
            {
                cooldownForSound = isShifting ? 0.35f : 0.5f;
                if (!isInHouse) GetComponent<AudioSource>().PlayOneShot(listOfRoadSteps[new System.Random().Next(3)]);
                else GetComponent<AudioSource>().PlayOneShot(floorStepSound);
            }
            animator.speed = 2;
        }
        else animator.speed = 1;

    }
}
