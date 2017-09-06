using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealthBarController : MonoBehaviour {
	public GameObject NPCCube;
	
	[SerializeField]
	private int NPCHealth;
	private int NPCMaxHealth;
    void Start()
    {
        transform.localScale += new Vector3(1, 5, 1);
    }

        // Update is called once per frame
        void Update () {
		transform.localScale += new Vector3(1, 5*(NPCHealth/NPCMaxHealth), 1);
	}
}