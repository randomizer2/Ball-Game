using UnityEngine;
using System.Collections;

public class loader : MonoBehaviour {

	public GameObject GameManager;

	void Awake()
	{
		if (gameManager.instance ==null)
			Instantiate(GameManager);
	}

}
