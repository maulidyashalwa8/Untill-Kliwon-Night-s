using UnityEngine;

public class PlayerDeathOnCollision : MonoBehaviour
{
    public GameObject gameOverPanel;  // Panel yang muncul saat player kalah

    private void Start()
    {
        // Sembunyikan panel kalah pada awalnya
        gameOverPanel.SetActive(false); 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Cek apakah player bertabrakan dengan musuh (tag: Enemy)
        if (hit.gameObject.CompareTag("Enemy"))
        {
            // Hancurkan musuh setelah bertabrakan
            Destroy(hit.gameObject);

            // Langsung panggil kematian
            Die();
        }
    }

    // Fungsi ketika player mati (misalnya, terkena enemy)
    void Die()
    {
        Debug.Log("Player mati. Game over.");
        gameOverPanel.SetActive(true); // Tampilkan panel kalah
        Time.timeScale = 0f; // Hentikan permainan
    }
}
