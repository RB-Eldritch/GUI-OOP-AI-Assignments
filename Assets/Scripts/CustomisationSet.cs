using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//you will need to change Scenes
using UnityEngine.SceneManagement;

public class CustomisationSet : MonoBehaviour {

    #region Variables

    [Header("Texture Lists")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();

    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int curSkin;
    public int curHair, curMouth, curEyes, curArmour, curClothes;

    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public SkinnedMeshRenderer charMeshRend;

    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMaxIndex = 4;
    public int hairMaxIndex = 5, mouthMaxIndex = 3, eyesMaxIndex = 4, armourMaxIndex = 11, clothesMaxIndex = 11;

    [Header("Character Name")]
    //name of our character that the user is making
    public string charName = "Astrid";

    #endregion

    #region Start
    //in start we need to set up the following
    void Start() {

        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMaxIndex; i++) {

            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;

            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of hair textures we need
        for (int i = 0; i < hairMaxIndex; i++) {

            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;

            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of mouth textures we need
        for (int i = 0; i < mouthMaxIndex; i++) {

            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;

            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of eyes textures we need
        for (int i = 0; i < eyesMaxIndex; i++) {

            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;

            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }

        for (int i = 0; i < armourMaxIndex; i++) {

            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;

            //add our temp texture that we just found to the skin List
            armour.Add(temp);
        }

        for (int i = 0; i < clothesMaxIndex; i++) {

            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;

            //add our temp texture that we just found to the skin List
            clothes.Add(temp);
        }

        #endregion

        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        charMeshRend = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();

        #region do this after making the function SetTexture

        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Hair", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Armour", 0);
        SetTexture("Clothes", 0);

        #endregion
    }
    #endregion

    #region SetTexture

    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    void SetTexture(string type, int dir) {


        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        //inside a switch statement that is swapped by the string name of our material
        switch (type) {

            //case skin
            case "Skin":

                //index is the same as our skin index
                index = curSkin;

                //max is the same as our skin max
                max = skinMaxIndex;

                //textures is our skin list .ToArray()
                textures = skin.ToArray();

                //material index element number is 1
                matIndex = 1;

            //break
            break;

            //now repeat for each material 

            //hair is 2
            case "Hair":

                //index is the same as our hair index
                index = curHair;

                //max is the same as our hair max
                max = hairMaxIndex;

                //textures is our hair list .ToArray()
                textures = hair.ToArray();

                //material index element number is 1
                matIndex = 2;

            //break
            break;

            //mouth is 3
            case "Mouth":

                //index is the same as our mouth index
                index = curMouth;

                //max is the same as our mouth max
                max = mouthMaxIndex;

                //textures is our mouth list .ToArray()
                textures = mouth.ToArray();

                //material index element number is 1
                matIndex = 3;

            //break
            break;

            //eyes are 4
            case "Eyes":

                //index is the same as our eyes index
                index = curEyes;

                //max is the same as our eyes max
                max = eyesMaxIndex;

                //textures is our eyes list .ToArray()
                textures = eyes.ToArray();

                //material index element number is 1
                matIndex = 4;

            //break
            break;

            case "Armour":

                index = curArmour;
                max = armourMaxIndex;
                textures = armour.ToArray();
                matIndex = 5;
            break;

            case "Clothes":

                index = curClothes;
                max = clothesMaxIndex;
                textures = clothes.ToArray();
                matIndex = 6;
            break;
        }

        //outside our switch statement
        //index plus equals our direction
        index += dir;

        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0) {

            index = max - 1;
        }

        if (index > max - 1) {

            index = 0;
        }

        //Material array is equal to our characters material list
        Material[] mat = charMeshRend.materials;

        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];

        //our characters materials are equal to the material array
        charMeshRend.materials = mat;

        //create another switch that is goverened by the same string name of our material

        switch (type) {

            //case skin
            case "Skin":

                //skin index equals our index
                curSkin = index;

                //break
                break;

            //same thing for Hair, 
            case "Hair":

                //skin index equals our index
                curHair = index;

                //break
                break;

            //Mouth 
            case "Mouth":

                //skin index equals our index
                curMouth = index;

                //break
                break;

            //and Eyes
            case "Eyes":

                //skin index equals our index
                curEyes = index;

                //break
                break;

            case "Armour":

                curArmour = index;
            break;

            case "Clothes":

                curClothes = index;
            break;
        }

    }

