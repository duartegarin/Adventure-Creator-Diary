using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class DiarySaver : MonoBehaviour, ISave {

	public string journalPages;
	public Diary diary;

	public void Start(){

		diary = GameObject.Find ("DiaryCanvas").transform.Find ("Diary").gameObject.GetComponent<Diary>();
	}

	public void PreSave(){

		for (int i = 0; i < diary.bookPages.Length; i++)
		{
			journalPages += diary.bookPages [i].name + '|';
		}
		GlobalVariables.SetStringValue (15, journalPages);
	}

	public void PostLoad(){
		char[] separator = { '|'};
		journalPages = GlobalVariables.GetStringValue (15);
		string[] spriteNames = journalPages.Split (separator);
		Sprite[] journalSprites = new Sprite[spriteNames.Length-1];
		for (int i = 0; i < spriteNames.Length-1; i++)
		{
			journalSprites[i] = Resources.Load(spriteNames[i], typeof(Sprite)) as Sprite;
		}
		diary.bookPages = journalSprites;
		diary.currentPage = journalSprites.Length - 1;
		diary.UpdateSprites ();
		diary.updateButtons ();
		AC.Menu diaryMenu = PlayerMenus.GetMenuWithName ("Diary");
		diaryMenu.TurnOn ();
	}

}
