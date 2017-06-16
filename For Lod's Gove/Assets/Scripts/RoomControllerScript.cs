using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControllerScript : MonoBehaviour {

	public GameObject firstRoom;
	public GameObject Room;
    public GameObject LastRoom;
    public static int numeroSalas = 10;
	public int roomNumber;
	public static int
	porcentaje = 4,
	dim = 40,
	count = 0;

	public bool up = true, right = true, down = true, left = true;

    private int random;
	private bool last = true;

	private static int[,] mapa = new int[dim, dim];
	private Vector3 roomPosition;


	// Use this for initialization
	void Start () 
	{
		mapa[dim/2, dim/2] = 2;
		FillMap ();

		roomNumber = 0;
		roomPosition = new Vector2 ( dim/2 *64, dim/2*51.2f);
		checkDoor(dim/2, dim/2);


		Instantiate (firstRoom, roomPosition, Quaternion.identity);
	

	
		for (int i = 0; i < dim; i++)
		{
			for (int j = 0; j < dim; j++)
			{

				if(mapa[i,j] == 1)
				{	
					roomPosition = new Vector2 ( i*64, j*51.2f);
					checkDoor(i, j);
						roomNumber++;

					if (Random.Range (roomNumber, numeroSalas) == numeroSalas && last) {
						last = false;
						Instantiate(LastRoom, roomPosition, Quaternion.identity);

					}else
						
                        Instantiate(Room, roomPosition, Quaternion.identity);
                    
                   


                }
			} 

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*static void PrintMap()
	{
		for (int i = 0; i < dim; i++)
		{
			for (int j = 0; j < dim; j++)
			{

				if(mapa[i,j] == 1)
				{	roomPosition = new Vector2 ((640 * i), (480 * j));
					Instantiate(room , roomPosition, Quaternion.identity);
				}
			} 
				
		}
	}*/


	static void FillMap()
	{


		while (count < numeroSalas)
		{
			for (int i = 0; i < dim; i++)
			{
				for (int j = 0; j < dim; j++)
				{
					if (mapa[i, j] != 0 && count < numeroSalas)
					{
						PutSala(i, j);
					

					}

				}


			}
		}
	}

	 void checkDoor(int i, int j)
	{
		if (mapa [i, j - 1] != 0)
			up = true;
		else
			up = false;

		if (mapa [i + 1, j] != 0)
			right = true;
		else
			right = false;

		if (mapa [i, j + 1] != 0)
			down = true;
		else
			down = false;

		if (mapa [i - 1, j] != 0)
			left = true;
		else
			left = false;
	}

	static bool CheckNearby(int x, int y)
	{
		int freeCount = 0, freeMax;


		if ((x + y) % 2 == 0)
			freeMax = 1;
		else
			freeMax = 2;


		if (mapa[x, y - 1] != 0)
			freeCount++;
		if (mapa[x + 1, y] != 0)
			freeCount++;
		if (mapa[x, y + 1] != 0)
			freeCount++;
		if (mapa[x - 1, y] != 0)
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
