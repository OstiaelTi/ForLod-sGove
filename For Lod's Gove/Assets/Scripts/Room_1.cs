using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_1 : MonoBehaviour {

    public GameObject Diablillo;
    public GameObject Rock;
	public GameObject Fire;
	public int roomTypes;

    // Use this for initialization
    void Awake () 
		{
		float s = Random.Range (0, (roomTypes+1));
		int sw = (int)s;
			switch (sw) {
		case 0:
			Instantiate (Rock, new Vector2 (transform.position.x + 10, transform.position.y), Quaternion.identity);
			Instantiate (Rock, new Vector2 (transform.position.x - 10, transform.position.y), Quaternion.identity);
			Instantiate (Rock, new Vector2 (transform.position.x, transform.position.y + 10), Quaternion.identity);
			Instantiate (Rock, new Vector2 (transform.position.x, transform.position.y - 10), Quaternion.identity);

			Instantiate (Diablillo, new Vector2 (transform.position.x - 10, transform.position.y - 10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x + 10, transform.position.y + 10), Quaternion.identity);
			break;

		case 2:

			Instantiate (Fire, new Vector2 (transform.position.x + 10, transform.position.y), Quaternion.identity);
			Instantiate (Fire, new Vector2 (transform.position.x - 10, transform.position.y), Quaternion.identity);
			Instantiate (Fire, new Vector2 (transform.position.x, transform.position.y + 10), Quaternion.identity);
			Instantiate (Fire, new Vector2 (transform.position.x, transform.position.y - 10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x , transform.position.y), Quaternion.identity);
			break;

		case 3:
			
			Instantiate (Rock, new Vector2 (transform.position.x + 10, transform.position.y+ 10), Quaternion.identity);
			Instantiate (Rock, new Vector2 (transform.position.x - 10, transform.position.y- 10), Quaternion.identity);
			Instantiate (Fire, new Vector2 (transform.position.x- 10, transform.position.y + 10), Quaternion.identity);
			Instantiate (Fire, new Vector2 (transform.position.x+ 10, transform.position.y - 10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x , transform.position.y), Quaternion.identity);

			break;


		case 4:
			Instantiate (Diablillo, new Vector2 (transform.position.x + 10, transform.position.y+ 10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x - 10, transform.position.y- 10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x- 10, transform.position.y + 10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x+ 10, transform.position.y - 10), Quaternion.identity);
			break;

		case 5:
			Instantiate (Diablillo, new Vector2 (transform.position.x + 10, transform.position.y+10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x - 10, transform.position.y-10), Quaternion.identity);
			Instantiate (Fire, new Vector2 (transform.position.x , transform.position.y), Quaternion.identity);

			break;

		default:
			Instantiate (Rock, new Vector2 (transform.position.x + 10, transform.position.y), Quaternion.identity);
			Instantiate (Rock, new Vector2 (transform.position.x - 10, transform.position.y), Quaternion.identity);
			Instantiate (Rock, new Vector2 (transform.position.x, transform.position.y + 10), Quaternion.identity);
			Instantiate (Rock, new Vector2 (transform.position.x, transform.position.y - 10), Quaternion.identity);

			Instantiate (Diablillo, new Vector2 (transform.position.x - 10, transform.position.y - 10), Quaternion.identity);
			Instantiate (Diablillo, new Vector2 (transform.position.x + 10, transform.position.y + 10), Quaternion.identity);
			
			break;
		}
		}
	
	// Update is called once per frame
	void Update () {
		
	}
}


