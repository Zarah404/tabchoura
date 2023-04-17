using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_level : MonoBehaviour
{
  private bool isFalling = false;
    private Coroutine restartCoroutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isFalling = false;
            if (restartCoroutine != null)
            {
                StopCoroutine(restartCoroutine);
            }
        }
        else
        {
            isFalling = true;
            restartCoroutine = StartCoroutine(CheckFalling());
        }
    }

    private IEnumerator CheckFalling()
    {
        yield return new WaitForSeconds(2.0f); // wait for 2 seconds before checking if the player is still falling
        if (isFalling)
        {
            Debug.Log("Player fell off the platform!");
            yield return new WaitForSeconds(1.0f); // wait for 1 second before restarting the game
            Debug.Log("Restarting game...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("Player landed on a platform.");
        }
    }
}
