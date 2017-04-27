using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour{


	public GameObject Player;
    public GameObject Diablillo;
    public GameObject Rock;

    // Use this for initialization
    void Start () {
	    Instantiate (Player, transform.position, Quaternion.identity);

        Instantiate(Rock, new Vector2(transform.position.x + 15, transform.position.y), Quaternion.identity);
        Instantiate(Rock, new Vector2(transform.position.x - 15, transform.position.y), Quaternion.identity);
        Instantiate(Rock, new Vector2(transform.position.x, transform.position.y + 15), Quaternion.identity);
        Instantiate(Rock, new Vector2(transform.position.x, transform.position.y - 15), Quaternion.identity);

        Instantiate(Diablillo, new Vector2(transform.position.x - 15, transform.position.y - 15), Quaternion.identity);
        Instantiate(Diablillo, new Vector2(transform.position.x + 15, transform.position.y + 15), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
