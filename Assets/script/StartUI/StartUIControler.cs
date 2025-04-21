using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIControler : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject settingUi;
    private void Awake()
    {
        mainUI.SetActive(true);
        settingUi.SetActive(false);
    }

    public void Back()
    {
        settingUi.SetActive(false);
        mainUI.SetActive(true);
    }

    public void Setting()
    {
        settingUi.SetActive(true);
        mainUI.SetActive(false);
    }

    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
}
