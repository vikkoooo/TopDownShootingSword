using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int PlayerScore;
    public Text textElement;

    private void Start()
    {
        PlayerScore = 0;
    }

    private void Update()
    {
        textElement.text = $"Score: {PlayerScore.ToString()}";
    }
    
}
