
using UnityEngine;

public class test : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        

       
        
        if (other.transform.GetComponent<IHittable>() == null) return;
        other.transform.GetComponent<IHittable>().Damage();
        Debug.Log("entraste papu ");
    }
}
