using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpLabel;

    private void Start()
    {
        GameManager.Instance.OnHpChanged += HpChanged;

        HpChanged(GameManager.Instance.Hp);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnHpChanged -= HpChanged;
    }

    private void HpChanged(int hp) =>
        _hpLabel.text = $"Hp: {hp}";
}