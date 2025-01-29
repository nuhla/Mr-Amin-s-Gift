using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    public static int totalScore = 0;
    private HashSet<GameObject> clickedCubes = new HashSet<GameObject>();
    public delegate void OnScoreAdded(int points, GameObject cube);
    public static OnScoreAdded onScoreAdded;
    void Start()
    {
        UpdateScoreText();
    }

    private void OnEnable()
    {
        onScoreAdded += AddScore;
    }

    private void OnDisable()
    {
        onScoreAdded -= AddScore;
    }

    private void AddScore(int points, GameObject cube)
    {
        if (clickedCubes.Contains(cube)) return;
        clickedCubes.Add(cube);

        if (score < totalScore)
            score += points;

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{score} / {totalScore}";
    }

}
