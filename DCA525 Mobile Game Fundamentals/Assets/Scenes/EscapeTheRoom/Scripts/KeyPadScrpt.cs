using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyPadScrpt : MonoBehaviour {

    private GameObject BigKeyPanel;
    private Image BigPanelImage;
    private GameObject KeyPanelScreen;
    private Image ScreenImage;
    private GameObject KeyPadText;
    private Text KeyPadTextVal;
    private GameObject ExitText;
    private Text ExitTextVal;

    //Door Stuff
    private bool DoorOpen;
    private GameObject ClosedDoor;
    private SpriteRenderer ClosedRenderer;
    private GameObject OpenDoor;
    private BoxCollider2D OpenCollider;
    private SpriteRenderer OpenRenderer;

    //Keypad Values
    bool KeyPadOpen;
    public int FValueInt;
    public int SValueInt;
    public int TValueInt;
    private string FValueString;
    private string SValueString;
    private string TValueString;

    private GameObject BTNOne;
    private GameObject BTNTwo;
    private GameObject BTNThree;
    private GameObject BTNEnter;
    private GameObject BTNExit;

    private Button BTNOneInter;
    private Button BTNTwoInter;
    private Button BTNThreeInter;
    private Button BTNEnterInter;
    private Button BTNExitInter;


    // Use this for initialization
    void Start () {
        BigKeyPanel = GameObject.Find("BigKeyPanel");
        BigPanelImage = BigKeyPanel.GetComponent<Image>();
        KeyPanelScreen = GameObject.Find("KeyPanelScreen");
        ScreenImage = KeyPanelScreen.GetComponent<Image>();
        KeyPadText = GameObject.Find("KeyPadText");
        KeyPadTextVal = KeyPadText.GetComponent<Text>();
        ExitText = GameObject.Find("ExitText");
        ExitTextVal = ExitText.GetComponent<Text>();

        BigPanelImage.enabled = false;
        ScreenImage.enabled = false;
        KeyPadTextVal.enabled = false;
        ExitTextVal.enabled = false;

        // Buttons
        BTNOne = GameObject.Find("Button1");
        BTNTwo = GameObject.Find("Button2");
        BTNThree = GameObject.Find("Button3");
        BTNEnter = GameObject.Find("EnterButton");
        BTNExit = GameObject.Find("ExitButton");

        BTNOneInter = BTNOne.GetComponent<Button>();
        BTNTwoInter = BTNTwo.GetComponent<Button>();
        BTNThreeInter = BTNThree.GetComponent<Button>();
        BTNEnterInter = BTNEnter.GetComponent<Button>();
        BTNExitInter = BTNExit.GetComponent<Button>();

        BTNOneInter.interactable = false;
        BTNTwoInter.interactable = false;
        BTNThreeInter.interactable = false;
        BTNEnterInter.interactable = false;
        BTNExitInter.interactable = false;

        //Doors
        ClosedDoor = GameObject.Find("doorsclose");
        ClosedRenderer = ClosedDoor.GetComponent<SpriteRenderer>();
        OpenDoor = GameObject.Find("doorsopen");
        OpenCollider = OpenDoor.GetComponent<BoxCollider2D>();
        OpenRenderer = OpenDoor.GetComponent<SpriteRenderer>();

        ClosedRenderer.enabled = true;
        OpenCollider.enabled = false;
        OpenRenderer.enabled = false;

        // Setting Starting Values To Blank
        FValueString = " ";
        SValueString = " ";
        TValueString = " ";
        KeyPadTextVal.text = " , , , ";

        KeyPadOpen = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            // Debug to test if if statement works
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

            if (hit && hit.collider.CompareTag("Keypad")) // Checking tag of hit sprite
            {
                Debug.Log("KeyPad Hit");
                BigPanelImage.enabled = true;
                ScreenImage.enabled = true;
                KeyPadTextVal.enabled = true;
                BTNOneInter.interactable = true;
                BTNTwoInter.interactable = true;
                BTNThreeInter.interactable = true;
                BTNEnterInter.interactable = true;
                BTNExitInter.interactable = true;
                ExitTextVal.enabled = true;
                KeyPadOpen = true;
            }
            else if (hit && hit.collider.CompareTag("OpenDoor") && KeyPadOpen == false)
            {
                LoadMainMenu();
                Debug.Log("LoadMainMenu");
            }
        }

        if (DoorOpen == true)
        {
            ClosedRenderer.enabled = false;
            OpenCollider.enabled = true;
            OpenRenderer.enabled = true;
        }
    }

    public void CheckCode()
    {
        if (FValueInt == 1 && SValueInt == 2 && TValueInt == 3)
        {
            KeyPadTextVal.text = "Correct";
            DoorOpen = true;
            Debug.Log("EnterButton");
        }
    }

    public void ExitKeyPad()
    {
        BigPanelImage.enabled = false;
        ScreenImage.enabled = false;
        KeyPadTextVal.enabled = false;
        BTNOneInter.interactable = false;
        BTNTwoInter.interactable = false;
        BTNThreeInter.interactable = false;
        BTNEnterInter.interactable = false;
        BTNExitInter.interactable = false;
        ExitTextVal.enabled = false;
        //Reset Values
        FValueString = " ";
        SValueString = " ";
        TValueString = " ";
        KeyPadTextVal.text = " , , , ";
        KeyPadOpen = false;
    }

    public void UpdateFValueInt()
    {
        FValueInt = 1;
        FValueString = FValueInt.ToString();
        KeyPadTextVal.text = FValueString + " , " + SValueString + " , " + TValueString;
        Debug.Log("Button1");
    }

    public void UpdateSValueInt()
    {
        SValueInt = 2;
        SValueString = SValueInt.ToString();
        KeyPadTextVal.text = FValueString + " , " + SValueString + " , " + TValueString;
        Debug.Log("Button2");
    }

    public void UpdateTValueInt()
    {
        TValueInt = 3;
        TValueString = TValueInt.ToString();
        KeyPadTextVal.text = FValueString + " , " + SValueString + " , " + TValueString;
        Debug.Log("Button3");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
    }

}
