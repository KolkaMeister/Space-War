using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int score=0;
    
    void Awake()
    {
        ProtectObject();
    }

    void ProtectObject()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void AddToScore(int Price)
    {
        score += Price;
    }
    public void ResetScore()
    {
        Destroy(gameObject);
    }

}
