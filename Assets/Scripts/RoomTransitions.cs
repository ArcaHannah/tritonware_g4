using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransitions : MonoBehaviour
{
    // the room that this room transition takes you to
    [SerializeField] private Transform nextRoom;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            TeleportPlayer(player);
        }
    }

    void TeleportPlayer(GameObject player)
    {
        player.transform.position = nextRoom.transform.position;
    }
}
