using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int PlayerScore=0;
    public string textValue;
    public Text textElement;

    public  int points { get => PlayerScore; set => PlayerScore = value; }

    private void Update()
    {
        textElement.text = $"Score: {points}";
    }

    
   
}
