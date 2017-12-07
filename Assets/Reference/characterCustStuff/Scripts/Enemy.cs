using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int curHealth = 100, maxHealth = 100;

    public WorldSpaceHealth worldSpace;

	// Use this for initialization
	void Start () {

        worldSpace = GetComponent<WorldSpaceHealth>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.RightAlt)) {

            curHealth -= 10;
        }
	}

    private void LateUpdate() {

        if (curHealth < 0) {

            curHealth = 0;
        }

        if (curHealth > maxHealth) {

            curHealth = maxHealth;
        }

        worldSpace.maxHealth = maxHealth;
        worldSpace.curHealth = curHealth;
    }
}
