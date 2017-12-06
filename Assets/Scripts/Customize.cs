using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize : MonoBehaviour {
    [Header("Character")]
    public GameObject character;

    [Header("Indexes")]
    public int skinIndex;

    [Header("Renderer Arrays")]
    public Renderer[] skin;
    public Renderer[] hat;
    public Renderer[] eyes;
    public Renderer[] sleeves;
    public Renderer[] hair;

    [Header("Renderers")]
    public Renderer shirt;
    
    [Header("Materials")]
    public Material[] shirtMat;
    public Material[] skinMat;

	// Use this for initialization
	void Start () {

        skinIndex = Random.Range(0,skinMat.Length);

       
        foreach(Renderer skins in skin)
        {
            skins.material = skinMat[skinIndex];
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        // shirt.material = shirtMat[Random.Range(0, shirtMat.Length)];
        
    }
}
