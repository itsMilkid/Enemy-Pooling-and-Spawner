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

public class PoolingManager : MonoBehaviour {

	public Pool[] pools;

	public Dictionary<string,List<GameObject>> activePools = new Dictionary<string,List<GameObject>>();

	private void Awake(){
		InitiatePools();
	}

	private void InitiatePools(){
		for(int i = 0; i < pools.Length; i++){
			List<GameObject> newList = new List<GameObject>();
			for(int j = 0; j < pools[i].poolSize; j++){
				GameObject obj = (GameObject) Instantiate(pools[i].pooledObject,new Vector3(-20,-20,0), Quaternion.identity);
				obj.transform.parent = transform;
				obj.SetActive(false);
				newList.Add(obj);
			}
			activePools.Add(pools[i].name,newList);
		}
		Debug.Log(activePools.Count);
		
		for(int k= 0; k < pools.Length; k++){
			Debug.Log(pools[k].name.ToString() + " " + activePools[pools[k].name].Count);
		}
	}

}
