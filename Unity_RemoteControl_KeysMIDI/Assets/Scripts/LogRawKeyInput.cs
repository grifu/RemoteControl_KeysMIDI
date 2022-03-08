using UnityEngine;
using UnityRawInput;
using UnityEngine.UI;
using WindowsInput;

public class LogRawKeyInput : MonoBehaviour
{
    public bool WorkInBackground;
    public bool InterceptMessages;
    public Text texto;
    public GameObject midiPrefab;
    InputSimulator IS;
    public int notaMIDI = 0;

    void Start()
    {
        notaMIDI = 0;
        IS = new InputSimulator();
    }

    private void OnEnable ()
    {
        RawKeyInput.Start(WorkInBackground);
        RawKeyInput.OnKeyUp += LogKeyUp;
        RawKeyInput.OnKeyDown += LogKeyDown;
    }

    private void OnDisable ()
    {
        RawKeyInput.Stop();
        RawKeyInput.OnKeyUp -= LogKeyUp;
        RawKeyInput.OnKeyDown -= LogKeyDown;
    }

    private void OnValidate ()
    {
        // Used for testing purposes, won't work in builds.
        // OnValidate is invoked only in the editor.
        RawKeyInput.InterceptMessages = InterceptMessages;
    }

    private void LogKeyUp (RawKey key)
    {
        
        texto.text = key.ToString();
        if(key.ToString() == "Up" || key.ToString() == "Down" || key.ToString() == "Left" || key.ToString() == "Right" || key.ToString() == "Next" || key.ToString() == "Prior"){
            Instantiate(midiPrefab); 
            IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);   
        }
           
        Debug.Log("Key Up: " + key);
    }

    private void LogKeyDown (RawKey key)
    {
        Debug.Log("Key Down: " + key);
    }

    public void MudaCanalMidi(UnityEngine.UI.Text valor){
        
        int.TryParse(valor.text, out notaMIDI);
        Debug.Log("valor = "+notaMIDI);
    }
}
