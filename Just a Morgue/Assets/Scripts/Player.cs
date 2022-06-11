using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool facingRight = true;

    public Animator animator;

    public AudioSource JumpScareSFX;
    public AudioSource FootStep;
    public AudioSource ActionSFX;
    public AudioClip[] clips;

    public float Timer = 0.7f;
    public float TimerDown;

    public float speed = 1f;
    public bool alive = true;
    public bool stealth = false;
    public bool useStealth = false;

    public bool showE = false;

    public bool key = false;
    public bool takeKey = false;
    private bool takeSecondKey = false;

    public bool useLadder = false;
    private bool ladderUp = false;

    public bool useDoor = false;
    public bool secondUseDoor = false;

    public bool useSwitch = false;
    public bool secondUseSwitch = false;

    public bool useEscape = false;
    public bool endEscape = false;

    public bool useCrowbar = false;
    public bool secondUseCrowbar = false;

    public bool breakCrowbarBox = false;
    public bool secondBreakCrowbarBox = false;
    public bool crowbar = false;

    public bool takeHammer = false;
    public bool secondTakeHammer = false;
    public bool hammer = false;

    public float ScreamTimer = 2;
    public float ScreamTimerDown = 2;
    private bool secondUseScream = false;

    public static bool theEnd = false;

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;

    void Start()
    {
        Application.targetFrameRate = 30;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        E();
        Key();
        Crowbar();
        Hammer();

        if(alive == false)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.E))//взаимодействие, подбор предметов
        {
            ActionSFX.Play();
            if (useStealth == true)
            {
                stealth = !stealth;
                animator.SetBool("UseStealth", stealth);
            }
            else if (takeKey == true && takeSecondKey == false)
            {
                key = true;
                takeSecondKey = true;
            }
            else if (useLadder == true)
            {
                if (ladderUp == false)
                {
                    gameObject.transform.position += new Vector3(0, -4, 0);
                }
                else if (ladderUp == true)
                {
                    gameObject.transform.position += new Vector3(0, 4, 0);
                }
                ladderUp = !ladderUp;
            }
            else if (useDoor == true && secondUseDoor == false)
            {
                GameObject.Find("Block").SetActive(false);
                secondUseDoor = true;
            }
            else if (useSwitch == true && secondUseSwitch == false)
            {
                useEscape = true;
                secondUseSwitch = true;
            }
            else if (endEscape == true)
            {
                gameObject.transform.position += new Vector3(0, 0, 10000);
                SceneManager.LoadScene(3);
            }
            else if(useCrowbar == true && secondUseCrowbar == false && secondBreakCrowbarBox == true)
            {
                Destroy(GameObject.Find("Boxes"));
                secondUseCrowbar = false;
            }
            else if(breakCrowbarBox == true && secondBreakCrowbarBox == false)
            {
                secondBreakCrowbarBox = true;
            }
            else if (takeHammer == true && secondTakeHammer == false)
            {
                secondTakeHammer = true;
            }
        }

        if(HorizontalMove != 0)
        {
            MoveSounds();
        }

        if (stealth == false)
        {
            animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
            HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            speed = 0.2f;
        }
        else
        {
            speed = 0;
        }

        if (useStealth == false)
        {
            stealth = false;
        }

        if(HorizontalMove > 0 && facingRight)
        {
            Flip();
        }
        else if(HorizontalMove < 0 && !facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void CheckGround()//выталкивание персонажа из пола
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);
        if(colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void Death()
    {
        if(stealth == false)
        {
            alive = false;
            GameObject.Find("JumpScare").transform.position = GameObject.Find("Player").transform.position;
            GameObject.Find("JumpScare").transform.position += new Vector3(-3.5f, 2.29f, 0);
            if(secondUseScream == false)
            {
                Screamer();
            }
            if(ScreamTimerDown > 0)
            {
                ScreamTimerDown -= Time.deltaTime;
            }
            if (ScreamTimerDown < 0)
            {
                ScreamTimerDown = ScreamTimer;
                SceneManager.LoadScene(0);
            }
        }
    }
    //изучить как менять прозрачность объекта
    private void E()
    {
        if (showE == true)
        {
            GameObject.Find("EImage").transform.position = new Vector3(GameObject.Find("Canvas").transform.position.x + 3.8f, 
                GameObject.Find("Canvas").transform.position.y - 2, 0);
        }

        if(showE == false)
        {
            GameObject.Find("EImage").transform.position = new Vector3(0, 0, -10000);
        }
    }

    private void Key()
    {
        if (key == true)
        {
            GameObject.Find("KeyImage").transform.position = new Vector3(GameObject.Find("Canvas").transform.position.x + 3.8f,
                GameObject.Find("Canvas").transform.position.y + 2, 0);
        }

        if(key == false)
        {
            GameObject.Find("KeyImage").transform.position = new Vector3(0, 0, -10000);
        }
    }

    private void Crowbar()
    {
        if (crowbar == true)
        {
            GameObject.Find("CrowbarImage").transform.position = new Vector3(GameObject.Find("Canvas").transform.position.x + 2.8f,
                GameObject.Find("Canvas").transform.position.y + 2, 0);
        }

        if (crowbar == false)
        {
            GameObject.Find("CrowbarImage").transform.position = new Vector3(0, 0, -10000);
        }
    }

    private void Hammer()
    {
        if (hammer == true)
        {
            GameObject.Find("HammerImage").transform.position = new Vector3(GameObject.Find("Canvas").transform.position.x + 3.3f,
                GameObject.Find("Canvas").transform.position.y + 2, 0);
        }

        if (hammer == false)
        {
            GameObject.Find("HammerImage").transform.position = new Vector3(0, 0, -10000);
        }
    }

    public void MoveSounds()
    {
        if (TimerDown > 0)
        {
            TimerDown -= Time.deltaTime;
        }
        if (TimerDown < 0)
        {
            FootStep.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            TimerDown = Timer;
        }
    }

    public void Screamer()
    {
        JumpScareSFX.Play();
        secondUseScream = true;
    }
}
