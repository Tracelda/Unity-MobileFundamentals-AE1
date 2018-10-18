using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScrpt : MonoBehaviour {

    public float MoveSpeed;
    public float JumpStrength;
    public float RayLength;

    private Rigidbody2D CharRigid;
    public Animator CharAnim;
    bool Sprint;

    // Use this for initialization
    void Start () {
        CharRigid = GetComponent<Rigidbody2D>();
        CharAnim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Sprint = true;

            if (Input.GetButtonUp("Fire3"))
            {
                Sprint = false;
            }
        }
        else
            Sprint = false;

        if (Sprint == true)
        {
            CharRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed + 2, CharRigid.velocity.y);
            CharAnim.SetFloat("MovementSpeed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
            Debug.Log("Sprinting");
        }
        else
        {
            CharRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, CharRigid.velocity.y);
            CharAnim.SetFloat("MovementSpeed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (Physics2D.Linecast(transform.position,transform.position + new Vector3(0, RayLength, 0),1 << LayerMask.NameToLayer("Floor")))
            {
                CharRigid.AddForce(new Vector2(0, JumpStrength));
                CharAnim.SetBool("Jumping", true);
                SFXScrpt.AudioManager.PlaySFX("Jump");
            }
        }

        if(Input.GetMouseButtonDown(1)) // attack
        {
            CharAnim.SetBool("Attacking", true);
            SFXScrpt.AudioManager.PlaySFX("Jump");
            Debug.Log("Attacking");
        }

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
