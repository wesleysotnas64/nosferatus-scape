using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private bool idle;
    private bool run;
    private bool jump;
    private bool dash;
    private Animator animator;
    private FootSensor sensor;
    private Player player;
    void Start()
    {
        animator = GetComponent<Animator>();
        sensor = transform.GetChild(0).GetComponent<FootSensor>();
        player = GetComponent<Player>();
    }

    
    void Update()
    {
        run = false;
        if(Input.GetKey(KeyCode.A) && transform.position.x > -player.xRange) run = true;
        if(Input.GetKey(KeyCode.D) && transform.position.x <  player.xRange) run = true;
        SetAnimationParameters();
        AnimationsControll();
    }

    private void SetAnimationParameters()
    {
        idle = !run;
        // jump = sensor.active == false;
        // if (jump)
        // {
        //     idle = false;
        //     run = false;
        // }
    }

    private void AnimationsControll()
    {


        animator.SetBool("idle", idle);
        animator.SetBool("run", run);
        animator.SetBool("jump", jump);
        animator.SetBool("dash", dash);
    }
}
