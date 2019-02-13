using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject gameSelectionMenu;

    public void OpenGameSelectionMenu()
    {
        if (gameSelectionMenu.gameObject.activeInHierarchy == false)
        {
            gameSelectionMenu.gameObject.SetActive(true);
        }
        else
        {
            gameSelectionMenu.gameObject.SetActive(false);
        }
    }

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
