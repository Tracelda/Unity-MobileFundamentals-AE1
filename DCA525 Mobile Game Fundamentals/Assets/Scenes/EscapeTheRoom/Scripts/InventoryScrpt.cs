using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryScrpt : MonoBehaviour {

    public int NumOfInvenSlots;
    public GameObject[] Items;
    public Sprite[] Image;

    private GameObject Poster;
    private Rigidbody2D PosterRigid;
    private BoxCollider2D PosterCollider;
    private GameObject PaperNote;
    private BoxCollider2D NoteCollider;
    private GameObject BigNote;
    private BoxCollider2D BigNoteCollider;
    private bool NoteOnScreen;
    private GameObject TextCanvas;

    // Use this for initialization
    void Start () {
        NumOfInvenSlots = 8;
        Image = new Sprite[NumOfInvenSlots];
        Poster = GameObject.Find("Poster");
        PosterRigid = Poster.GetComponent<Rigidbody2D>();
        PosterCollider = Poster.GetComponent<BoxCollider2D>();
        PosterRigid.bodyType = RigidbodyType2D.Kinematic;

        PaperNote = GameObject.Find("notebook");
        NoteCollider = PaperNote.GetComponent<BoxCollider2D>();

        BigNote = GameObject.Find("notebookbig");
        BigNoteCollider = BigNote.GetComponent<BoxCollider2D>();
        BigNoteCollider.enabled = false;
        BigNote.GetComponent<SpriteRenderer>().enabled = false;

        TextCanvas = GameObject.Find("TextCanvas");
        TextCanvas.GetComponent<Canvas>().enabled = false;


        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            // Debug to test if if statement works
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

            if (hit && hit.collider.CompareTag("Item")) // Checking tag of hit sprite
            {
                Debug.Log("Item Hit");
                AddItem(hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite);
            }
            else if(hit && hit.collider.CompareTag("Poster"))
            {
                PosterRigid.bodyType = RigidbodyType2D.Dynamic;
                Debug.Log("Poster Hit");
                NoteCollider.enabled = true;
            }
            else if(hit && hit.collider.CompareTag("Paper"))
            {
                NoteOnScreen = true;
                BigNote.GetComponent<SpriteRenderer>().enabled = true;
                BigNoteCollider.enabled = true;
                GameObject.Find("TextCanvas").GetComponent<Canvas>().enabled = true;
                PosterRigid.bodyType = RigidbodyType2D.Static;
                PosterCollider.enabled = false;
            }
            else if (hit && hit.collider.CompareTag("bignote") && NoteOnScreen == true)
            {
                NoteOnScreen = false;
                BigNote.GetComponent<SpriteRenderer>().enabled = false;
                BigNoteCollider.enabled = false;
                GameObject.Find("TextCanvas").GetComponent<Canvas>().enabled = false;
            }
        }
    }

    public void AddItem(Sprite itemToAdd)
    {
            foreach(GameObject myItem in Items)
            {
            if (myItem.GetComponent<Image>().enabled ||myItem.GetComponent<Image>().sprite != null)
                continue;

            myItem.GetComponent<Image>().enabled = true;
            myItem.GetComponent<Image>().sprite = itemToAdd;
            //myItem.GetComponent<Image>().tag = "InvenItem";
            Debug.Log("Add");
            break;
            }
    }

    public void RemoveItem()
    {
        EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Image>().sprite = null;
    }

}
