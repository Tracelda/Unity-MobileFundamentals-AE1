using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointScrpt : MonoBehaviour {

    private Vector3 mouselocation;
    public GameObject TopBolt;
    public GameObject BottomBolt;
    public HingeJoint2D TopJoint;
    public HingeJoint2D BottomJoint;

    // Use this for initialization
    void Start () {
        TopBolt = GameObject.Find("TopBolt");
        TopJoint = TopBolt.GetComponent<HingeJoint2D>();

        BottomBolt = GameObject.Find("BottomBolt");
        BottomJoint = TopBolt.GetComponent<HingeJoint2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
             // Debug to test if if statement works
                                //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

            if (hit && hit.collider.CompareTag("TopJoint") == true) // Checking tag of hit sprite
            {
                Debug.Log("Top Joint Hit");
                TopBolt.GetComponent<SpriteRenderer>().enabled = false;
                TopJoint.enabled = false;
                Debug.Log("Click");
            }
            else if(hit && hit.collider.CompareTag("BottomJoint") == true)
            {
                Debug.Log("Bottom Joint Hit");
                BottomBolt.GetComponent<SpriteRenderer>().enabled = false;
                BottomJoint.enabled = false;
            }
        }

    }
}
