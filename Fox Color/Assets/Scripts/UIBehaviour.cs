using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{

    public GameObject UI;
    public Text life;
    public Image control;
    public float controlsShowTime = 10;
    public GameObject player;
    public PlayerController playerfoo;

    public GameObject pauseMenu;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        this.playerfoo = this.player.GetComponent<PlayerController>();
        this.pauseMenu.SetActive(false);
        this.gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.life.text = playerfoo.lifecounter.ToString();
        this.cancel();
        this.lifeCheck();
    }

    void ShowControls()
    {
        for (float f = 1f; f <= this.controlsShowTime; f += 1f)
        {
            this.control.enabled = true;
        }
        this.control.enabled = false;
    }

    void cancel()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            print("Paused");
            this.pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void lifeCheck()
    {
        if (this.playerfoo.lifecounter < 1)
        {
            this.gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
