﻿using UnityEngine;
using System.Collections;

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

	}
}