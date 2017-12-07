using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    #region Variables

    public GameObject customMenu;
    
    [Header("Character's MoveDirection")]

    //vector3 called moveDirection
    //we will use this to apply movement in worldspace
    public Vector3 moveDir = Vector3.zero;

    
    private CharacterController charC;


    [Header("Variables")]

    //public float variables jumpSpeed, speed, gravity
    public float damage;
    public float stamina;
    public float armor;    
    public float speed;
    public float accuracy;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [Header("Stamina")]
    public float staminaTimerFloat;
    public float staminaTimerMax;
    public float staminaTimerCountdown;
    public bool staminaBool;
    public GUIStyle staminaBarOrange;

    

    [Header("Armor")]
    public float armorCounter, armorMax;
    public bool armorBool;
    public GUIStyle armorBarOrange;

    #endregion

    #region Start
    void Start()
    {
        Customize customScript = customMenu.GetComponent<Customize>();

        speed = customScript.speedIndex;
        damage = customScript.damageIndex;
        stamina = customScript.staminaIndex;
        armor = customScript.armorIndex;
        accuracy = customScript.accuracyIndex;

        /*speed = speed * 0.5f;
        damage = damage * 0.5f;
        stamina = stamina * 0.5f;
        armor = armor * 0.5f;
        accuracy = accuracy * 0.5f;*/




        //charc is on this game object we need to get the character controller that is attached to it
        charC = this.GetComponent<CharacterController>();

        staminaTimerCountdown = 1;
        staminaBool = false;

        //Debug.Log("playerMana = " + gameObject.GetComponent<PlayerStats>().playerMana);
        armorBool = false;

        

        //Debug.Log("PlayerStat's playerStamina = " + gameObject.GetComponent<PlayerStats>().playerStamina);
    }
    #endregion

    #region Update
    void Update()
    {
        GetStaminaStatFunction();

        GetArmorCount();

        //if our character is grounded
        if (charC.isGrounded)
        {
            
            //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            //moveDir is transformed in the direction of our moveDir
            moveDir = transform.TransformDirection(moveDir);

            //our moveDir is then multiplied by our speed
            moveDir *= speed;

            //we can also jump if we are grounded so
            //in the input button for jump is pressed then
            /*if (Input.GetButton("Jump"))
            {
                //our moveDir.y is equal to our jump speed
                moveDir.y = jumpSpeed;
            }*/

            StaminaTimerFunction();
        }

        //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
        moveDir.y -= gravity * Time.deltaTime;

        //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
        charC.Move(moveDir * Time.deltaTime);

        
    }
    #endregion

    void StaminaTimerFunction() // if Player is pressing a Movement Key, minus Stamina/reduce Speed, if not, increase Stamina/normal Speed
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) // I didn't do this for the Arrow Keys for easier Debugging, since of my time is spent Debugging
        {
            staminaTimerFloat = staminaTimerFloat - (staminaTimerCountdown * Time.deltaTime);
            //Debug.Log("staminaTimerFloat = " + staminaTimerFloat);

            if (staminaTimerFloat <= 0) // keep from going below Zero
            {
                staminaTimerFloat = 0;
                
            }

            if (staminaTimerFloat > 0) // to allow normal speed if stamina above 0
            {
                speed = customMenu.GetComponent<Customize>().speedIndex;


            }
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            staminaTimerFloat = staminaTimerFloat + ((staminaTimerCountdown * 2) * Time.deltaTime);
            //Debug.Log("staminaTimerFloat = " + staminaTimerFloat);

            if (staminaTimerFloat >= staminaTimerMax) // keep from going above Max Stat value
            {
                staminaTimerFloat = staminaTimerMax;
                speed = customMenu.GetComponent<Customize>().staminaIndex;
            }
        }
    }

    void GetStaminaStatFunction() // Get Stamina value
    {
        if (customMenu.GetComponent<Customize>().staminaIndex != 0 && staminaBool == false)
        {
            switch (customMenu.GetComponent<Customize>().staminaIndex)
            {
                case 1:
                    staminaTimerFloat = 1f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 2:
                    staminaTimerFloat = 2f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 3:
                    staminaTimerFloat = 3f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 4:
                    staminaTimerFloat = 4f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 5:
                    staminaTimerFloat = 5f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 6:
                    staminaTimerFloat = 6f;
                    staminaTimerMax = staminaTimerFloat;

                    break;
            }

            staminaBool = true;
        }
    }       

    void GetArmorCount()
    {
        if (armorBool == false && customMenu.GetComponent<Customize>().armorIndex != 0)
        {
            armorCounter = customMenu.GetComponent<Customize>().armorIndex;
            armorMax = armorCounter;

            //Debug.Log("manaCounter = " + manaCounter);

            armorBool = true;
        }
    }

    void OnGUI()
    {

        if (SceneManager.GetActiveScene().name == "Game")
        {
            float scrW = Screen.width / 16; // Dividing Screen Width into 16 parts, value of scrW = 1
            float scrH = Screen.height / 9; // Dividing Screen Height into 9 parts, value of scrH = 1

            //GUI.Box(new Rect(6f * scrW, scrH, 4 * scrW, 0.5f * scrH), "HEALTH"); //
            //GUI.Box(new Rect(6f * scrW, scrH, playerHealth * (4 * scrW) / playerHealthMax, 0.5f * scrH), "", healthBarRed); //

            // MANA
            GUI.Box(new Rect(6f * scrW, 8f * scrH, 4 * scrW, 0.5f * scrH), ""); //
            GUI.Box(new Rect(6f * scrW, 8f * scrH, armorCounter * (4 * scrW) / armorMax, 0.5f * scrH), "", armorBarOrange); //

            // STAMINA
            GUI.Box(new Rect(6f * scrW, 7.5f * scrH, 4 * scrW, 0.5f * scrH), ""); //
            GUI.Box(new Rect(6f * scrW, 7.5f * scrH, staminaTimerFloat * (4 * scrW) / staminaTimerMax, 0.5f * scrH), "", staminaBarOrange);
        }
    }



}
