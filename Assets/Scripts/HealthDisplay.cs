using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TMP_Text HPText;
    Player player;
    void Start()
    {
        HPText = GetComponent<TMP_Text>();
        player =FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = player.GetHP().ToString();
    }
}
