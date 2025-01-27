using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{

    public Text resultText;
    public Text rankText;

  private void Start()
    {
        // PlayerPrefsから保存されたタイマー値を取得
        if (PlayerPrefs.HasKey("FinalTime"))
        {
            float finalTime = PlayerPrefs.GetFloat("FinalTime");
            int minutes = Mathf.FloorToInt(finalTime / 60);
            int seconds = Mathf.FloorToInt(finalTime % 60);
            resultText.text = string.Format("残り時間    :    {0:00}:{1:00}", minutes, seconds);

            if(finalTime >= 180f)
            {
                rankText.text = "Rank: S";
            }

           else if (finalTime >= 120f)
            {
                rankText.text = "Rank: A";
            }

           else if (finalTime >= 60f)
            {
                rankText.text = "Rank: B";
            }
            else
            {
                rankText.text = "Rank: C";
            }
            
        }

        else
        {
            resultText.text = "------";
            rankText.text = "Rank: ------";
        }
    }

   

}
