using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {

    Rigidbody2D Rigid;
    public GameObject TheBox;
    public Rigidbody2D TheBoxRigid;
    bool GameWon;
    bool StartCounting;
    public float TimerTarget;
    public float TimerValue;
    public Slider Slider;
    GameObject MenuBox;
    GameObject Canvas;
    GameObject MenuBTN;
    GameObject RestartBTN;
    GameObject WinnerTXT;
    GameObject MenuTXT;
    GameObject RestartTXT;


    // Use this for initialization
    void Start () {
        Rigid = GetComponent<Rigidbody2D>();

        TheBox = GameObject.Find("TheBox");
        TheBoxRigid = TheBox.GetComponent<Rigidbody2D>();

        MenuBox = GameObject.Find("Menu Box");
        MenuBox.GetComponent<SpriteRenderer>().enabled = false;

        Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<Canvas>().enabled = false;

        MenuBTN = GameObject.Find("MenuBTN");
        MenuBTN.GetComponent<Image>().enabled = false;

        RestartBTN = GameObject.Find("RestartBTN");
        RestartBTN.GetComponent<Image>().enabled = false;

        WinnerTXT = GameObject.Find("YouAreWinner");
        WinnerTXT.GetComponent<Text>().enabled = false;

        MenuTXT = GameObject.Find("MenuText");
        MenuTXT.GetComponent<Text>().enabled = false;

        RestartTXT = GameObject.Find("RestartText");
        RestartTXT.GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if(StartCounting == true && TimerValue < TimerTarget)
        {
            // Slider not filling fully
            TimerValue = TimerValue + Time.deltaTime;
            Slider.value = Mathf.MoveTowards(Slider.value, 100.0f, 0.15f);

            if(TimerValue >= TimerTarget) // not registering as soon as timer is finished
            {
                StartCounting = false;
                GameWon = true;
                Debug.Log("Game Won");
            }
        }

        if (GameWon == true)
        {
            MenuBox.GetComponent<SpriteRenderer>().enabled = true;

            MenuBTN = GameObject.Find("MenuBTN");
            MenuBTN.GetComponent<Image>().enabled = true;

            RestartBTN = GameObject.Find("RestartBTN");
            RestartBTN.GetComponent<Image>().enabled = true;

            WinnerTXT = GameObject.Find("YouAreWinner");
            WinnerTXT.GetComponent<Text>().enabled = true;

            MenuTXT = GameObject.Find("MenuText");
            MenuTXT.GetComponent<Text>().enabled = true;

            RestartTXT = GameObject.Find("RestartText");
            RestartTXT.GetComponent<Text>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            Debug.Log("Hit Floor!!!!!!!!");
            StartCounting = true;
            Canvas.GetComponent<Canvas>().enabled = true;
            // Slider not showing when enabled
        }
    }
}
