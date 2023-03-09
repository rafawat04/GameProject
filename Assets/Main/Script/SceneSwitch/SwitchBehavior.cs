using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    
    private int hp = 1;
    void Start()
    {
        //HeadBackが押されたら最初に戻るので
        //その時にHPも初期化されているから
        //ゲーム中のCanvasになるはず
        if(hp == 0) //戦闘中のCanvas playerHp 
        {
            GameObject Canvas = GameObject.Find ("Canvas");
            Canvas.SetActive (true);
            //switchCanvasチェックする
            GameObject SwitchCanvas = GameObject.Find ("SwitchCanvas");
            SwitchCanvas.SetActive(false);
        }
        
        //もしhpが0になったら
    
        //Canvasチェック外す
        if(hp == 1) //戦闘終わった後のメニューCanvas
        {
        GameObject Canvas = GameObject.Find ("Canvas");
        Canvas.SetActive (false);
        //switchCanvasチェックする
        GameObject SwitchCanvas = GameObject.Find ("SwitchCanvas");
        SwitchCanvas.SetActive (true);
        }
        
        //mainCameraの位置を取得(mainpoint)

        //selectCameraの位置を取得(selectpoint)

        //mainCameraをmainpointからselectpointに移動
    }
}
