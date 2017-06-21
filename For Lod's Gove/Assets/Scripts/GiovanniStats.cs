using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GiovanniStats : MonoBehaviour
{
	public float moveSpeed;
	public float fe;
	public float damage;
	public float range;         

	public bool isDead;

	// Use this for initialization
	void Start()
	{
		moveSpeed = 10;
		fe = 100;
		damage = 1;
		range = 1;

		isDead = false;


			
	}

	// Update is called once per frame
	void Update()
	{
		Scene scene = SceneManager.GetActiveScene ();
		if (Input.GetKey ("g")) {
			if(scene.name == "Zone1")
			SceneManager.LoadScene ("Zone2", LoadSceneMode.Single);
			if(scene.name == "Zone2")
			SceneManager.LoadScene ("Zone3", LoadSceneMode.Single);
		}

	}
}