﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MouseLook : MonoBehaviour
    {
        //Before you write this section please scroll to the bottom of the page
        #region Variables
        //[Header("Rotational Axis")]
        [Header("Rotational Axis")]

        //create a public link to the rotational axis called axis and set a defualt axis
        public RotationalAxis axis = RotationalAxis.MouseX;

        //[Header("sensitivity")]
        [Header("Sensitivity")]

        //public floats for our x and y sensitivity
        public float sensitivityX = 15f;
        public float sensitivityY = 15f;

        //[Header("Y Rotation Clamp")]
        [Header("Y Rotation Clamp")]

        //max and min Y rotation
        public float minimumY = -60f;
        public float maximumY = 60f;

        //we will have to invert our mouse position later to calculate our mouse look correctly
        //float for rotation Y
        float rotationY = 0;

        #endregion
        #region Start
        void Start()
        {
            //if our game object has a rigidbody attached to it
            if (this.GetComponent<Rigidbody>())
            {
                //set the rigidbodys freezRotaion to true
                GetComponent<Rigidbody>().freezeRotation = true;
            }
        Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        #endregion
        #region Update
        void Update()
        {
            #region Mouse X and Y
            //if our axis is set to Mouse X and Y
            if (axis == RotationalAxis.MouseXAndY)
            {
                //float rotation x is equal to our y axis plus the mouse input on the Mouse X times our x sensitivity
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
                rotationY += Input.GetAxis("Mouse Y") * sensitivityX;

                //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and x rotation on the y axis
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            #endregion

            #region Mouse X
            //else if we are rotating on the X
            else if (axis == RotationalAxis.MouseX)
            {
                //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            #endregion

            #region Mouse Y
            else //else we are only rotation on the Y
            {
                //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

                //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis
                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
            #endregion
        }
        #endregion
    }
    #region RotationalAxis
   
    //Create a public enum called RotationalAxis
    public enum RotationalAxis
    {
        //MouseXandY
        MouseXAndY = 0,

        //MouseX
        MouseX = 1,

        //MouseY
        MouseY = 2
    }
    //Creating an enum out side the script and making it public means it can be asessed anywhere in any script with out reference
    #endregion


