using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Transform masukanLoadingbar;

    [SerializeField]
    private float nilaiSekarang;
    [SerializeField]
    private float nilaiKecepatan;

    void Update()
    {
        if(nilaiSekarang < 100)
        {
            nilaiSekarang += nilaiKecepatan * Time.deltaTime;
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
        masukanLoadingbar.GetComponent<Image>().fillAmount = nilaiSekarang / 100;
    }
}