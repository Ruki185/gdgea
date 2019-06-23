using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{

    public Button respawnButton;
    public Button resumeButton;
    public Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        this.menuButton.onClick.AddListener(this.menu);
        this.resumeButton.onClick.AddListener(this.onResume);
        this.respawnButton.onClick.AddListener(this.respawn);
    }

    // 50Hz Update
    void Update()
    {
        this.resume();
    }

    void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.onResume();
    }

    void menu()
    {
        SceneManager.LoadScene("MainMenu");
        this.onResume();
    }   

    void onResume()
    {
        this.transform.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void resume()
    {
        if (Input.GetButtonDown("Cancel") && this.transform.gameObject.activeSelf)
        {
            print("foo");
            this.onResume();
        }
    }
}
