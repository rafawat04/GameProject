using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMain : MonoBehaviour
{
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}
