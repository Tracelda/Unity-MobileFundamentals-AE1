using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class CookieScript : MonoBehaviour {

    public GameObject Cookie;
    public Rigidbody2D CookieRigid;
    private bool CookieCollected;
    private bool GameWon;

    // Ui Objects
    GameObject MenuBox;
    GameObject Canvas;
    GameObject MenuBTN;
    GameObject RestartBTN;
    GameObject WinnerTXT;
    GameObject MenuTXT;
    GameObject RestartTXT;

    // Use this for initialization
    void Start()
    {
        Cookie = GameObject.Find("Cookie");
        CookieRigid = Cookie.GetComponent<Rigidbody2D>();

        // Ui Stuff
        MenuBox = GameObject.Find("Menu Box");
        MenuBox.GetComponent<SpriteRenderer>().enabled = false;

        Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CookieCollected == true)
        {
            Cookie.SetActive(!Cookie.activeInHierarchy);
            SFXScrpt.AudioManager.PlaySFX("ElectroWin");
            GameWon = true;
        }

        // Show Hidden Ui
        if (GameWon == true)
        {
            Canvas.GetComponent<Canvas>().enabled = true;
            MenuBox.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hampster")
        {
            Debug.Log("Hit");
            CookieCollected = true;
        }
    }
}