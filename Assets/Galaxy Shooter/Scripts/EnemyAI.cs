using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {


    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private GameObject _explosionPrefab;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update () {       
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -7.0f) {            
            transform.position = new Vector3(transform.position.x, 7.0f, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with : " + other.tag);
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        if (other.tag == "Laser")  {            
            Laser laser = other.GetComponent<Laser>();
           if (laser != null)
           {
            laser.DestroyLaser();
           }
            _uiManager.updateScore();
        }
        else if (other.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Hit();
            }
        }
        Destroy(this.gameObject);
    }
}
