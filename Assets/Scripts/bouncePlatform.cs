using UnityEngine;
using System.Collections;

public class bouncePlatform : MonoBehaviour {

	public float bounciness; // Determines height

	void OnCollisionEnter2D(Collision2D other)
	{

		other.rigidbody.AddForce(Vector2.up * bounciness, ForceMode2D.Impulse);
	}

}
