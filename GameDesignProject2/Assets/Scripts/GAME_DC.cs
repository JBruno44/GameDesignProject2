using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GAME_DC : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 3;
    public TMP_Text liveCount;
    public GameObject playerPrefab;
    public GameObject player;
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        liveCount.text = "Lives: " + lives.ToString();

        if (player.transform.position.y < -4)
        {
            lives -= 1;
            Destroy(player.gameObject);
            player = Instantiate(playerPrefab);
        }

        if (lives < 1)
        {
            SceneManager.LoadScene("GameOver_DC");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            lives = 300;
        }
    }
}
