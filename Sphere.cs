using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	private float lifetime = 10f;
	private string objectType = "Sphere";
	public float timer;

	private EnemyPooling pool;
	private Spawner spawner;

	private void Start(){
		pool = GetComponentInParent<EnemyPooling>();
		spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
		timer = lifetime;
	}

	private void Update(){
		timer -= Time.deltaTime;

		if(timer < 0){
			timer = 0;
		}

		if(timer == 0){
			gameObject.SetActive(false);
			timer = lifetime;
			pool.poolsDictionairy[objectType].Add(gameObject);
			spawner.activeObjects.Remove(gameObject);
		}
	}
}
