using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
