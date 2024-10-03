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

    void Update()
    {
        // Memeriksa apakah tombol keyboard "E" ditekan
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Mengambil semua collider item dalam jangkauan
            Collider[] hitColliders = Physics.OverlapSphere(playerCamera.transform.position, detectionRadius);

            // Iterasi melalui semua collider yang terdeteksi
            foreach (var hitCollider in hitColliders)
            {
                // Mendapatkan referensi ke objek yang bertabrakan
                GameObject clickedObject = hitCollider.gameObject;

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
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true; // Show cursor
    }
}
