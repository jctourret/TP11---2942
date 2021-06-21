using UnityEngine;

public class Shoot : MonoBehaviour
{
   public Transform canyon;
   public GameObject bullet;
   [SerializeField]private float timeToShoot;

   private void Start()
   {
      InvokeRepeating("ShootCanyon",timeToShoot,timeToShoot);
   }

   private void ShootCanyon()
   {
      Instantiate(bullet,canyon.position,canyon.rotation,gameObject.transform);
   }
   
}
