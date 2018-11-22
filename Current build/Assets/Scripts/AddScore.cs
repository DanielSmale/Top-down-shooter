using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public delegate void SendScoreI(int theScore);
    public static event SendScoreI OnSendScore;

    public int scoreToAdd = 10;

    public void OnDestroy()
    {
        if(OnSendScore != null)
        {
            OnSendScore(scoreToAdd);
        }
    }



}
