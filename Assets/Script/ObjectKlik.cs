using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectKlik : MonoBehaviour
{
    public string clickableTag = "Item";
    public Camera playerCamera;
    public float detectionRadius = 5.0f;
    public int totalItemsNeeded = 5;
    private int itemsCollected = 0;
    public static bool GameIsPaused = false;
    public GameObject panel;
    public GameObject penyangga;

    void Start()
    {
        UnlockCursor(); // Pastikan kursor terlihat sejak awal
    }

    void Update()
    {
        // Memeriksa apakah tombol mouse kiri ditekan
        if (Input.GetMouseButtonDown(0))
        {
            // Membuat ray dari posisi kamera
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Jika ray mengenai objek dalam jangkauan
            if (Physics.Raycast(ray, out hit, detectionRadius))
            {
                // Mendapatkan referensi ke objek yang terkena ray
                GameObject clickedObject = hit.collider.gameObject;

                // Mengecek apakah objek memiliki tag item
                if (clickedObject.CompareTag(clickableTag))
                {
                    // Jalankan aksi pengumpulan item
                    CollectItem(clickedObject);
                }
            }
        }
    }

    // Fungsi untuk mengumpulkan item
    private void CollectItem(GameObject item)
    {
        // Hancurkan item dan tingkatkan jumlah item yang dikumpulkan
        Destroy(item);
        Destroy(penyangga);
        itemsCollected++;
        OpenPanel();

        Debug.Log("Item dikumpulkan. Total item: " + itemsCollected);

        // Periksa apakah semua item telah dikumpulkan
        if (itemsCollected >= totalItemsNeeded)
        {
            Win();
        }
    }

    // Fungsi untuk menang setelah semua item dikumpulkan
    private void Win()
    {
        Debug.Log("Kamu Menang! Semua barang telah dikumpulkan.");
        // Tambahkan aksi kemenangan di sini (misalnya, tampilkan UI atau pindah ke level baru)
    }

    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            UnlockCursor();
            Pause();
        }
        else
        {
            Resume();
        }
    }
    
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Pastikan kursor tidak terkunci
        Cursor.visible = true; // Tampilkan kursor
    }
}
