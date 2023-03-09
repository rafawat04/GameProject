using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadBack : MonoBehaviour
{
    public void OnButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject Canvas = GameObject.Find ("Canvas");
        Canvas.SetActive (true);
        //switchCanvasチェックする
        GameObject SwitchCanvas = GameObject.Find ("SwitchCanvas");
        SwitchCanvas.SetActive(false);

        


    }
}
