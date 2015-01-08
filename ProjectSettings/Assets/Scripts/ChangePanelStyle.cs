using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePanelStyle : MonoBehaviour {

	public float newHeight;
	public float newScrollViewHeight;
	public int newFontSize;
	public Font newFont;


	// Use this for initialization
	void Start () {
	

			//GuiLoader.loader = new GuiLoader ();
		//	rectTransform.sizeDelta = new Vector2( yourWidth, yourHeight);

			//change panel size
			var rt = GuiLoader.loader.panel;

			var width = rt.sizeDelta.x;
			rt.sizeDelta = new Vector2 (width, newHeight);
			//change scrollViewSize // default is 57.6
			
			
			var scrollview = GuiLoader.loader.scrollViewText;
		 //   var rt2 = scrollview.transform.GetComponent<RectTransform> ();
		//RectTransformExtensions.SetHeight (rt2, 30);

			//var scrollwidth =scrollview.sizeDelta.x;
			//GuiLoader.loader.scrollViewText.sizeDelta = new Vector2(scrollwidth, newScrollViewHeight);
	

		//RectTransform rTrans =  scrollview.transform.GetComponent<RectTransform>();
		
		// set new width and height
		
	//	rTrans.anchoredPosition = new Vector2(15, 20);

			//var jotain  = GuiLoader.loader.panel.
		//	scrollview.rect.Set(0,20, scrollwidth, 166f );

	//	var scrollview2 = scrollview.GetComponent<RectTransform> ();
//		scrollview2.sizeDelta = new Vector2(scrollwidth, 20);
			//buttonplacechange
//		
			//nextB.transform.position = Vector3 (20, 0, 0);
			//nextB.transform.position= new Vector3(200,200, 20);
			//ChangeButtonHight(nextB, newButtons);

		//Rect sample_size = nextB.GetComponent<RectTransform>().rect;





		if (newFontSize != null || newFontSize > 0) {
				
			GuiLoader.loader.panelText.fontSize= newFontSize;
				
				}
//		RectTransform rt = Canvas.GetComponent<RectTransform>();
		//		rt.sizeDelta = new Vector2(100, 100); Canvas.GetComponent (typeof (RectTransform)) as RectTransform; 57.6

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeButtonHight(Button button, float  newButtons){
//
//		var rectTransform = button.GetComponent<RectTransform>();
//		var width = rectTransform.position.x;
//		var hight = rectTransform.position.y;
//		rectTransform.position = new Vector2(width, newButtons);

	}
}
