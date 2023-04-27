using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GAME_DC : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 3;
    public string liveKey = "lifeCount";
    public TMP_Text liveCount;
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject checkpointArea;
    public bool checkpointHit = false;
    public string middleOfGame = "middle";

    public bool inMiddle = false;
    void Start()
    {
        lives = 3;
        if (PlayerPrefs.HasKey(liveKey))
        {
            Debug.Log("LIVES SET");
            Debug.Log(liveKey);
            if(PlayerPrefs.GetInt(middleOfGame)==1)
            {
                lives = PlayerPrefs.GetInt(liveKey);
            }
            else
            {
                PlayerPrefs.SetInt(liveKey, lives);
            }
        }
        else
        {
            PlayerPrefs.SetInt(liveKey, lives);
        }

        if (PlayerPrefs.HasKey(middleOfGame))
        {
            Debug.Log(middleOfGame);
        }
        else
        {
            PlayerPrefs.SetInt(middleOfGame, 0);
        }

        if(PlayerPrefs.GetInt(middleOfGame) !=1)
        {
            inMiddle = false;
        }
        else
        {
            inMiddle = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        liveCount.text = "Lives: " + lives.ToString();
        inMiddle = true;
        PlayerPrefs.SetInt(middleOfGame, 1);

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
            PlayerPrefs.SetInt(middleOfGame, 0);
            SceneManager.LoadScene("GameOver_DC");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            lives = 300;
        }
        if(player.transform.position.x>checkpointArea.transform.position.x-2.5 && player.transform.position.x<checkpointArea.transform.position.x+2.5)
        {
            checkpointHit = true;
            Debug.Log("IT WORKS");
        }
    }

    public void storeLives()
    {
        PlayerPrefs.SetInt(liveKey, lives);
    }
}
