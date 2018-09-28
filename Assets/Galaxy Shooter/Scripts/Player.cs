using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private int _health = 3;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private float _fireRate = 0.25f;
    private  float _canFire = 0.0f;
    private float _speedFacotor = 1.0f;

    private bool _canTripleShot = false;
    private bool _shieldActive = false;

    private UIManager _uiManager;
    private GameManager _gameManager;

	// Use this for initialization
	void Start () {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Shoot();
    }

    private void Movement() {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * _speed * _speedFacotor * Time.deltaTime);
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * _speed * _speedFacotor * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

    private void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0) && Time.time > _canFire) {
            if (_canTripleShot) {
                Instantiate(_tripleShotPrefab, transform.position , Quaternion.identity);                
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0,0.88f, 0), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    public void PoweBoostOn(int id) {
        if (id == 0)
        {
            _canTripleShot = true;
        }
        else if (id == 1)
        {
            _speedFacotor = 2.0f;
        }
        else {
            _shieldActive = true;
            _shieldGameObject.SetActive(true);
        }
        StartCoroutine(PowerBoostOff(id));
    }

    private IEnumerator PowerBoostOff(int id) {
        yield return new WaitForSeconds(10.0f);
        if (id == 0)
        {
            _canTripleShot = false;
        }
        else if (id == 1)
        {
            _speedFacotor = 1.0f;
        }
    }

    public void Hit()
    {
        if (_shieldActive) {
            _shieldActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        _health--;
        _uiManager.updateLives(_health);
        if (_health == 0)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _gameManager.GameOver();
            Destroy(this.gameObject);
        }        
    }
}
