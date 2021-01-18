using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas GameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Application.Quit();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
