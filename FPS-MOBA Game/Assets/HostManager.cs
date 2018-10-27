using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HostManager : MonoBehaviour {

    public Text errorText;

    [HideInInspector]
    public string matchName;

    public void SetMatchName(string _name)
    {
        matchName = _name;
    }

    public void StartMatch ()
    {
        if (matchName != "" && matchName != null)
        {
            SceneManager.LoadScene("LegendSelection");
        }
        else
        {
            errorText.text = "Please give the match a name!";
        }
    }

}
