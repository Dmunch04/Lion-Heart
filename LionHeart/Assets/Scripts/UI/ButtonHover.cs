using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler {

    // This runs when you hover over an object with this script on
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Plays the button hover sound
        AudioManager.instance.Play("ButtonHover");
    }

}
