using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _enemyShipObject;
    [SerializeField]
    private GameObject _playerObject;
    [SerializeField]
    private GameObject[] _poweUps;

    public void SpawnEnemyShip() {       
        float randomX = Random.Range(-7.0f, 7.0f);
        Instantiate(_enemyShipObject, new Vector3(randomX, 7.0f, 0), Quaternion.identity);
    }

    public void SpawnPowerUps()    {
        int randomPowerUp = Random.Range(0,3);
        float randomX = Random.Range(-7.0f, 7.0f);
        Instantiate(_poweUps[randomPowerUp], new Vector3(randomX, 7.0f, 0), Quaternion.identity);
    }
  
    public void SpawnPlayer()
    {
        Instantiate(_playerObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
