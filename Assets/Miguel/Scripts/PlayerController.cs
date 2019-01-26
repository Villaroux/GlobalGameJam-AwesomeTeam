using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animatorController;

    public float speed = 2.0f;
    [Header("Dash Settings")]
    public KeyCode dashKey;
    public float dashSpeed = 5.0f;
    public float dashCD = 0.0f;
    float dashTimer;
    public bool IsDashActivated = false;
    bool dashTimerSetup = false;
    [Header("Block Settings")]
    public KeyCode blockKey;
    public bool IsBlockActivated = false;
    bool blockTimerSetup = true;
    public float blockCD = 0.0f;
    float blockTimer;




    void Awake()
    {
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        DashTimer();
        BlockTimer();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        //Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        //Animations
        animatorController.SetFloat("velocity", movement.magnitude * speed);
        if (Input.GetKeyDown(dashKey) &&  Time.time - dashTimer > dashCD)
        {
            transform.position = transform.position + movement * dashSpeed * Time.deltaTime;
            dashTimerSetup = true;
        }
        if(Input.GetKeyDown(blockKey) && Time.time - blockTimer > blockCD)
        {
            animatorController.SetTrigger("Block");
            blockTimerSetup = true;
        }
    }
    void BlockTimer()
    {
        if (blockTimerSetup)
        {
            blockTimer = Time.time;
            blockTimerSetup = false;
        }
    }
    void DashTimer()
    {
        if (dashTimerSetup)
        {
            dashTimer = Time.time;
            dashTimerSetup = false;
        }
    }
}
