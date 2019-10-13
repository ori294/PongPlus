using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusReverseAxis : MonoBehaviour
{
    public GameObject AxisReversedText;
    
    void OnTriggerEnter(Collider other)
    {
        //Get all the pedals in the game
        GameObject[] pedalGameObjects = GameObject.FindGameObjectsWithTag("Pedal");

        if (AxisReversedText.activeSelf) {
            AxisReversedText.SetActive(false);

            //re-invert the axis for the pedals.
            for (int i = 0; i < pedalGameObjects.Length; i++) {
            pedalGameObjects[i].GetComponent<PedalMovement>().isAxisReversed = false;   
            }
        } 
        else 
        {   //Invert the axis for the pedals.
             AxisReversedText.SetActive(true);
             for (int i = 0; i < pedalGameObjects.Length; i++) {
            pedalGameObjects[i].GetComponent<PedalMovement>().isAxisReversed = true;   
            }
        }
        
    }
}

