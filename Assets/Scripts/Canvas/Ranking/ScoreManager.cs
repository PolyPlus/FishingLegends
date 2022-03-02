using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    //public List<Score> scores;
    // Start is called before the first frame update
    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        //scores = new List<Score>();
        sd = JsonUtility.FromJson<ScoreData>(json);
       // sd = new ScoreData();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x =>x.score);
    }
    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }
    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);

    }
}
