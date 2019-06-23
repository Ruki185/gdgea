using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverBehaviour : MonoBehaviour
{

    public Button respawnButton;
    public Button menuButton;

    // Start is called before the first frame update
    void Start()
    {

        this.respawnButton.onClick.AddListener(respawn);
        this.menuButton.onClick.AddListener(menu);
    }

    // Frame Update
    void Update()
    {
        respawnAction();
    }

    void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.onResume();
    }

    void menu()
    {
        print("flip");  
        SceneManager.LoadScene("MainMenu");
        this.onResume();
    }

    void onResume()
    {
        this.transform.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void respawnAction()
    {
        if (Input.GetButton("Fire1") && this.transform.gameObject.activeSelf)
        {
            this.respawn();
        }
    }
}
