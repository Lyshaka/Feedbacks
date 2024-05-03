using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public float Damage;
	public float Velocity;
	[HideInInspector] public bool IsFlipped;

	// Private Variables
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		//Rotate towards Mouse
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
		Vector2 myPos = transform.position;
		Vector2 dir = mousePos - myPos;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);

		rb.velocity = transform.up * Velocity * Time.fixedDeltaTime;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ground"))
		{
			StartCoroutine(PlayFeedback());
		}
		else if (collision.CompareTag("Enemy"))
		{
			collision.gameObject.GetComponent<EnemyController>().GetDamage(Damage, rb.velocity);
			StartCoroutine(PlayFeedback());
		}
	}

	IEnumerator PlayFeedback()
	{
		rb.velocity = Vector2.zero;
		GetComponent<Renderer>().enabled = false;
		GetComponent<Rigidbody2D>().gravityScale = 0;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<ParticleSystem>().Play();
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