    #endregion

    #region Save

    //Function called Save this will allow us to save our indexes to PlayerPrefs
    void Save() {

        //SetInt for SkinIndex, HairIndex, MouthIndex, Eyesindex
        PlayerPrefs.SetInt("SkinIndex", curSkin);
        PlayerPrefs.SetInt("HairIndex", curHair);
        PlayerPrefs.SetInt("MouthIndex", curMouth);
        PlayerPrefs.SetInt("EyesIndex", curEyes);
        PlayerPrefs.SetInt("ArmourIndex", curArmour);
        PlayerPrefs.SetInt("ClothesIndex", curClothes);

        //SetString CharacterName
        PlayerPrefs.SetString("CharacterName", charName);
    }

    #endregion

    #region OnGUI

    //Function for our GUI elements
    void OnGUI() {

        //create the floats scrW and scrH that govern our 16:9 ratio
        float scrH = Screen.height / 9;
        float scrW = Screen.width / 16;

        //create an int that will help with shuffulling your GUI elements under eachother
        int i = 0;

        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), "<")) {

            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Skin", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Skin");

        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), ">")) {

            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            SetTexture("Skin", 1);
        }

        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;

        //set up same things for Hair,
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), "<")) {

            //when pressed the button will run SetTexture and grab the Hair Material and move the texture index in the direction  -1
            SetTexture("Hair", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Hair
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Hair");

        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), ">")) {

            //when pressed the button will run SetTexture and grab the Hair Material and move the texture index in the direction  1
            SetTexture("Hair", 1);
        }

        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;

        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), "<")) {

            //when pressed the button will run SetTexture and grab the Hair Material and move the texture index in the direction  -1
            SetTexture("Mouth", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Hair
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Mouth");

        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), ">")) {

            //when pressed the button will run SetTexture and grab the Hair Material and move the texture index in the direction  1
            SetTexture("Mouth", 1);
        }

        i++;

        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), "<")) {

            //when pressed the button will run SetTexture and grab the Hair Material and move the texture index in the direction  -1
            SetTexture("Eyes", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Hair
        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Eyes");

        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), ">")) {

            //when pressed the button will run SetTexture and grab the Hair Material and move the texture index in the direction  1
            SetTexture("Eyes", 1);
        }

        i++;

        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), "<")) {

            SetTexture("Armour", -1);
        }

        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Armour");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), ">")) {

            SetTexture("Armour", 1);
        }

        i++;

        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), "<")) {

            SetTexture("Clothes", -1);
        }

        GUI.Box(new Rect(.75f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Clothes");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (.5f * scrH), 0.5f * scrW, .5f * scrH), ">")) {

            SetTexture("Clothes", 1);
        }

        i++;

        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Random")) {

            SetTexture("Skin", Random.Range(0, skinMaxIndex - 1));
            SetTexture("Hair", Random.Range(0, hairMaxIndex - 1));
            SetTexture("Mouth", Random.Range(0, mouthMaxIndex - 1));
            SetTexture("Eyes", Random.Range(0, eyesMaxIndex - 1));
            SetTexture("Armour", Random.Range(0, armourMaxIndex - 1));
            SetTexture("Clothes", Random.Range(0, clothesMaxIndex - 1));
        }

        //Reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (.5f * scrH), scrW, .5f * scrH), "Reset")) {

            SetTexture("Skin", curSkin = 0);
            SetTexture("Hair", curHair = 0);
            SetTexture("Mouth", curMouth = 0);
            SetTexture("Eyes", curEyes = 0);
            SetTexture("Armour", curArmour = 0);
            SetTexture("Clothes", curClothes = 0);
            charName = "Astrid";
        }

        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;

        //name of our character equals a GUI TextField that holds our character name and limit of characters
        charName = GUI.TextField(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 2f * scrW, .5f * scrH), charName, 12);

        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;

        //GUI Button called Save and Play
        if (GUI.Button(new Rect(.25f * scrW, scrH + i * (.5f * scrH), 2f * scrW, .5f * scrH), "Save")) {

            Save();
            SceneManager.LoadScene("GameScene");
        }

        //this button will run the save function and also load into the game level
    }



    #endregion
}
