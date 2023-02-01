using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;// Skor deðiþkeni
    private Text myText;// Text component'i için referans

    void Start()
    {
        myText = GetComponent<Text>();
    }

    void Update()
    {
        myText.text = "Score: " + score;// Skoru text component'ine göster
    }
}
