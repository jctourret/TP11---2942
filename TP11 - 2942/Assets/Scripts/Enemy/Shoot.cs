using UnityEngine;

public class Shoot : MonoBehaviour
{
   public Transform canyonLeft;
   public Transform canyonRight;
   public GameObject bullet;
   [SerializeField]private float timeToShoot;

   private void Start()
   {
      InvokeRepeating("ShootCanyons",timeToShoot,timeToShoot);
   }

   private void ShootCanyons()
   {
      Instantiate(bullet,canyonRight.position,canyonRight.rotation,gameObject.transform);
      Instantiate(bullet,canyonLeft.position,canyonLeft.rotation,gameObject.transform);
   }
   
}
