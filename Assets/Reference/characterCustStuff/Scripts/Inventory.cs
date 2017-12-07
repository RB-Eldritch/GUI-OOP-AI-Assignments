using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public MouseLook mainCam;
    public GameObject player;

    public List<Item> inv = new List<Item>();
    public bool showInv;
    public Item selectedItem;
    public int money;
    public Vector2 scrollPos;
    public GameObject wHand, curWeapon;
    public GameObject helmetNode, curHelmet;

    // Use this for initialization
    void Start () {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        player = GameObject.FindGameObjectWithTag("Player");
        wHand = GameObject.FindGameObjectWithTag("WeaponHandler");
        helmetNode = GameObject.FindGameObjectWithTag("HelmetNode");

        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(103));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(205));
        inv.Add(ItemGen.CreateItem(300));
        inv.Add(ItemGen.CreateItem(400));
        inv.Add(ItemGen.CreateItem(401));
        inv.Add(ItemGen.CreateItem(206));
        inv.Add(ItemGen.CreateItem(301));
        
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Tab)) {

            ToggleInv();
        }
	}

    public bool ToggleInv() {

        if (showInv) {

            showInv = false;
            Time.timeScale = 1;

            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<MouseLook>().enabled = true;
            mainCam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            return false;
        }
        else if (!showInv) {

            showInv = true;
            Time.timeScale = 0;

            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<MouseLook>().enabled = false;
            mainCam.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            return true;
        }

        return showInv;
    }

    void OnGUI() {

        if (showInv) {

            float scrH = Screen.height / 9;
            float scrW = Screen.width / 16;

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");

            if (inv.Count <= 35) {

                for (int i = 0; i < inv.Count; i++) {

                    if (GUI.Button(new Rect(.5f * scrW, .25f * scrH + i * (.25f * scrH), 3 * scrW, .25f * scrH), inv[i].Name)) {

                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            else {

                scrollPos = GUI.BeginScrollView(new Rect(0, 0, 6 * scrW, 9 * scrH), scrollPos, new Rect(0, 0, 0, 9 * scrH + ((inv.Count - 35) * .25f * scrH)), false, true);

                for (int i = 0; i < inv.Count; i++) {

                    if (GUI.Button(new Rect(.5f * scrW, .25f * scrH + i * (.25f * scrH), 3 * scrW, .25f * scrH), inv[i].Name)) {

                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }

                GUI.EndScrollView();
            }

            if (selectedItem != null) {

                if (selectedItem.Type == ItemType.Food) {

                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);

                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, .25f * scrH), "Consume")) {

                        Debug.Log("Mmm, tasty " + selectedItem.Name + ", Om Nom");
                        inv.Remove(selectedItem);
                        selectedItem = null;
                    }
                }

                if (selectedItem.Type == ItemType.Weapon) {

                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);

                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, .25f * scrH), "Equip")) {

                        Debug.Log("My mighty " + selectedItem.Name);

                        if (curWeapon != null) {

                            Destroy(curWeapon);
                        }

                        curWeapon = Instantiate(Resources.Load("Prefabs/" + selectedItem.Mesh) as GameObject, wHand.transform.position, Quaternion.identity, wHand.transform);
                        
                        selectedItem = null;
                    }
                }

                if (selectedItem.Type == ItemType.Apparel) {

                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Description + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);

                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, .25f * scrH), "Equip")) {

                        Debug.Log("My Lucky " + selectedItem.Name);

                        if (curHelmet != null) {

                            Destroy(curHelmet);
                        }

                        curHelmet = Instantiate(Resources.Load("Prefabs/" + selectedItem.Mesh) as GameObject, helmetNode.transform.position, Quaternion.identity, helmetNode.transform);

                        selectedItem = null;
                    }
                }

                if (selectedItem.Type == ItemType.Crafting) {


                }

                if (selectedItem.Type == ItemType.Quest) {


                }

                if (selectedItem.Type == ItemType.Money) {


                }

                if (selectedItem.Type == ItemType.Ingredients) {


                }

                if (selectedItem.Type == ItemType.Potions) {


                }

                if (selectedItem.Type == ItemType.Scrolls) {


                }

                /*
                Food
                Weapon
                Apparel
                Crafting
                Quest
                Money
                Ingredients
                Potions
                Scrolls
                */
            }
        }
    }
}
