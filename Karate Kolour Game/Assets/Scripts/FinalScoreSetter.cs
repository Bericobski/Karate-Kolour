using UnityEngine;
using TMPro;

public class FinalScoreSetter : MonoBehaviour
{
    private const string HIGH_SCORE_DATA_KEY = "POINTS";
    private const int DEFAULT_SCORE = 0;

    public TextMeshProUGUI scoreTextField;
    public TextMeshProUGUI highScoreTextField;

    void Start()
    {
        int currentScore = game_instance.instance.player_score;
        int maxScore = Load();

        bool newHighScore = false;

        if (currentScore > maxScore)
        {
            newHighScore = true;
            maxScore = currentScore;
            Save(maxScore);
        }

        UpdateScore(currentScore);
        UpdateHighScore(maxScore, newHighScore);

        // Reset score
        game_instance.instance.player_score = 0;
    }

    private void Save(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE_DATA_KEY, score);
        PlayerPrefs.Save();
    }

    private int Load()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_DATA_KEY, DEFAULT_SCORE);
    }

    public void UpdateScore(int score)
    {
        scoreTextField.text = "Score: " + score;
    }

    public void UpdateHighScore(int highScore, bool isNew)
    {
        if (isNew)
            highScoreTextField.text = "<color=#FFD700>NEW</color> High Score: " + highScore;
        else
            highScoreTextField.text = "High Score: " + highScore;
    }
}
