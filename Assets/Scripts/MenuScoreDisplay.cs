using UnityEngine;
using UnityEngine.UI;

public class MenuScoreDisplay : MonoBehaviour
{

    public Text score;
    
    void Start()
    {
        score.text = Score.PlayerScore.ToString();
    }

}
