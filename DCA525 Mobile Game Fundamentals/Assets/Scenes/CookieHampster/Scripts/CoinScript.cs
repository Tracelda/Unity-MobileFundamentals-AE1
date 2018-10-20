using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public int CoinsCollected;
    public GameObject Coin;
    public Rigidbody2D CoinRigid;

	// Use this for initialization
	void Start () {
        Coin = this.gameObject;
        CoinRigid = Coin.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hampster")
        {
            Debug.Log("Hit");
            Coin.SetActive(!Coin.activeInHierarchy);
            SFXScrpt.AudioManager.PlaySFX("Coin");
            CoinsCollected++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CoinHit");
        Coin.SetActive(!Coin.activeInHierarchy);
        SFXScrpt.AudioManager.PlaySFX("Coin");
        CoinsCollected++;
    }
}
