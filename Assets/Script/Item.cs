using UnityEngine;

public class Item : MonoBehaviour
{
    public int totalItemsNeeded = 5;
    private int itemsCollected = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            CollectItem(other.gameObject);
        }
    }

    private void CollectItem(GameObject item)
    {

        Destroy(item);
        itemsCollected++;

        if (itemsCollected >= totalItemsNeeded)
        {
            Win();
        }
    }


    private void Win()
    {
        Debug.Log("Kamu Menang! Semua barang telah dikumpulkan.");

    }
}
