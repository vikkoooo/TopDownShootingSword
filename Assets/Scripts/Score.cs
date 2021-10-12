using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int PlayerScore;
    public Text textElement;
    
    private void Update()
    {
        textElement.text = $"Score: {PlayerScore.ToString()}";
    }
    
}
