using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float delay = 0.1f;
 
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
