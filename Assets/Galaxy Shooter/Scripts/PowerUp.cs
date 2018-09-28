using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private int _id;

    [SerializeField]
    private float _speed = 2.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with : " + other.name);
        if (other.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if (player != null) {
                player.PoweBoostOn(_id);                     
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5.6f) {
            Destroy(this.gameObject);
        }
	}
}
