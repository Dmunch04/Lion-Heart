using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject selectionMenu;

    // Use this for initialization
    void Start()
    {
        // Runs the function for toggling the selection menu
        ToggleSelectionMenu();

        // Sets the IsOn bool from the LegendSelection script to true.
        //This will block movement and rotation and lock the cursor from start
        LegendSelection.IsOn = true;

        // Sets the IsOn bool from the PauseMenu script to false.
        // This will make sure the movement and rotation and cursor lock
        //is not activated at start
        PauseMenu.IsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the bool made in the OpenGate script is true
        if (OpenGate.IsGoing == true)
        {
            // Checks if the player presses the E key
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Runs the function for toggling the selection menu
                ToggleSelectionMenu();
            }
        }
    }

    // In this function we disables and enables the pause menu
    public void TogglePauseMenu()
    {
        // Toggles the pause menu on & off depending on it's current state
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        // Sets the bool to the state of the pause menu (On or Off)
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }

    // In this function we disables and enables the pause menu
    public void ToggleSelectionMenu ()
    {
        // Toggles the selection menu on & off depending on it's current state
        selectionMenu.SetActive(!selectionMenu.activeSelf);
        // Sets the bool to the state of the selection menu (On or Off)
        LegendSelection.IsOn = selectionMenu.activeSelf;
    }
}
