using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    #region Variables
    [Header("Material Arrays")]
    //Material List 
    public List<Material> skin = new List<Material>();
    public List<Material> hair = new List<Material>();
    public List<Material> hat = new List<Material>();
    public List<Material> shirt = new List<Material>();
    public List<Material> sleeves = new List<Material>();
    public List<Material> eyes = new List<Material>();
    [Header("Index")]
    //index numbers for our current skin, hair, hat, shirt, sleeves, eyes textures
    public int skinIndex;
    public int hairIndex;
    public int hatIndex;
    public int shirtIndex;
    public int sleevesIndex;
    public int eyesIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer head, ears, nose, arms;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMaxIndex;
    public int hairMaxIndex, hatMaxIndex, shirtMaxIndex, sleevesMaxIndex, eyesMaxIndex;
    #endregion

    #region Start
    //in start we need to set up the following
    void Start()
    {


        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Material temp = Resources.Load("PlayerMats/Skin/Skin_0" + i.ToString()) as Material;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < hairMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Material temp = Resources.Load("PlayerMats/Hair/Hair_0" + i.ToString()) as Material;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < shirtMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Material temp = Resources.Load("PlayerMats/Shirt/Shirt_0" + i.ToString()) as Material;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < sleevesMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Material temp = Resources.Load("PlayerMats/Sleeves/Sleeves/Sleeve_0" + i.ToString()) as Material;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < hatMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Material temp = Resources.Load("PlayerMats/Hat/Hat_0" + i.ToString()) as Material;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < eyesMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Material temp = Resources.Load("PlayerMats/Eye/Iris/Iris_0" + i.ToString()) as Material;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        head = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Hair", 0);
        SetTexture("Hat", 0);
        SetTexture("Shirt", 0);
        SetTexture("Sleeves", 0);
        SetTexture("Eyes", 0);

        #endregion
    }
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    void SetTexture(string type, int dir)
    {
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, matIndex = 0;
        Material[] textures = new Material[0];
        //inside a switch statement that is swapped by the string name of our material
        switch (type)
        {
            //case skin
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
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
                //index is the same as our skin index
                index = hairIndex;
                //max is the same as our skin max
                max = hairMaxIndex;
                //textures is our skin list .ToArray()
                textures = hair.ToArray();
                //material index element number is 2
                matIndex = 2;
                //break
                break;
            //mouth is 3
            case "Hat":
                //index is the same as our skin index
                index = hatIndex;
                //max is the same as our skin max
                max = hatMaxIndex;
                //textures is our skin list .ToArray()
                textures = hat.ToArray();
                //material index element number is 3
                matIndex = 3;
                //break
                break;
            //eyes are 4
            case "Eyes":
                //index is the same as our skin index
                index = eyesIndex;
                //max is the same as our skin max
                max = eyesMaxIndex;
                //textures is our skin list .ToArray()
                textures = eyes.ToArray();
                //material index element number is 4
                matIndex = 4;
                //break
                break;
            //eyes are 4
            case "Shirt":
                //index is the same as our skin index
                index = shirtIndex;
                //max is the same as our skin max
                max = shirtMaxIndex;
                //textures is our skin list .ToArray()
                textures = shirt.ToArray();
                //material index element number is 4
                matIndex = 5;
                //break
                break;
            //eyes are 4
            case "Sleeves":
                //index is the same as our skin index
                index = sleevesIndex;
                //max is the same as our skin max
                max = sleevesMaxIndex;
                //textures is our skin list .ToArray()
                textures = sleeves.ToArray();
                //material index element number is 4
                matIndex = 6;
                //break
                break;
        }
        //outside our switch statement
        //index plus equals our direction
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = head.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        head.materials = mat;
        //create another switch that is goverened by the same string name of our material
        switch (type)
        {
            //case skin
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                //break
                break;
            //case hair
            case "Hair":
                //skin index equals our index
                hairIndex = index;
                //break
                break;
            //case mouth
            case "Hat":
                //skin index equals our index
                hatIndex = index;
                //break
                break;
            //case eyes
            case "Eyes":
                //skin index equals our index
                eyesIndex = index;
                //break
                break;
        }
    }
    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes to PlayerPrefs
    void Save()
    {
        //SetInt for SkinIndex, HairIndex, MouthIndex, Eyesindex
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("HatIndex", hatIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
       
    }
    #endregion

    #region OnGUI
    //Function for our GUI elements
    void OnGUI()
    {

        //create the floats scrW and scrH that govern our 16:9 ratio
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        //create an int that will help with shuffulling your GUI elements under eachother
        int i = 0;
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Skin", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Skin");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        {
            SetTexture("Skin", 1);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //set up same things for Hair, Mouth and Eyes
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Hair", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Hair");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        {
            SetTexture("Hair", 1);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Hat", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Hat");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        {
            SetTexture("Hat", 1);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
            SetTexture("Eyes", -1);
        }
        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Eyes");
        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        {
            SetTexture("Eyes", 1);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
        {
            SetTexture("Skin", Random.Range(0, skinMaxIndex - 1));
            SetTexture("Hair", Random.Range(0, hairMaxIndex - 1));
            SetTexture("Hat", Random.Range(0, hatMaxIndex - 1));
            SetTexture("Eyes", Random.Range(0, eyesMaxIndex - 1));
        }
        //reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Default"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Hat", hatIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
       
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //GUI Button called Save and Play
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Save & Play"))
        {
            //this button will run the save function and also load into the game level
            Save();
            SceneManager.LoadScene(1);
        }
    }
    #endregion
}
