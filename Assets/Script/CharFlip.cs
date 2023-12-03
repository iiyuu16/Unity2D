using System.Collections;
using UnityEngine;

public class CharFlip : MonoBehaviour
{
    private bool isRotating = false;
    public float rotateEvery = 5.0f;
    public float secondsToFlip = 1.0f;

    void Start()
    {
        StartCoroutine(RotateEveryFiveSeconds());
    }

    IEnumerator RotateEveryFiveSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(rotateEvery);

            if (isRotating)
            {
                RotateTo(0f);
            }
            else
            {
                RotateTo(180f);
            }

            isRotating = !isRotating;
        }
    }

    void RotateTo(float targetRotation)
    {
        StartCoroutine(RotateOverTime(targetRotation, secondsToFlip));
    }

    IEnumerator RotateOverTime(float targetRotation, float duration)
    {
        float elapsed = 0f;
        float startRotation = transform.rotation.eulerAngles.y;
        while (elapsed < duration)
        {
            float newRotation = Mathf.LerpAngle(startRotation, targetRotation, elapsed / duration);
            transform.rotation = Quaternion.Euler(0, newRotation, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, targetRotation, 0);
    }
}
