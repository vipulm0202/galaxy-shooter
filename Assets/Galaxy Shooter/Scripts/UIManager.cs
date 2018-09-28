using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Sprite[] lives;
    public Image livesDisplay;
    public Image title;

    public Text scoreText;
    private int _score;
 
    public void updateLives(int currentLives) {
        livesDisplay.sprite = lives[currentLives];
    }

    public void updateScore() {
        _score ++;
        scoreText.text = "Score : " + _score;
    }

    public void ResetScore() {
        _score = -1;
        updateScore();
    }

    public void ShowTitle() {
        Debug.Log("Showing tile");
        title.gameObject.SetActive(true);
    }

    public void HideTitle()
    {
        Debug.Log("Hiding title");
        title.gameObject.SetActive(false);
    }
}
