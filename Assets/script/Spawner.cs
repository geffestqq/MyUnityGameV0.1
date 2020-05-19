using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class Spawner : MonoBehaviour {
   public Transform SpawnPos;
   public GameObject Enemy;
   
   void Start()
   {
	   StartCoroutine(SpawnCD());
   }
   
   void Repeate()
   {
	   StartCoroutine(SpawnCD());
   }
   IEnumerator SpawnCD()
   {
	   yield return new WaitForSeconds(4f);
	   Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
	   Repeate();
   }
}