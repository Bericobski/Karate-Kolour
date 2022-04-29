using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreGame : MonoBehaviour
{
    private string DATANAME = "POINTS";
    private int score = 0;
    private int currentScore;
    private const int DEFAULT = 0;
    public TextMeshProUGUI maxScore;

    void Start()
    {
        LoadData();
        Run();
        Save();
        //LoadData();
        // GenerateData();
        //Save();
    }

    private void GenerateData() { currentScore = game_instance.instance.player_score; }
    private void Save() { PlayerPrefs.SetInt(DATANAME, currentScore); }
    private void LoadData()
    {
        score = PlayerPrefs.GetInt(DATANAME, DEFAULT);
        maxScore.text = "High Score: " + score;
    }
    private void Run()
    {
        GenerateData();
        if (currentScore > PlayerPrefs.GetInt(DATANAME, score))
        {
            LoadData();
        }
        else { maxScore.text = "High Score: " + score; }
        Save();
    }
    /*private void SaveAndLoad()
    {
        currentScore = game_instance.instance.player_score;
        if (currentScore > DEFAULT)
        {
            PlayerPrefs.SetInt(DATANAME, currentScore);
            score = PlayerPrefs.GetInt(DATANAME, DEFAULT);
        }
        else { score = DEFAULT; }
        maxScore.text = "High Score: " + score;
        PlayerPrefs.SetInt(DATANAME, score);
    }*/
    void Update() {}
}