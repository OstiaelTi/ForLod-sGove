using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_2 : MonoBehaviour
{

    public GameObject Diablillo;
    public GameObject Rock;

    // Use this for initialization
    void Start()
    {
        Instantiate(Rock, new Vector2(transform.position.x + 15, transform.position.y + 15), Quaternion.identity);
        Instantiate(Rock, new Vector2(transform.position.x - 15, transform.position.y - 15), Quaternion.identity);
 
        Instantiate(Diablillo, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    
    }

    // Update is called once per frame
    void Update()
    {

    }
}