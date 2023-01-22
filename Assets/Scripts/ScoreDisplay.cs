using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Canvas _canvas;
    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int newScore)
    {
        //add score setting code
    }

    private void CreateCanvas()
    {
        var myGO = new GameObject();
        myGO.name = "Canvas";

        _canvas = myGO.AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.WorldSpace;

        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        // Text
        var myText = new GameObject();
        myText.transform.parent = myGO.transform;
        myText.name = "Score";

        _text = myText.AddComponent<Text>();
        _text.font = (Font)Resources.Load("MyFont");
        _text.text = GetScoreAsString(0);
        _text.fontSize = 100;

        // Text position
        var rectTransform = _text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);
    }

    private string GetScoreAsString(int score)
    {
        return score.ToString();
    }
}
