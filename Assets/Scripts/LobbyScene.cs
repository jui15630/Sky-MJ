
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScene : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Title");
    }
}
