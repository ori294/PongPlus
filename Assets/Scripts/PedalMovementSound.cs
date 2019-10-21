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
    public GameObject gameUI;
    private bool left = false;
    private bool right = false;
    private bool stop = true;
    public float speed = 0.1f;
    public 

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("right", Right);
        actions.Add("left", Left);
        actions.Add("stop", Stop);
        actions.Add("pause", Pause);
        
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
        right = true;
        left = false;
        stop = false;
    }

    private void Left()
    {  
        right = false;
        left = true;
        stop = false;
    }

    private void Stop()
    {
        right = false;
        left = false;
        stop = true;
    }

    private void Pause()
    {
        gameUI.GetComponent<InGameUI>().Pause();
    }


    void Update()
    {
        if (left && !stop) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
             transform.position.z + speed);
        }
        else if (right && !stop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
             transform.position.z - speed);
        }
    }


    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Wall") 
        {
            Stop();
        }
    }
}
