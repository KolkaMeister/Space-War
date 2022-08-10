using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    TMP_Text scoreText;
    //GameSession gameSession;
    void Start()
    {

        scoreText = GetComponent<TMP_Text>();
        //gameSession = FindObjectOfType<GameSession>();
    }
    void Update()
    {
        scoreText.text = PlayerPrefsController.GetPoints().ToString();
    }
}
