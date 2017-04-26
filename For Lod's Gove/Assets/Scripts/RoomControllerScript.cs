using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControllerScript : MonoBehaviour {

	public GameObject room;
	public Transform roomPos;
	public int ola;
	public static int numeroSalas = 30,
	porcentaje = 4,
	dim = 50,
	count = 0;

	private static int[,] mapa = new int[dim, dim];
	private Vector2 roomPosition;
	private int x = 0, y = 0;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		mapa[dim / 2, dim / 2] = 1;
		roomPosition = new Vector2 (x,y);
		roomPos = GameObject.FindGameObjectWithTag("roomContr").transform;
		PrintMap ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static void PrintMap()
	{
		for (int i = 0; i < dim; i++)
		{
			for (int j = 0; j < dim; j++)
			{

				if(mapa[i,j] == 1)
				{	roomPosition = new Vector2 ((transform.position.x) + (640 * i), (transform.position.y) + (480 * j));
					Instantiate(room , roomPosition);
				}
			} 
				
		}
	}


	static void FillMap()
	{


		while (count < numeroSalas)
		{
			for (int i = 0; i < dim; i++)
			{
				for (int j = 0; j < dim; j++)
				{
					if (mapa[i, j] == 1 && count < numeroSalas)
					{
						PutSala(i, j);

					}

				}


			}
		}
	}

	static bool CheckNearby(int x, int y)
	{
		int freeCount = 0, freeMax;


		if ((x + y) % 2 == 0)
			freeMax = 1;
		else
			freeMax = 2;


		if (mapa[x, y - 1] == 1)
			freeCount++;
		if (mapa[x + 1, y] == 1)
			freeCount++;
		if (mapa[x, y + 1] == 1)
			freeCount++;
		if (mapa[x - 1, y] == 1)
			freeCount++;

		return freeCount <= freeMax;
	}

	static void PutSala(int x, int y)
	{
		if (CheckNearby(x, y)) {
			if (CheckNearby(x, y -1) && Random.Range(0, porcentaje) == 0 && mapa[x, y - 1] == 0)
			{
				mapa[x, y - 1] = 1;
				count++;
			}else
				if (CheckNearby(x + 1, y) && Random.Range(0, porcentaje) == 0 && mapa[x + 1, y] == 0)
				{
					mapa[x + 1, y] = 1;
					count++;
				}else
					if (CheckNearby(x, y + 1) && Random.Range(0, porcentaje) == 0 && mapa[x, y + 1] == 0)
					{
						mapa[x, y + 1] = 1;
						count++;
					}else
						if (CheckNearby(x -1, y) && Random.Range(0, porcentaje) == 0 && mapa[x -1 , y] == 0)
						{
							mapa[x - 1, y] = 1;
							count++;
						}
		}
	}

}
