using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameAsyncLoader : MonoBehaviour
{
    [SerializeField] private Image m_loadScreen;
    [SerializeField] private GameObject m_root;
    [SerializeField] private Slider m_progressBar;
    [SerializeField] private float m_hideScreenDuration = 0.5f;

    private const float LoadDuration = 5;
    
    private async void Start()
    {
        await AsyncLoading();
    }

    private async UniTask AsyncLoading()
    {
        DOTween.To(() => m_progressBar.value, x => m_progressBar.value = x, 1f, LoadDuration);
        
        await UniTask.Delay(TimeSpan.FromSeconds(LoadDuration));

        OnLoadingComplete();
    }

    private void OnLoadingComplete()
    {
        m_loadScreen.maskable = false;
        m_root.SetActive(false);
        
        DOTween.To(FadeScreen, m_loadScreen.color.a, 0, m_hideScreenDuration).OnComplete(HideScreen);
    }

    private void FadeScreen(float alpha)
    {
        Color color = m_loadScreen.color;
        color.a = alpha;
        
        m_loadScreen.color = color;
    }

    private void HideScreen()
    {
        Color color = m_loadScreen.color;
        color.a = byte.MaxValue;
        
        m_loadScreen.color = color;
        m_loadScreen.maskable = true;
        
        m_loadScreen.enabled = false;
    }
}