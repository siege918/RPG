using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {


    private string currentText = "";
    private string nextText;
    public string initialText;
    private int WaitFrames = 0;

	// Use this for initialization
	void Start () {
        nextText = initialText;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
            
        if (WaitFrames > 0)
        {
            WaitFrames--;
        }
        else if (nextText != null && !currentText.Equals(nextText)) {
            char[] nextTextArray = nextText.ToCharArray();
            if (nextTextArray[currentText.Length] == '%' && nextTextArray[currentText.Length + 1] == '%')
            {
                int currentIndex = currentText.Length + 2;
                while (currentIndex < nextText.Length && char.IsDigit(nextTextArray[currentIndex]))
                {
                    WaitFrames = (WaitFrames * 10) + (int)char.GetNumericValue(nextTextArray[currentIndex]);
                    currentIndex++;
                }
                nextText = nextText.Remove(currentText.Length, currentIndex - currentText.Length);
            }
            else
            {
                currentText = nextText.Substring(0, currentText.Length + 1);
            }
        }

        this.GetComponent<UnityEngine.UI.Text>().text = currentText;
	}
}
