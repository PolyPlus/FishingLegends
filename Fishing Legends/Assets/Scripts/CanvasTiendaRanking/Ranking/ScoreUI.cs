using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;

    void Start()
    {

        //scoreManager.AddScore(new Score("BanbAna", 50));
        //scoreManager.AddScore(new Score("ManzAna", 120));
        if (StaticInfo.addRanking == true)
        {
            for (int i=0; i<StaticInfo.totalScores.Count; ++i)
            {
                scoreManager.AddScore(new Score(PlayerPrefs.GetString(StaticInfo.name), StaticInfo.totalScores[i]));
            }

            StaticInfo.totalScores = new List<int>(); 
            StaticInfo.addRanking = false;
        }

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i=0; i < scores.Length && i < 10; ++i)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.nombre.text = scores[i].nombre;
            row.score.text = scores[i].score.ToString();
        }
    }
}
