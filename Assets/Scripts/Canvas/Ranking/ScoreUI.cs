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
        
        scoreManager.AddScore(new Score("BanbAna", 50));
        scoreManager.AddScore(new Score("ManzAna", 120));
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i=0; i < scores.Length; ++i)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.nombre.text = scores[i].nombre;
            row.score.text = scores[i].score.ToString();
        }
    }
}
