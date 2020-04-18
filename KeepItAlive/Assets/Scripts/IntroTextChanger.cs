using System.Collections;
using UnityEngine;
using TMPro;

public class IntroTextChanger : MonoBehaviour {
    public string intialText;
    public float timeBetweenChanges = 1;

    public TextMeshProUGUI text;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void Reset() {
        text.text = intialText;
        StartCoroutine(DotAdder());
    }

    IEnumerator DotAdder() {
        yield return new WaitForSeconds(timeBetweenChanges);
        text.text += ".";
        yield return new WaitForSeconds(timeBetweenChanges);
        text.text += ".";
        yield return new WaitForSeconds(timeBetweenChanges);
        text.text += ".";
        yield return new WaitForSeconds(timeBetweenChanges * 2);
        GameManager.instance.IntroFinished();
    }

}
