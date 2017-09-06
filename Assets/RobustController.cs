using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RobustController : MonoBehaviour {
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;
	public bool inLevel = false;
	private int NPCHealth;
	private int NPCMaxHealth;
	[SerializeField]
	public int playerHealth;
	public int playerMaxHealth = 100;
	public GameObject NPCCube;
	public GameObject NPCHealthText;
	public GameObject PlayerCube;
	public GameObject PlayerHealthText;


	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
		PlayerCube.SetActive (false);
		NPCCube.SetActive (false);
		{
			SceneManager.LoadScene ("MainMenu");
		}
	}

    public void winCondition()
    {
        NPCCube.SetActive(false);
        NPCHealthText.SetActive(false);
        PlayerCube.SetActive(false);
        PlayerHealthText.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObject.index);
		if (device.GetPressDown(triggerButton))
		{
			SceneManager.LoadScene ("NewStance");
			inLevel = true;
			playerHealth = playerMaxHealth;
		}

		if (inLevel) {
			if(playerHealth < 1)
			{
				gameOver();
			}

			if (NPCHealth < 1)
			{
				winCondition();
			}
		}
	}

	private void gameOver()
	{

		NPCCube.SetActive (false);
		NPCHealthText.SetActive (false);
		PlayerCube.SetActive (false);
		PlayerHealthText.SetActive (false);
		
	}

	void FixedUpdate()
	{
	}
}