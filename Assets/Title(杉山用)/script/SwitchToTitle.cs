using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToTitle : MonoBehaviour
{
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }
}
