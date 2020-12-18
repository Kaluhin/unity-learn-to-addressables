using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _3._GameManager.Scripts.Menu
{
  public class LoadingScreen : MonoBehaviour
  {
    [SerializeField] private Slider _loadingProgress;
    
    public async Task LoadLevel(string levelName)
    {
      _loadingProgress.value = 0f;
      await GameManager.Instance.LoadLevel(levelName, OnProgressChanged);
    }

    private void OnProgressChanged(float progress)
    {
      _loadingProgress.value = progress;
    }
  }
}