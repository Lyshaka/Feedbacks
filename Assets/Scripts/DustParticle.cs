using UnityEngine;

public class DustParticle : MonoBehaviour
{
	Rigidbody2D rb;
	[SerializeField] ParticleSystem ps;
	GroundCheck gc;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponentInParent<Rigidbody2D>();
		gc = transform.parent.GetComponentInChildren<GroundCheck>();
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("velocity : " + rb.linearVelocity.magnitude);
		Debug.Log("grounded : " + gc.GetGrounded());
		if (rb.linearVelocity.magnitude > 0 && gc.GetGrounded())
		{
			Debug.Log("yes");
			while (!ps.isPlaying)
			{
				ps.Play();
			}
		}
		else
		{
			Debug.Log("no");
			ps.Stop();
		}
	}
}
