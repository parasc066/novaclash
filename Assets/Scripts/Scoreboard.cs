using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text scoreboardText;
    public void IncreaseScore(int amount)
    {
        score += amount;//score = score + amount;
        scoreboardText.text = score.ToString();
    }
}
