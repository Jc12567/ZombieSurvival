using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameText : MonoBehaviour
{
    public static GameText instance;
    [SerializeField]
    private TMP_Text gameText;
    private ArrayList strings = new ArrayList();
    [SerializeField]
    private float speedOfRemoval = 10f;
    [SerializeField]
    private float timeToRemove = 100f;
    // Start is called before the first frame update
    void Start()
    {
        gameText.SetText("");
    }

    private void Awake()
    {
        instance = this;
    }
    public void addText(string text)
    {
        timeToRemove = 100f;
        text.Equals("/n" + text);
        if (!strings.Contains(text))
        {
            strings.Add(text);
            if (strings.Count >= 5)
            {
                strings.RemoveAt(4);
            }
            for (int i = 0; i <= strings.Count - 1; i++)
            {
                gameText.SetText((string)strings[i] + gameText.text);
            }
        }
    }

    private void FixedUpdate()
    {
        if (timeToRemove<=0)
        {
            strings.Clear();
            gameText.SetText("");
        } else
        {
            timeToRemove -= speedOfRemoval * Time.deltaTime;
        }
        
    }
}
