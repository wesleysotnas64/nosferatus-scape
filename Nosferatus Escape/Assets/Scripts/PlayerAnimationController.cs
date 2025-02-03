using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private bool idle;
    private bool run;
    private bool jump;
    private bool dash;
    private Animator animator;
    private FootSensor sensor;
    private PlayerMovement player;
    void Start()
    {
        animator = GetComponent<Animator>();
        sensor = transform.GetChild(0).GetComponent<FootSensor>();
        player = GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        SetAnimationParameters();
        AnimationsControll();
    }

    private void SetAnimationParameters()
    {
        run = false;
        if(Input.GetKey(KeyCode.A) && transform.position.x > -player.xRange) run = true;
        if(Input.GetKey(KeyCode.D) && transform.position.x <  player.xRange) run = true;
        idle = !run;

        jump = sensor.active == false;
        if (jump)
        {
            idle = false;
            run = false;
        }

        dash = player.inDash;
        if(dash)
        {
            idle = false;
            run = false;
            jump = false;
        }
    }

    private void AnimationsControll()
    {
        animator.SetBool("idle", idle);
        animator.SetBool("run", run);
        animator.SetBool("jump", jump);
        animator.SetBool("dash", dash);
    }
}
