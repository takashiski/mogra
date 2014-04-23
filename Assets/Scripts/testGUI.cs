using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testGUI : MonoBehaviour {
	public GameObject[] mogras = new GameObject[5];
	static public int score = 0;
	List<List<int> > lists = new List<List<int> > ();
	List<int > list = new List<int>();

	public float timeCount = 0f;
	public int index = 0;
	void OnGUI(){
		for(int i=0;i<5;++i){
			if(GUI.Button(new Rect(0,i*30,100,30),"Move")){
				this.SendMessageToOBJ(mogras[i]);
			}
		}
		GUI.TextArea(new Rect(100,0,100,30),testGUI.score.ToString());
		GUI.TextArea(new Rect(200,0,100,30),((this.lists.Count)-(this.index)).ToString());
	}
	// Use this for initialization
	void Start () {
		for(int i=0;i<5;++i){
			lists.Add(new List<int>{i});
		}
		for(int i=0;i<4;++i){
			lists.Add (new List<int>{i,i+1});
		}
		for(int i=0;i<3;++i){
			lists.Add (new List<int>{i,i+2});
		}
		for(int i=0;i<2;++i){
			lists.Add (new List<int>{i,i+3});
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetKeys();
		this.Move();
	}
	void Move(){
		if(this.timeCount==0f && index < lists.Count){
			this.SendMassageByVector(lists[index++]);
		}
		this.timeCount+=Time.deltaTime;
		if(this.timeCount > 3f){
			this.timeCount=0;
		}

	}
	void GetKeys(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			this.SendMessageToOBJ(mogras[0]);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			this.SendMessageToOBJ(mogras[1]);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			this.SendMessageToOBJ(mogras[2]);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			this.SendMessageToOBJ(mogras[3]);
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			this.SendMessageToOBJ(mogras[4]);
		}
	}
	void SendMassageByVector(List<int> list){
		foreach(int n in list){
			SendMessageToOBJ(mogras[n]);
		}

	}
	void SendMessageToOBJ(GameObject obj){
		obj.SendMessage("StartMoving");
	}
}
