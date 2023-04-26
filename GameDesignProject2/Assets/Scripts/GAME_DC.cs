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
    public GameObject checkpointArea;
    public bool checkpointHit = false;
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        liveCount.text = "Lives: " + lives.ToString();

        if (player.transform.position.y < -4f)
        {
            lives -= 1;
            Destroy(player.gameObject);
            player = Instantiate(playerPrefab);
            if(checkpointHit==true)
            {
                player.transform.position = checkpointArea.transform.position;
            }
        }

        if (lives < 1)
        {
            SceneManager.LoadScene("GameOver_DC");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            lives = 300;
        }

        Debug.Log(player.transform.position.x);
        Debug.Log(checkpointArea.transform.position);
        if(player.transform.position.x>checkpointArea.transform.position.x-2.5 && player.transform.position.x<checkpointArea.transform.position.x+2.5)
        {
            checkpointHit = true;
            Debug.Log("IT WORKS");
        }
    }
}
