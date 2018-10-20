using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScrpt : MonoBehaviour {

    public float MoveSpeed;
    public float SprintSpeed;
    public float JumpStrength;
    public float RayLength;
    public int HurtCount;
    public int DeathValue;
    private bool InputLock;
    private float VerticalVelocity;

    private Rigidbody2D CharRigid;
    public Animator CharAnim;
    private bool Sprint;
    private bool Isgrounded;

    // Ui Objects
    GameObject MenuBox;
    GameObject Canvas;
    GameObject MenuBTN;
    GameObject RestartBTN;
    GameObject WinnerTXT;
    GameObject MenuTXT;
    GameObject RestartTXT;


    // Use this for initialization
    void Start () {
        CharRigid = GetComponent<Rigidbody2D>();
        CharAnim = GetComponent<Animator>();
        HurtCount = 0;

        // Ui Stuff
        MenuBox = GameObject.Find("Menu Box");
        MenuBox.GetComponent<SpriteRenderer>().enabled = false;

        Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (InputLock == false)
        {
            // Sprinting/Movement
            if (Input.GetButtonDown("Fire3"))
            {
                CharAnim.SetBool("Sprinting", true);
                // Debug.Log("Sprinting aaaaaaaa");
                Sprint = true;
            }
            if (Input.GetButtonUp("Fire3"))
            {
                CharAnim.SetBool("Sprinting", false);
                // Debug.Log("Stop Sprinting aaaaaaaa");
                Sprint = false;
            }

            if (Sprint == true)
            {
                CharRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * SprintSpeed, CharRigid.velocity.y);
                CharAnim.SetFloat("MovementSpeed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                // Debug.Log("Sprinting");
            }
            else
            {
                CharRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, CharRigid.velocity.y);
                CharAnim.SetFloat("MovementSpeed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
            }

            // Jumping
            Isgrounded = Physics2D.Linecast(transform.position, transform.position + new Vector3(0, RayLength, 0), 1 << LayerMask.NameToLayer("Floor"));
            CharAnim.SetBool("Grounded", Isgrounded);

            if (Input.GetButtonDown("Jump"))
            {
                if (Isgrounded)
                {
                    CharRigid.AddForce(new Vector2(0, JumpStrength));
                    CharAnim.SetBool("Jumping", true);
                    SFXScrpt.AudioManager.PlaySFX("Jump");
                }
            }

            // Attacking
            if (Input.GetMouseButtonDown(1))
            {
                CharAnim.SetTrigger("Attacking");
                Debug.Log("Attacking");
                SFXScrpt.AudioManager.PlaySFX("Attack");
            }
        }
        // Hurting
        if (Input.GetButtonDown("Z"))
        {
            CharRigid.velocity = new Vector2(0, CharRigid.velocity.y);
            CharAnim.SetTrigger("Hurt");
            // Debug.Log("Sprinting aaaaaaaa");
            HurtCount++;
            
        }

        // Death
        if (HurtCount == DeathValue)
        {
            CharAnim.SetBool("Death", true);
            // Debug.Log("Death!!!!!!!!");

            // Show Hidden UI
            Canvas.GetComponent<Canvas>().enabled = true;
            MenuBox.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }

    public void PlayFootstep()
    {
        SFXScrpt.AudioManager.PlaySFX("Footstep");
        Debug.Log("Footstep");
    }

    private void LockInput()
    {
        InputLock = true;
    }

    private void UnlockInput()
    {
        InputLock = false;
    }

    private void FlipChar() // Makes char face the direction they're walking
    {
        if (CharRigid.velocity.x > 0 && transform.localScale.x < 0 || CharRigid.velocity.x < 0 && transform.localScale.x > 0)
        {
            Vector2 VEC = transform.localScale;
            VEC.x *= -1;
            transform.localScale = VEC;
        }
    }

    
}
