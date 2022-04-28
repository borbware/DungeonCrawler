using UnityEngine;

public class CollectKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Inventory>().keys++;
            Destroy(gameObject);
        }
    }
}
