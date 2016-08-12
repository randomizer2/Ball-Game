using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	public static int nextLevel = 1;
	public float levelDelay =2f;

	private Text levelNumber;
	private Text levelComplete;
	private GameObject UI;

	public static gameManager instance =null;



	void Awake ()
	{
		if (instance==null)
			instance=this;
		else if(instance !=this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

	}



	void InitSetup()
	{

		UI = GameObject.Find("UserInterface");
		levelComplete =GameObject.Find("LevelComplete").GetComponent<Text>();
		levelComplete.text = "Level Complete!";
		levelNumber = GameObject.Find("LevelNumber").GetComponent<Text>();
		levelNumber.text = "Level " + nextLevel;
	
		UI.SetActive(true);
		Invoke("HideLevelText" , levelDelay );
	}

	private void OnLevelWasLoaded()
	{
		
		InitSetup();


	}

	private void HideLevelText()
	{
		UI.SetActive(false);

	}
}
