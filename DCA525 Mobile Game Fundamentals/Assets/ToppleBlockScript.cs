using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppleBlockScript : MonoBehaviour
{
    private Vector3 mouselocation;
    public bool Moving;
    bool PickedUp;
    bool Moved;
    public GameObject ToppleBox;
    Rigidbody2D Rigid;
    public GameObject woodBlock;
    public Rigidbody2D WoodRigid;
    public Rigidbody2D MetalRigid;
    public Rigidbody2D TheBoxRigid;
    private object ToppleBoxJoint;
    bool colliding;

    // Use this for initialization
    void Start()
    {
        Moving = false;
        PickedUp = false;
        Moved = false;

        Rigid = GetComponent<Rigidbody2D>();

        woodBlock = GameObject.Find("WoodBlock");
        WoodRigid = woodBlock.GetComponent<Rigidbody2D>();

        MetalRigid = GameObject.Find("MetalBlock").GetComponent<Rigidbody2D>();

        TheBoxRigid = GameObject.Find("TheBox").GetComponent<Rigidbody2D>();

        ToppleBox = GameObject.Find("ToppleBox");

        ToppleBox.GetComponent<FixedJoint2D>().enabled = false;

        Rigid.bodyType = RigidbodyType2D.Kinematic;
        //WoodRigid.bodyType = RigidbodyType2D.Kinematic;
        MetalRigid.bodyType = RigidbodyType2D.Kinematic;
        TheBoxRigid.bodyType = RigidbodyType2D.Kinematic;

    }

    // Update is called once per frame
    void Update()
    {
        if (PickedUp == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click"); // Debug to test if if statement works
                //Converting Mouse Pos to 2D (vector2) World Pos
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                if (hit.collider.CompareTag("Movable") == true) // Checking tag of hit sprite
                {
                    Moving = true;
                }
            }
            if (Moving == true)
            {
                mouselocation = Input.mousePosition;
                mouselocation.z = 10f; // used to set the distance that the object is placed infront of the camera when moving
                Rigid.transform.position = Camera.main.ScreenToWorldPoint(mouselocation);

                if (Input.GetMouseButtonUp(0))
                {
                    Moving = false;
                    PickedUp = false;
                    Moved = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.tag == "Connecter")
        {
            Debug.Log("Hit");
            colliding = true;

            if (colliding == true)
            {
                Debug.Log("Locking");
                Moving = false;
                PickedUp = false;
                Moved = true;
                Rigid.bodyType = RigidbodyType2D.Dynamic;
                WoodRigid.bodyType = RigidbodyType2D.Dynamic;
                MetalRigid.bodyType = RigidbodyType2D.Dynamic;
                TheBoxRigid.bodyType = RigidbodyType2D.Dynamic;
                ToppleBox.GetComponent<FixedJoint2D>().enabled = true;
            }
            else
            {
                Debug.Log("Collision Did Not Work");
            }
        }
        // Input.GetMouseButtonUp(0) &&
    }
}