using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZONE : MonoBehaviour
{
    IEnumerator cor()
    {
        ScreenFade.instance.FadeToBlack();
        yield return new WaitForSeconds(3f);
        ScreenFade.instance.FadeFromBlack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(cor());
            SceneManager.LoadScene("Island");
        }
    }
}
