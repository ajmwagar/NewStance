using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {
	public GameObject NPCCube;
	public GameObject PlayerHealth;
	[SerializeField]
	public int playerHealth = 100;
	public int playerMaxHealth = 100;
    void Start()
    {
        transform.localScale += new Vector3(1, 5, 1);
    }

    // Update is called once per frame
    void Update () {
		transform.localScale += new Vector3(1, 5*(playerHealth/playerMaxHealth), 1);
	}
}