#region Copyright
//MIT License
//Copyright (c) 2017 , Milkid - Kristin Stock 

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

#endregion

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool  {

	public string name;
	public GameObject pooledObject;
	public int poolSize;
}

public class EnemyPooling : MonoBehaviour {

	public Pool[] enemyPools;
	public Dictionary<string,List<GameObject>> poolsDictionairy = new Dictionary<string,List<GameObject>>();

	private void Awake(){
		InitiateAndPopulatePools();
	}

	private void InitiateAndPopulatePools(){
		for(int i = 0; i < enemyPools.Length; i++){
			List<GameObject> newPool = new List<GameObject>();
			for(int j = 0; j < enemyPools[i].poolSize; j++){
				GameObject obj = (GameObject) Instantiate(enemyPools[i].pooledObject,new Vector3(-20,-20,0),Quaternion.identity);
				obj.transform.parent = transform;
				obj.SetActive(false);
				newPool.Add(obj);
			}
			poolsDictionairy.Add(enemyPools[i].name,newPool);
		}
	}	
}
