using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_1 : MonoBehaviour {

    public GameObject Diablillo;
    public GameObject Rock;

    // Use this for initialization
    void Start () {

        Instantiate(Rock, new Vector2(transform.position.x + 10, transform.position.y), Quaternion.identity);
        Instantiate(Rock, new Vector2(transform.position.x - 10, transform.position.y), Quaternion.identity);
        Instantiate(Rock, new Vector2(transform.position.x, transform.position.y + 10), Quaternion.identity);
        Instantiate(Rock, new Vector2(transform.position.x, transform.position.y - 10), Quaternion.identity);

        Instantiate(Diablillo, new Vector2(transform.position.x - 10, transform.position.y - 10), Quaternion.identity);
        Instantiate(Diablillo, new Vector2(transform.position.x + 10, transform.position.y + 10), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
