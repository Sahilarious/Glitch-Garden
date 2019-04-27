using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Projectile : MonoBehaviour
{
	public ProjectileTypes pt;
	[SerializeField]
	public int damage = 5;
	[SerializeField]
	int speed = 5;
	[SerializeField]
	int angularSpeed = 200;

	public bool thrown = false;

	void Start ()
	{
	}

	public virtual void Update ()
	{
		if(thrown)
		{
			//transform.Translate(Time.deltaTime * speed, 0, 0);
			transform.position += new Vector3(Time.deltaTime * speed, 0, 0);

			transform.Rotate(Vector3.forward, Time.deltaTime * -angularSpeed);
		}
	}

	public virtual void ThrowProjectile(Vector2 startPos)
	{
		Debug.Log("Projectile thrown");
		transform.position = startPos;
		gameObject.SetActive(true);
		thrown = true;
	}

	public void ResetProjectile()
	{
		thrown = false;
		gameObject.SetActive(false);
		transform.position = new Vector2(-10,-10);
		transform.rotation = Quaternion.identity;
	}

}
