using UnityEngine;

public class DustParticle : MonoBehaviour
{
	Rigidbody2D rb;
	ParticleSystem ps;
	GroundCheck gc;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponentInParent<Rigidbody2D>();
		ps = GetComponent<ParticleSystem>();
		gc = transform.parent.GetComponentInChildren<GroundCheck>();
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("grounded : " + gc.GetGrounded());
		if (rb.velocity.magnitude > 0)
		{
			Debug.Log("yes");
			ps.Play();
		}
		else
		{
			Debug.Log("no");
			ps.Stop();
		}
	}
}
