using UnityEngine;
using UnityEngine.SceneManagement;

//Play Level 1
public class PlayLevel : MonoBehaviour {
	private int playerHealth = 100;
	private int playerMaxHealth = 100;
	public bool inLevel = false;

	public void Start()
	{
		SceneManager.LoadScene ("NewStance");
		inLevel = true;
		playerHealth = playerMaxHealth;
	}
}