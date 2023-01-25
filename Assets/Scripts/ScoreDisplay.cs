using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshPro _text;

    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int newScore)
    {
        _text.SetText( GetScoreAsString(newScore));
    }

    private void CreateText()
    {
        // Text
        var myText = new GameObject();
        myText.transform.parent = transform;
        myText.transform.position = transform.position;
        myText.name = "Score";

        _text = myText.AddComponent<TextMeshPro>();
        _text.SetText(GetScoreAsString(0));
        _text.color = new Color(0, 0, 0);
        _text.alignment = TextAlignmentOptions.Center;
        _text.fontSize = 200;

        // Text position
        var rectTransform = _text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(100, 10);
        myText.transform.position += new Vector3(0, 7, 0);
    }

    private string GetScoreAsString(int score)
    {
        int scoreLength = 5;
        return score.ToString("D" + scoreLength); ;
    }
}
