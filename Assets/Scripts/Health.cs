using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    public GameObject player;
    public GameObject customMenu;
    public float health;
    public Light faceLight;
    

    void Update()
    {
        if (health <= 75 && health > 50)
        {
            faceLight.color = Color.red;
            faceLight.intensity = 4;
        }

        if (health <= 50 && health > 25)
        {
            faceLight.color = Color.red;
            faceLight.intensity = 6;
        }

        if (health <= 25)
        {
            faceLight.color = Color.red;
            faceLight.intensity = 8;
        }
        if(health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void Start()
    {
        
        Customize customScript = customMenu.GetComponent<Customize>();
        health = customScript.healthIndex * 10;
       



    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
