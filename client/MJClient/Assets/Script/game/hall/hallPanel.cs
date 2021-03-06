﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
public class hallPanel : MonoBehaviour {
	Account account;
	public static hallPanel instance;
	Transform topRoot,rangRoot,seleRoot,bottomRoot;
	Text playerNameText,goldText,roomCardText;
	Transform enterRoomBtn,xzddBtn,CreatRoomBtn;
	Transform enterRoomPanel,enterRoomPanel_enterRoomBtn,enterRoomPanel_returnBtn;
	InputField enterRoomPanel_InputField;
	Transform Friends_Content,Friend_item;
	Transform mailBtn;
	string _name,_id;
	// Use this for initialization
	void init(){
		topRoot = transform.Find ("top");
		seleRoot = transform.Find ("selePanel");
		playerNameText = topRoot.Find ("playerName").GetComponent<Text> ();
		goldText = topRoot.Find ("goldBG/Text").GetComponent<Text> ();
		roomCardText = topRoot.Find ("FKBG/Text").GetComponent<Text> ();
		rangRoot =  transform.Find ("Ranking");
		//topRoot.gameObject.SetActive (false);
		//rangRoot.gameObject.SetActive (false);
		enterRoomBtn = seleRoot.Find ("enterRoom");
		xzddBtn = seleRoot.Find ("XZMJ");
		CreatRoomBtn = seleRoot.Find ("CreatRoom");
		Friends_Content = transform.Find ("Ranking/Scroll View/Viewport/Content");
		Friend_item = transform.Find ("Ranking/item");
		EventInterface.AddOnEvent (enterRoomBtn, Click);
		EventInterface.AddOnEvent (xzddBtn, Click);
		EventInterface.AddOnEvent (CreatRoomBtn, Click);

		enterRoomPanel = transform.Find ("enterRoomPanel");
		enterRoomPanel_InputField = enterRoomPanel.Find ("InputField").GetComponent<InputField> ();
		enterRoomPanel_enterRoomBtn = enterRoomPanel.Find ("enterRoomBtn");
		enterRoomPanel_returnBtn = enterRoomPanel.Find ("returnBtn");
		EventInterface.AddOnEvent (enterRoomPanel_returnBtn, Click);
		EventInterface.AddOnEvent (enterRoomPanel_enterRoomBtn, Click);

		bottomRoot = transform.Find ("bottom");
		mailBtn = bottomRoot.Find ("message_btn");
		EventInterface.AddOnEvent (mailBtn, Click);

	}
	void Click(Transform tr){
		if (tr == xzddBtn) {
					
		} else if (tr == enterRoomBtn) {
			
			
		} else if (tr == enterRoomPanel_returnBtn) {
			
		}else if (tr == enterRoomPanel_enterRoomBtn) {
			
		}else if(tr == CreatRoomBtn){
			
		}else if(tr == mailBtn){
			
		}
	}
	void initPlayerData() {
		playerNameText.text = "名字："+account.playerName_base + "    ID:" + account.playerID_base;

	}
	void loseNet() {
		if (account == null)
		{
			GameManager.GetInstance().showMessagePanel("已和服务器断开连接！", () => {
				Application.LoadLevel("Login");
			});
		}

	}

	
	void Start () {
		instance = this;
		init ();
		installEvents ();
		if (KBEngineApp.app == null) {
			loseNet();
			return;
		}
		account = (Account)KBEngineApp.app.player ();
		if (account == null) {
			loseNet();
			return;
		}
		if (account.isNewPlayer==1) {			
			GameManager.GetInstance().LoadPanel("Prefabs/CreatPlayerPanel", GameObject.Find("Canvas/Root").transform);
			return;
		}
		initPlayerData();
	}
	
	void installEvents()
	{
		KBEngine.Event.registerOut("OnReqCreateAvatar", this, "OnReqCreateAvatar");

	}

	public void OnReqCreateAvatar(int code)
	{
		if (code == 0)
		{

			initPlayerData();


		}
	}
	void OnDestroy()
	{
		KBEngine.Event.deregisterOut(this);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
