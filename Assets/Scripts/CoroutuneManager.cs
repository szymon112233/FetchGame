using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutuneManager : MonoBehaviour {
    
    public void StartCor(IEnumerator cor)
    {
        StartCoroutine(cor);
    }
}
