using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos; // Vi tri di chuyen toi
    public float Yincrement; // Bien do dao dong

    public float speed; // Toc do dao dong
    public float maxHeight;
    public float minHeight;
    public int health = 3;

    public GameObject effect;
    public Text healthDisplay;

    public GameObject gameStart;
    public GameObject gameOver;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "HP: " + health.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStart.SetActive(false);
            spawner.SetActive(true);
        }

        if (health <= 0) // Het mau!
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
