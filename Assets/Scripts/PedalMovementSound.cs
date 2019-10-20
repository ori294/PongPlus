using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PedalMovementSound : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("right", Right);
        actions.Add("left", Left);
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void OnApplicationQuit()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.OnPhraseRecognized -= OnPhraseRecognized;
            keywordRecognizer.Stop();
        }
    }

    private void Right()
    {
        //transform.Translate(0, 0, -1);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2f);
    }

    private void Left()
    {
        //transform.Translate(0, 0, 1);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f);
    }
}
