using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameText : MonoBehaviour
{
    public static GameText instance;
    [SerializeField]
    private TMP_Text gameText;
    private ArrayList strings;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameText.SetText("");
    }
    public void addText(string text)
    {
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
                gameText.SetText((string)strings[i] + gameText);
            }
        }
    }
}
