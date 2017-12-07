using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Customize : MonoBehaviour
{
    [Header("Character")]
    public GameObject character;
    public GameObject haveHat;
    public Dropdown dropdown;
    public Scene currentScene;
    

    [Header("Bools")]
    public bool hatOn;
    public bool sleeveless;
    public bool shirtless;
    public bool gameScene;
    public int hatInt;
    public int sleeveInt;
    public int shirtInt;

    [Header("Indexes")]
    public int skinIndex;
    public int skinMaxIndex;
    public int hatIndex;
    public int hatMaxIndex;
    public int shirtIndex;
    public int shirtMaxIndex;
    public int hairIndex;
    public int hairMaxIndex;
    public int eyeIndex;
    public int eyeMaxIndex;
    public int sleeveIndex;
    public int sleeveMaxIndex;

    [Header("Stats")]
    public int skillPoints;
           
    public int healthIndex;
    public int healthMinIndex;
    public int healthMaxIndex;
           
    public int speedIndex;
    public int speedMinIndex;
    public int speedMaxIndex;
           
    public int damageIndex;
    public int damageMinIndex;
    public int damageMaxIndex;
           
    public int staminaIndex;
    public int staminaMinIndex;
    public int staminaMaxIndex;
           
    public int armorIndex;
    public int armorMinIndex;
    public int armorMaxIndex;
           
    public int accuracyIndex;
    public int accuracyMinIndex;
    public int accuracyMaxIndex;


    [Header("Renderer Arrays")]
    public Renderer[] skin;
    public Renderer[] hat;
    public Renderer[] eye;
    public Renderer[] sleeve;
    public Renderer[] hair;
    public Renderer[] shirt;

    [Header("Materials")]
    public Material[] shirtMat;
    public Material[] skinMat;
    public Material[] hatMat;
    public Material[] hairMat;
    public Material[] eyeMat;
    public Material[] sleeveMat;

    [Header("Art")]
    public GUISkin menuSkin;

    void Awake()
    {
        Load();
        currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Game Scene")
        {
            gameScene = true;            
        }
        else
        {
            gameScene = false;
        }
    }

    void Load()
    {
       
        skinIndex = PlayerPrefs.GetInt("SkinIndex");
        hairIndex =  PlayerPrefs.GetInt("HairIndex");
        shirtIndex = PlayerPrefs.GetInt("ShirtIndex");
        hatIndex = PlayerPrefs.GetInt("HatIndex");
        eyeIndex =  PlayerPrefs.GetInt("EyesIndex");
        sleeveIndex = PlayerPrefs.GetInt("SleeveIndex");
        healthIndex = PlayerPrefs.GetInt("HealthIndex");
        speedIndex = PlayerPrefs.GetInt("SpeedIndex");
        staminaIndex = PlayerPrefs.GetInt("StaminaIndex");
        armorIndex = PlayerPrefs.GetInt("ArmorIndex");
        damageIndex = PlayerPrefs.GetInt("DamageIndex");
        accuracyIndex = PlayerPrefs.GetInt("AccuracyIndex");
        dropdown.value = PlayerPrefs.GetInt("Class");
        hatInt = PlayerPrefs.GetInt("HatBool");
        shirtInt = PlayerPrefs.GetInt("Shirtless");
        sleeveInt = PlayerPrefs.GetInt("Sleeveless");

        if (hatInt == 1)
        {
            hatOn = true;
        }
        else
        {
            hatOn = false;
        }

        if (shirtInt == 1)
        {
            shirtless = false;
        }
        else
        {
            shirtless = true;
        }

        if (sleeveInt == 1)
        {
            sleeveless = false;
        }
        else
        {
            sleeveless = true;
        }
    }

    // Use this for initialization
    void Start()
    {
        

        
        skinMaxIndex = skinMat.Length - 1;
        
        hatMaxIndex = hatMat.Length - 1;
        
        shirtMaxIndex = shirtMat.Length - 1;
        
        hairMaxIndex = hairMat.Length - 1;
        
        eyeMaxIndex = eyeMat.Length - 1;
        
        sleeveMaxIndex = sleeveMat.Length - 1;


        
        
        healthMaxIndex = 20;
        healthMinIndex =10;

        
        speedMaxIndex = 20;
        speedMinIndex = 10;

        
        damageMinIndex = 10;
        damageMaxIndex = 20;

        
        staminaMinIndex = 10;
        staminaMaxIndex = 20;

        
        armorMinIndex = 10;
        armorMaxIndex = 20;

        
        accuracyMinIndex = 10;
        accuracyMaxIndex = 20;

        

    }

    void Save()
    {
        
        //SetInt for SkinIndex, HairIndex, MouthIndex, Eyesindex
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("HatIndex", hatIndex);
        PlayerPrefs.SetInt("EyesIndex", eyeIndex);
        PlayerPrefs.SetInt("ShirtIndex", shirtIndex);
        PlayerPrefs.SetInt("SleeveIndex", sleeveIndex);
        PlayerPrefs.SetInt("HealthIndex", healthIndex);
        PlayerPrefs.SetInt("SpeedIndex",speedIndex);
        PlayerPrefs.SetInt("DamageIndex",damageIndex);
        PlayerPrefs.SetInt("StaminaIndex",staminaIndex);
        PlayerPrefs.SetInt("ArmorIndex",armorIndex);
        PlayerPrefs.SetInt("AccuracyIndex",accuracyIndex);
        PlayerPrefs.SetInt("Class", dropdown.value);
    }

    public void DropDown()
    {
        switch (dropdown.value)
        {
            case 0:
                Soldier();
                break;
            case 1:
                Juggernaut();
                break;
            case 2:
                Assassin();
                break;
            case 3:
                Scout();
                break;
            case 4:
                Tank();
                break;
            case 5:
                Sharpshooter();
                break;
            case 6:
                Custom();
                break;
        }
        
            

    }

    #region Classes
   public void Soldier()
    {
        healthIndex = 15;
        speedIndex = 15;
        damageIndex = 15;
        staminaIndex = 15;
        armorIndex = 15;
        accuracyIndex = 15;
        skillPoints = 0;
    }

   public void Juggernaut()
    {
        healthIndex = 17;
        speedIndex = 12;
        damageIndex = 17;
        staminaIndex = 12;
        armorIndex = 17;
        accuracyIndex = 15;
        skillPoints = 0;
    }

   public void Assassin()
    {
        healthIndex = 11;
        speedIndex = 18;
        damageIndex = 19;
        staminaIndex = 17;
        armorIndex = 10;
        accuracyIndex = 15;
        skillPoints = 0;
    }

   public void Scout()
    {
        healthIndex = 13;
        speedIndex = 20;
        damageIndex = 14;
        staminaIndex = 20;
        armorIndex = 10;
        accuracyIndex = 13;
        skillPoints = 0;
    }

   public void Tank()
    {
        healthIndex = 20;
        speedIndex = 10;
        damageIndex = 15;
        staminaIndex = 13;
        armorIndex = 20;
        accuracyIndex = 12;
        skillPoints = 0;
    }

   public void Sharpshooter()
    {
        healthIndex = 15;
        speedIndex = 13;
        damageIndex = 20;
        staminaIndex = 12;
        armorIndex = 10;
        accuracyIndex = 20;
        skillPoints = 0;

    }

   public void Custom()
    {
        healthIndex = 10;
        speedIndex = 10;
        damageIndex = 10;
        staminaIndex = 10;
        armorIndex = 10;
        accuracyIndex = 10;
        skillPoints = 30;
    }
    #endregion
    void OnGUI()
    {
        if (!gameScene)
        {

            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;

            int i = 0;

            GUI.skin = menuSkin;

            #region Skin
            if (GUI.Button(new Rect(13f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                skinIndex = skinIndex - 1;
            }
            GUI.Box(new Rect(13.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Skin");

            if (GUI.Button(new Rect(15f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                skinIndex = skinIndex + 1;
            }
            #endregion
            #region Hat
            if (GUI.Button(new Rect(13f * scrW, scrH + 1 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                hatIndex = hatIndex - 1;
            }
            GUI.Box(new Rect(13.5f * scrW, scrH + 1 * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Hat");

            if (GUI.Button(new Rect(15f * scrW, scrH + 1 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                hatIndex = hatIndex + 1;
            }

            hatOn = (GUI.Toggle(new Rect((12.5f * scrW), scrH + 1 * (0.5f * scrH), scrW, 0.5f * scrH), hatOn, ""));

            if (hatOn)
            {
                haveHat.SetActive(true);
                PlayerPrefs.SetInt("HatBool", 1);
            }
            else
            {
                haveHat.SetActive(false);
                PlayerPrefs.SetInt("HatBool", 0);
            }

            #endregion
            #region Shirt
            if (GUI.Button(new Rect(13f * scrW, scrH + 2 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                shirtIndex = shirtIndex - 1;
            }
            GUI.Box(new Rect(13.5f * scrW, scrH + 2 * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Shirt");

            if (GUI.Button(new Rect(15f * scrW, scrH + 2 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                shirtIndex = shirtIndex + 1;
            }

            shirtless = (GUI.Toggle(new Rect((12.5f * scrW), scrH + 2 * (0.5f * scrH), scrW, 0.5f * scrH), shirtless, ""));

            if (!shirtless)
            {
                PlayerPrefs.SetInt("Shirtless", 1);
                sleeveless = false;
                foreach (Renderer shirts in shirt)
                {
                    shirts.material = skinMat[skinIndex];
                }

            }
            else
            {
                PlayerPrefs.SetInt("Shirtless", 0);
            }

            #endregion
            #region Hair
            if (GUI.Button(new Rect(13f * scrW, scrH + 3 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                hairIndex = hairIndex - 1;
            }
            GUI.Box(new Rect(13.5f * scrW, scrH + 3 * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Hair");

            if (GUI.Button(new Rect(15f * scrW, scrH + 3 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                hairIndex = hairIndex + 1;
            }
            #endregion
            #region Eyes
            if (GUI.Button(new Rect(13f * scrW, scrH + 4 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                eyeIndex = eyeIndex - 1;
            }
            GUI.Box(new Rect(13.5f * scrW, scrH + 4 * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Eyes");

            if (GUI.Button(new Rect(15f * scrW, scrH + 4 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                eyeIndex = eyeIndex + 1;
            }
            #endregion
            #region Sleeves
            if (GUI.Button(new Rect(13f * scrW, scrH + 5 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                sleeveIndex = sleeveIndex - 1;
            }
            GUI.Box(new Rect(13.5f * scrW, scrH + 5 * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Sleeves");

            if (GUI.Button(new Rect(15f * scrW, scrH + 5 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                sleeveIndex = sleeveIndex + 1;
            }

            sleeveless = (GUI.Toggle(new Rect((12.5f * scrW), scrH + 5 * (0.5f * scrH), scrW, 0.5f * scrH), sleeveless, ""));

           

            #endregion
            #region Random
            if (GUI.Button(new Rect(13f * scrW, scrH + 6 * (0.5f * scrH), 2.5f * scrW, 0.5f * scrH), "Random"))
            {
                skinIndex = Random.Range(0, skinMat.Length);
                hairIndex = Random.Range(0, hairMat.Length);
                shirtIndex = Random.Range(0, shirtMat.Length);
                hatIndex = Random.Range(0, hatMat.Length);
                eyeIndex = Random.Range(0, eyeMat.Length);
                sleeveIndex = Random.Range(0, sleeveMat.Length);
            }
            #endregion
            #region Default
            if (GUI.Button(new Rect(13f * scrW, scrH + 7 * (0.5f * scrH), 2.5f * scrW, 0.5f * scrH), "Default"))
            {
                skinIndex = 5;
                hairIndex = 5;
                shirtIndex = 5;
                hatIndex = 5;
                eyeIndex = 5;
                sleeveIndex = 5;
            }
            #endregion
            #region Save & Continue
            if (GUI.Button(new Rect(12.5f * scrW, scrH + 14 * (0.5f * scrH), 3f * scrW, 0.5f * scrH), "Save & Continue"))
            {
                Debug.Log("Save");
                Save();
                SceneManager.LoadScene(1);
            }
            #endregion
            #region Stats
            #region Health
            if (GUI.Button(new Rect(9f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
            {
                if (healthIndex > healthMinIndex)
                {
                    healthIndex = healthIndex - 1;
                    skillPoints++;
                }
            }
            GUI.Box(new Rect(9.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.75f * scrH), "Health");

            if (GUI.Button(new Rect(11f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                if (skillPoints > 0)
                {
                    if (healthIndex < healthMaxIndex)
                    {
                        healthIndex = healthIndex + 1;
                        skillPoints--;
                    }
                }
            }
            GUI.Box(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 0.75f * scrW, 0.75f * scrH), healthIndex.ToString());
            #endregion
            #region Speed
            if (GUI.Button(new Rect(9f * scrW, scrH + 2 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
            {
                if (speedIndex > speedMinIndex)
                {
                    speedIndex = speedIndex - 1;
                    skillPoints++;
                }
            }
            GUI.Box(new Rect(9.5f * scrW, scrH + 2 * (0.5f * scrH), 1.5f * scrW, 0.75f * scrH), "Speed");

            if (GUI.Button(new Rect(11f * scrW, scrH + 2 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                if (skillPoints > 0)
                {
                    if (speedIndex < speedMaxIndex)
                    {
                        speedIndex = speedIndex + 1;
                        skillPoints--;
                    }
                }
            }
            GUI.Box(new Rect(8f * scrW, scrH + 2 * (0.5f * scrH), 0.75f * scrW, 0.75f * scrH), speedIndex.ToString());
            #endregion
            #region Damage
            if (GUI.Button(new Rect(9f * scrW, scrH + 4 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
            {
                if (damageIndex > damageMinIndex)
                {
                    damageIndex = damageIndex - 1;
                    skillPoints++;
                }
            }
            GUI.Box(new Rect(9.5f * scrW, scrH + 4 * (0.5f * scrH), 1.5f * scrW, 0.75f * scrH), "Damage");

            if (GUI.Button(new Rect(11f * scrW, scrH + 4 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                if (skillPoints > 0)
                {
                    if (damageIndex < damageMaxIndex)
                    {
                        damageIndex = damageIndex + 1;
                        skillPoints--;
                    }
                }
            }
            GUI.Box(new Rect(8f * scrW, scrH + 4 * (0.5f * scrH), 0.75f * scrW, 0.75f * scrH), damageIndex.ToString());
            #endregion
            #region Stamina
            if (GUI.Button(new Rect(9f * scrW, scrH + 6 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
            {
                if (staminaIndex > staminaMinIndex)
                {
                    staminaIndex = staminaIndex - 1;
                    skillPoints++;
                }
            }
            GUI.Box(new Rect(9.5f * scrW, scrH + 6 * (0.5f * scrH), 1.5f * scrW, 0.75f * scrH), "Stamina");

            if (GUI.Button(new Rect(11f * scrW, scrH + 6 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                if (skillPoints > 0)
                {
                    if (staminaIndex < staminaMaxIndex)
                    {
                        staminaIndex = staminaIndex + 1;
                        skillPoints--;
                    }
                }
            }
            GUI.Box(new Rect(8f * scrW, scrH + 6 * (0.5f * scrH), 0.75f * scrW, 0.75f * scrH), staminaIndex.ToString());
            #endregion
            #region Armor
            if (GUI.Button(new Rect(9f * scrW, scrH + 8 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
            {
                if (armorIndex > armorMinIndex)
                {
                    armorIndex = armorIndex - 1;
                    skillPoints++;
                }
            }
            GUI.Box(new Rect(9.5f * scrW, scrH + 8 * (0.5f * scrH), 1.5f * scrW, 0.75f * scrH), "Armor");

            if (GUI.Button(new Rect(11f * scrW, scrH + 8 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                if (skillPoints > 0)
                {
                    if (armorIndex < armorMaxIndex)
                    {
                        armorIndex = armorIndex + 1;
                        skillPoints--;
                    }
                }
            }
            GUI.Box(new Rect(8f * scrW, scrH + 8 * (0.5f * scrH), 0.75f * scrW, 0.75f * scrH), armorIndex.ToString());
            #endregion
            #region Accuracy
            if (GUI.Button(new Rect(9f * scrW, scrH + 10 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
            {
                if (accuracyIndex > accuracyMinIndex)
                {
                    accuracyIndex = accuracyIndex - 1;
                    skillPoints++;
                }
            }
            GUI.Box(new Rect(9.5f * scrW, scrH + 10 * (0.5f * scrH), 1.5f * scrW, 0.75f * scrH), "Accuracy");

            if (GUI.Button(new Rect(11f * scrW, scrH + 10 * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            {
                if (skillPoints > 0)
                {
                    if (accuracyIndex < accuracyMaxIndex)
                    {
                        accuracyIndex = accuracyIndex + 1;
                        skillPoints--;
                    }
                }
            }
            GUI.Box(new Rect(8f * scrW, scrH + 10 * (0.5f * scrH), 0.75f * scrW, 0.75f * scrH), accuracyIndex.ToString());
            #endregion
            #region Skill Points
            GUI.Box(new Rect(8f * scrW, scrH + 12 * (0.5f * scrH), 3.5f * scrW, .75f * scrH), "Skill Points: " + skillPoints.ToString());
            #endregion
            #endregion
        }
    }

    // Update is called once per frame
    void Update()
    {
        //shirt.material = shirtMat[Random.Range(0, shirtMat.Length)];
        #region Skin
        if (skinIndex < 0)
        {
            skinIndex = skinMat.Length - 1;
        }

        if (skinIndex > skinMat.Length - 1)
        {
            skinIndex = 0;
        }

        foreach (Renderer skins in skin)
        {
            skins.material = skinMat[skinIndex];
        }
        #endregion
        #region Hat
        if (hatIndex < 0)
        {
            hatIndex = hatMat.Length - 1;
        }

        if (hatIndex > hatMat.Length - 1)
        {
            hatIndex = 0;
        }

        foreach (Renderer hats in hat)
        {
            hats.material = hatMat[hatIndex];
        }
        if (hatOn)
        {
            haveHat.SetActive(true);
            PlayerPrefs.SetInt("HatBool", 1);
        }
        else
        {
            haveHat.SetActive(false);
            PlayerPrefs.SetInt("HatBool", 0);
        }
        #endregion        
        #region Shirt
        if (shirtIndex < 0)
        {
            shirtIndex = shirtMat.Length - 1;
        }

        if (shirtIndex > shirtMat.Length - 1)
        {
            shirtIndex = 0;
        }

        if (shirtless)
        {
            foreach (Renderer shirts in shirt)
            {
                shirts.material = shirtMat[shirtIndex];
            }
        }
        if (!shirtless)
        {
            PlayerPrefs.SetInt("Shirtless", 1);
            sleeveless = false;
            foreach (Renderer shirts in shirt)
            {
                shirts.material = skinMat[skinIndex];
            }

        }
        else
        {
            PlayerPrefs.SetInt("Shirtless", 0);
        }
        #endregion
        #region Hair
        if (hairIndex < 0)
        {
            hairIndex = hairMat.Length - 1;
        }

        if (hairIndex > hairMat.Length - 1)
        {
            hairIndex = 0;
        }

        foreach (Renderer hairs in hair)
        {
            hairs.material = hairMat[hairIndex];
        }
        #endregion
        #region Eyes
        if (eyeIndex < 0)
        {
            eyeIndex = eyeMat.Length - 1;
        }

        if (eyeIndex > eyeMat.Length - 1)
        {
            eyeIndex = 0;
        }

        foreach (Renderer eyes in eye)
        {
            eyes.material = eyeMat[eyeIndex];
        }
        #endregion
        #region Sleeves
        if (sleeveIndex < 0)
        {
            sleeveIndex = sleeveMat.Length - 1;
        }

        if (sleeveIndex > sleeveMat.Length - 1)
        {
            sleeveIndex = 0;
        }

        if (sleeveless)
        {
            foreach (Renderer sleeves in sleeve)
            {
                sleeves.material = sleeveMat[sleeveIndex];
            }
        }

        if (!sleeveless)
        {
            PlayerPrefs.SetInt("Sleeveless", 1);
            foreach (Renderer sleeves in sleeve)
            {
                sleeves.material = skinMat[skinIndex];
            }

        }
        else
        {
            PlayerPrefs.SetInt("Sleeveless", 0);
        }
        #endregion
    }
}
