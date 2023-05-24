using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

	public Transform Player;
	public Transform player2;

	public bool isFlipped = false;

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (GameObject.FindGameObjectWithTag("Player2"))
		{
			if (transform.position.x > player2.position.x && isFlipped)
			{
				transform.localScale = flipped;
				transform.Rotate(0f, 180f, 0f);
				isFlipped = false;
			}
			else if (transform.position.x < player2.position.x && !isFlipped)
			{
				transform.localScale = flipped;
				transform.Rotate(0f, 180f, 0f);
				isFlipped = true;
			}
		}

			if (GameObject.FindGameObjectWithTag("Player"))
			{
				if (transform.position.x > Player.position.x && isFlipped)
				{
					transform.localScale = flipped;
					transform.Rotate(0f, 180f, 0f);
					isFlipped = false;
				}
				else if (transform.position.x < Player.position.x && !isFlipped)
				{
					transform.localScale = flipped;
					transform.Rotate(0f, 180f, 0f);
					isFlipped = true;
				}
			}
		}
	}


