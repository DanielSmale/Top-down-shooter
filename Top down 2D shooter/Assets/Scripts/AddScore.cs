using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public delegate void SendScoreI(int theScore);
    public static event SendScoreI OnSendScore;

    public int score = 10;
    private bool scoreSent = false;

    public void OnAddScore()
    {
        if(OnSendScore != null)
        {
            if (!scoreSent)
            {
                scoreSent = true;
                OnSendScore(score);
            }
        }
    }



}
