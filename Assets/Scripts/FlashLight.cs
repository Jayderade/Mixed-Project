using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    public bool lightOn;
    public Light torch;
    public float numb;



	// Use this for initialization
	void Start () {
        torch.enabled = false;
        lightOn = false;
	}
	
    IEnumerator Flicker()
    {
        lightOn = false;
        yield return new WaitForSeconds(0.01f);
        lightOn = true;
        yield return new WaitForSeconds(0.01f);
        lightOn = false;
        yield return new WaitForSeconds(0.05f);
        lightOn = true;
        yield return new WaitForSeconds(0.01f);
        lightOn = false;
        yield return new WaitForSeconds(0.01f);
        lightOn = true;
        yield return new WaitForSeconds(0.01f);
        lightOn = false;
        yield return new WaitForSeconds(0.05f);
        lightOn = true;
        yield return new WaitForSeconds(0.01f);
        lightOn = false;
        yield return new WaitForSeconds(0.01f);
        lightOn = true;
        yield return new WaitForSeconds(0.01f);
        lightOn = false;
    }

	// Update is called once per frame
	void Update () {

        

        numb = Random.Range(0,1000);
                
        if (numb == 500 && lightOn)
        {
            StartCoroutine(Flicker());
        }

        if (Input.GetMouseButtonDown(1))
        {
            lightOn = true;
        }

        if(lightOn)
        {
            torch.enabled = true;
        }

        if(Input.GetMouseButtonDown(0))
        {            
            lightOn = false;
        }
        if(lightOn == false)
        {
            torch.enabled = false;
        }
    }
}
