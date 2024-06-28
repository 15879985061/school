using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowTextAtLocation : MonoBehaviour
{
    public Text displayText;
    public float displayDuration = 3f; // 显示时间
    public float fadeDuration = 1f; // 渐变时间

    private bool isFading; // 是否正在进行渐变

    void Start()
    {
        displayText.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player")) // 如果玩家进入了碰撞体
        {
            ShowCustomText(displayText.text);
        }
        
        
    }

    public void ShowCustomText(string text)
    {
        if (displayText != null && !isFading)
        {
            displayText.text = text;
            displayText.gameObject.SetActive(true); // 激活文本显示
            // 开始显示文本
            StartCoroutine(FadeText(true));
        }
    }

    IEnumerator FadeText(bool fadeIn)
    {
        isFading = true;

        Color startColor = displayText.color;
        Color endColor = fadeIn ? new Color(startColor.r, startColor.g, startColor.b, 1f) : new Color(startColor.r, startColor.g, startColor.b, 0f);
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            // 根据时间插值改变透明度
            displayText.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        // 完成渐变后，根据fadeIn决定是否隐藏文本
        if (!fadeIn)
        {
            displayText.gameObject.SetActive(false);
        }

        isFading = false;

        // 如果是显示文本，延迟一段时间后开始隐藏
        if (fadeIn)
        {
            yield return new WaitForSeconds(displayDuration);
            StartCoroutine(FadeText(false));
        }
    }
}
