using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameController gamecontroller;

    void Start() {
        if (gamecontroller == null) {
            gamecontroller = FindObjectOfType<GameController>();
        }
    }

    private void awake() {
        gamecontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            gamecontroller.Updatecheckpoint(transform.position);
        }
    }
}
