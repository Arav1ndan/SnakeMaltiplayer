using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private  TextMeshProUGUI scoreText;
 
    private int score;

    //private void Awake()
    //{
    //    scoreText = GetComponent<TextMeshProUGUI>();
    //    if(scoreText == null)
    //    {
    //        Debug.Log("score is not working");
    //    }
    //}
    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }
    public void DecreaseScore(int decrement)
    {
        if(score >= 0)
        {
            score -= decrement;
            RefreshUI();
        } 
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
}
