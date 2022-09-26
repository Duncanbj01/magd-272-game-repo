using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//main data types in c#
//integer- any number that isnt a decimal (positive, negative, and 0)
//float- any number that is a decimal
//string- grouping of characters
//array- list, dictionary 

public class CodingIntro : MonoBehaviour
{
    string myName = "Brian";
    int myAge = 27; 


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*myAge++; 
        Debug.Log("Hi my name is " + myName + " and I am " + myAge);*/

        Debug.Log(Input.GetAxisRaw("Horizontal") + " " + Input.GetAxisRaw("Vertical")); 
    }
}
