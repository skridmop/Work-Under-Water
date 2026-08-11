using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI totalScore;
    private int score;

    void Start()
    {
        totalScore = GetComponent<TextMeshProUGUI>();
        totalScore.text = "0";
        score = 0;
    }
    public void AddScore(int amount)
    {
        score += amount;
        totalScore.text = score.ToString();
    }
}