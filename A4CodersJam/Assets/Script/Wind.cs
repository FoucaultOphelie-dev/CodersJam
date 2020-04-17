using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector2 sens;
    public float speed;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddVelocity(collision.gameObject.GetComponent<CoderJam.Player>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RevertVelocity(collision.gameObject.GetComponent<CoderJam.Player>());
        }
    }

    private void AddVelocity(CoderJam.Player player)
    {
        player.addVelocity += sens * speed;
    }
    private void RevertVelocity(CoderJam.Player player)
    {
        player.addVelocity -= sens * speed;
    }
}
