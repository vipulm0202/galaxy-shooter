using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    private bool _gameOver = true;

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if(_gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Starting game!!");
            _uiManager.HideTitle();
            _uiManager.updateLives(3);
            _uiManager.ResetScore();
            _gameOver = false;
            _spawnManager.SpawnPlayer();
            StartCoroutine(SpawnEnemyShip());
            StartCoroutine(SpawnPowerUps());

        }
    }

    public void GameOver() {
        Debug.Log("Game Over!!");
        _gameOver = true;
        _uiManager.ShowTitle();
    }

    private IEnumerator SpawnEnemyShip()
    {
        while (!_gameOver) {
            _spawnManager.SpawnEnemyShip();
            yield return new WaitForSeconds(5);
        }       
    }

    private IEnumerator SpawnPowerUps()
    {
        while (!_gameOver) {
            _spawnManager.SpawnPowerUps();
            yield return new WaitForSeconds(8);
        }        
    }
}
