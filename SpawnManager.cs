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
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[Header("General Settings:")]
	public string poolType;
	public int maxInScene;

	[Header("Mode:")]
	public SPAWNMODE spawnMode;
	
	[Header("Region:")]
	public float spawnRadius;
	public float objectRadius;
	public LayerMask unwalkableLayers;

	[HideInInspector] public enum SPAWNMODE{WAVE,PERMANENT};
	[HideInInspector] public enum SPAWNSTATE{SPAWNING,WAITING};

	private EnemyPooling pooling;
	private int spawnIndex;
	private Vector3 currentSpawnpoint;

	private SPAWNSTATE spawnState;
	private List<GameObject> activeObjects = new List<GameObject>();

	private void Awake(){
		activeObjects.Clear();
		spawnIndex = 0;
		pooling = gameObject.GetComponentInParent<EnemyPooling>();
	}

}
