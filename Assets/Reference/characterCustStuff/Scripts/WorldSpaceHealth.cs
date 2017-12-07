using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceHealth : MonoBehaviour {

    public int curHealth, maxHealth;

    public float playerDist;
    public float maxDist = 35;
    public float minDist = 15;

    public float size;

    public Vector2 targetPos;

    public GameObject player;

    public GUIStyle boxStyle;

    // Update is called once per frame
    void LateUpdate() {

        targetPos = Camera.main.WorldToScreenPoint(transform.position);
        player = GameObject.FindGameObjectWithTag("Player");

        playerDist = Vector3.Distance(player.transform.position, transform.position);
    }

    private void OnGUI() {

        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (playerDist <= maxDist) {

            if (playerDist <= minDist) {

                size = 1;
            }
            else {

                size = ((playerDist - minDist) * .1f) + 1;
            }

            if (size < 20) {

                GUI.Box(new Rect(targetPos.x - .5f * scrW + scrW * ((size - 1) / 2), -targetPos.y + scrH * 8.25f, (curHealth * scrW / maxHealth) / size, (scrH * .25f) / size), "");
            }
        }
    }
}
