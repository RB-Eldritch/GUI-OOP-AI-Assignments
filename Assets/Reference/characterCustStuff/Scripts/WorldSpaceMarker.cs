using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceMarker : MonoBehaviour {

    public Vector2 targetPos;

    public GUIStyle NPCStyle;

    // Update is called once per frame
    void LateUpdate () {

        targetPos = Camera.main.WorldToScreenPoint(transform.position);
	}

    private void OnGUI() {

        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        GUI.Box(new Rect(targetPos.x - .25f * scrW, -targetPos.y + scrH * 7.8f, scrW * .5f, scrH * .5f), "", NPCStyle);
    }
}
