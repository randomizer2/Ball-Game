using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	public GameObject GoalParticle;
	public float levelDelay =2f;

	private Text levelNumber;
	private Text levelComplete;
	private GameObject UI;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		//moveHorizontal = Input.acceleration.x ;
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		rb2d.AddForce(movement*speed);



	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Death")
			Application.LoadLevel(Application.loadedLevel);

		if (other.tag == "Goal")
		{	Instantiate (GoalParticle, gameObject.transform.position, gameObject.transform.rotation);
			Invoke("ChangeLevel", levelDelay);

		}
			
	}




	private void ChangeLevel()
	{
		gameManager.nextLevel++;
		SceneManager.LoadScene(gameManager.nextLevel);

	}


}
