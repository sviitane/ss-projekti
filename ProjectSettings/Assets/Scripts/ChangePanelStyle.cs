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
	


		//	rectTransform.sizeDelta = new Vector2( yourWidth, yourHeight);

		if (newHeight != null && newHeight > 0  ) {

			//change panel size
			var rt = GuiLoader.loader.panel;

			var width = rt.sizeDelta.x;
			rt.sizeDelta = new Vector2 (width, newHeight);
			//change scrollViewSize // default is 57.6

			var scrollview = GuiLoader.loader.scrollViewText;
			var scrollwidth =scrollview.sizeDelta.x;
			GuiLoader.loader.scrollViewText.sizeDelta = new Vector2(scrollwidth, newScrollViewHeight);

			//buttonplacechange
//		
 			Button nextB = GuiLoader.loader.nextButton;
//			var rectTransform = nextB.GetComponent<RectTransform>();
//
//			rectTransform.position = new Vector2(150,150);

			//ChangeButtonHight(nextB, newButtons);



		}


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
