using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 startpos;

    private void Start() {
        startpos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Trap")) {
            Die();
        }
    }

    public void Updatecheckpoint(Vector2 pos) {
        startpos = pos;
    }

    void Die() {
        Respawn();
    }

    void Respawn() {
        transform.position = startpos;
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Checkpoint : MonoBehaviour
// {
//     private void awake() {
//         GameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
//     }

//     private void OnTriggerEnter2D(Collider2D collision) {
//         if (collision.CompareTag("Player")) {
//             GameController.Updatecheckpoint(transform.position);
//         }
//     }
// }
