using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    private int Enemyhp = 0;
    private int Playerhp = 1;
    void Start()
    {
        /*
        if(hp == 0) //戦闘中のCanvas playerHp 
        {
            GameObject Canvas = GameObject.Find ("Canvas");
            Canvas.SetActive (true);
            //switchCanvasチェックする
            GameObject SwitchCanvas = GameObject.Find ("SwitchCanvas");
            SwitchCanvas.SetActive(false);
        }
        */
        
        //勝ったのが敵か自分かの分岐

        //もし自分が勝ったら        
        if(Playerhp == 1) 
        {
            GameObject Win = GameObject.Find ("win");

            Win.SetActive (true);

            GameObject Lose = GameObject.Find ("lose");
            Lose.SetActive (false);

            //Canvasオブジェクトの検索    
            GameObject Canvas = GameObject.Find ("Canvas");

            // チェックマークを外して非表示にする
            Canvas.SetActive (false);
            
            //SwitchCanvasオブジェクトの検索
            GameObject SwitchCanvas = GameObject.Find ("SwitchCanvas");

            //チェックマークを付けて表示にする
            SwitchCanvas.SetActive (true);

        //もし敵が勝ったら
        }else if(Enemyhp == 1)
        {

            GameObject Win = GameObject.Find ("win");

            Win.SetActive (false);

            GameObject Lose = GameObject.Find ("lose");

            Lose.SetActive (true);

            //Canvasオブジェクトの検索    
            GameObject Canvas = GameObject.Find ("Canvas");

            // チェックマークを外して非表示にする
            Canvas.SetActive (false);
            
            //SwitchCanvasオブジェクトの検索
            GameObject SwitchCanvas = GameObject.Find ("SwitchCanvas");

            //チェックマークを付けて表示にする
            SwitchCanvas.SetActive (true);
        }
        
        //mainCameraの位置を取得(mainpoint)

        //selectCameraの位置を取得(selectpoint)

        //mainCameraをmainpointからselectpointに移動
    }
}
