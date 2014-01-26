﻿using UnityEngine;
using System.Collections;

public class TeamHealth : MonoBehaviour {

	public int startingHP;
	int currentHP;

	bool isInvicible = false;
	public float invicibilityTimer;

	public HUD3D hud;

	// Use this for initialization
	void Start () 
	{
		currentHP = startingHP;
	}

	public void TakeDamage(int damage)
	{
		if (!isInvicible) 
		{
			currentHP -= damage;
			isInvicible = true;
			hud.MoveHPHudItem(damage);
			StartCoroutine(invicibilityCooldown(invicibilityTimer));
		}
	}

	IEnumerator invicibilityCooldown(float timer)
	{
		yield return new WaitForSeconds (timer);
		isInvicible = false;
	}

}