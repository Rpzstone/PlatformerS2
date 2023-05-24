using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 102;

	public GameObject deathEffect;

	public void TakeDamage(int damage)
	{
	if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		
		Destroy(gameObject);
	}

}