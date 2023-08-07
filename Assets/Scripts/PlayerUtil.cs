using UnityEngine;

public class PlayerUtil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
        transform.position = new Vector3(Random.Range(-5, 5), 2, 0);
    }

}
