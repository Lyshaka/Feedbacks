using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	[SerializeField] private LayerMask groundLayer;

	private bool grounded;
	[SerializeField] private ParticleSystem ps;

	public bool GetGrounded()
	{
		return (grounded);
	}

	public void PlayGroundParticle()
	{
		ps.Play();
	}

	private void Start()
	{
		GetComponent<Collider2D>().includeLayers = groundLayer;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		grounded = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		grounded = false;
	}
}
