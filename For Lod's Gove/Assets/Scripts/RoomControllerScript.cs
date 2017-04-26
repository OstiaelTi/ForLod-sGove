﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControllerScript : MonoBehaviour {

	public GameObject firstRoom;
	public GameObject standardRoom;
	public static int numeroSalas = 30;

	public static int
	porcentaje = 4,
	dim = 40,
	count = 0;


	private static int[,] mapa = new int[dim, dim];
	private Vector3 roomPosition;


	// Use this for initialization
	void Start () 
	{
		mapa[dim/2, dim/2] = 2;
		roomPosition = new Vector2 ( dim/2 *64, dim/2*48);
		Instantiate (firstRoom, roomPosition, Quaternion.identity);
	
		FillMap ();
	
		for (int i = 0; i < dim; i++)
		{
			for (int j = 0; j < dim; j++)
			{

				if(mapa[i,j] == 1)
				{	roomPosition = new Vector2 ( i*64, j*48);
					Instantiate(standardRoom , roomPosition, Quaternion.identity);

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
