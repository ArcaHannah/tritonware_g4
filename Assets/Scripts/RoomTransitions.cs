using Unity.Cinemachine;
using UnityEngine;

public class RoomTransitions : MonoBehaviour
{
    // the room that this room transition takes you to
    [SerializeField] private Transform nextRoom;
    [SerializeField] private Collider2D camBoundary;
    CinemachineConfiner2D confiner;
    private Camera mainCamera;

    void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
        mainCamera = FindFirstObjectByType<Camera>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            TeleportPlayer(player);
            confiner.BoundingShape2D = camBoundary;
        }
    }

    void TeleportPlayer(GameObject player)
    {
        player.transform.position = nextRoom.transform.position;
    }
}
