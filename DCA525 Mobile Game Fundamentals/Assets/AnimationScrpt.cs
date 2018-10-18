using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScrpt : MonoBehaviour {

    public float MoveSpeed;
    public float JumpStrength;
    public float RayLength;

    private Rigidbody2D CharRigid;
    private Animator CharAnim;

    // Use this for initialization
    void Start () {
        CharRigid = GetComponent<Rigidbody2D>();
        CharAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        CharRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, CharRigid.velocity.y);
        CharAnim.SetFloat("MovementSpeed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        if (Input.GetButtonDown("Jump"))
        {
            if (Physics2D.Linecast(transform.position,
                transform.position + new Vector3(0, RayLength, 0),
                1 << LayerMask.NameToLayer("Floor")))
            {
                CharRigid.AddForce(new Vector2(0, JumpStrength));
                // AudioManager.AnimAudioManager.PlaySFX("Jump");
            }
        }
    }
}
