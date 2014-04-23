using UnityEngine;
using System.Collections;

enum State{
	ready,wait1,moveup,wait2,movedown,stop,launch
};
public class MoveMogra : MonoBehaviour {

	public float toppos = 2f;
	public float lowpos = 0f;
	public float readypos = 1f;
	public float deltaMove = 0.05f;

	public float gameSpeed = 1f;
	public float timeWait1 = 1f;
	public float timeWait2 = 1f;
	float timeCount=0f;
	State state=State.stop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DoByState(this.state);
	}

	void OnMouseDown(){
		switch(this.state){
			case State.ready:
			case State.wait1:
				break;
			default:
//				this.state=State.launch;
				this.state=State.movedown;
				testGUI.score+=1;
				break;
		}
	}






	void ChangeState(){
		++(this.state);
	}
	void DoByState(State state){
		switch(state)
		{
		case State.ready:Ready();break;
		case State.wait1:Wait();break;
		case State.moveup:MoveUp();break;
		case State.wait2:Wait();break;
		case State.movedown:MoveDown();break;
		case State.stop:break;
		case State.launch:Launch();break;
		}
	}
	void Ready(){
		Transform trans=this.gameObject.transform;
		trans.Translate(0f,deltaMove,0f);
		if(trans.position.y>this.readypos)
			this.ChangeState();
	}
	void MoveUp(){
		Transform trans=this.gameObject.transform;
		trans.Translate(0f,deltaMove,0f);
		if(trans.position.y>this.toppos)
			this.ChangeState();
	}
	void MoveDown(){
		Transform trans = this.gameObject.transform;
		trans.Translate(0f,-1*deltaMove,0f);
		if(trans.position.y < this.lowpos)
			this.ChangeState();
	}
	void Wait(){
		this.timeCount+=Time.deltaTime;
		if(this.state==State.wait1 && this.timeCount>this.timeWait1){
			this.ChangeState();
			this.timeCount=0f;
		}
		else if(this.state==State.wait2 && this.timeCount>this.timeWait2){
			this.ChangeState();
			this.timeCount=0f;
		}
	}
	void Launch(){
		Transform trans = this.gameObject.transform;
		trans.Translate(0f,1f,0f);
	}
	void StartMoving(){
		if(this.state == State.stop)
			this.state=State.ready;
	}
}
