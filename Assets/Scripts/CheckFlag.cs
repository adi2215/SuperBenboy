using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFlag : MonoBehaviour
{
    public GameObject image;
    public GameObject player;
    [SerializeField] private LevelLoadfer nextLevel;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            image.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            Invoke("NewScene", 1f);
        }
    }

    private void NewScene()
    {
        nextLevel.LoadLevel(1);
    }
}
