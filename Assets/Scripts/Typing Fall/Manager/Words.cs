using UnityEngine;

[System.Serializable]
public class Words
{
    public string wordLetter;
    public Sprite sprite1; // Sprite pertama
    public Sprite sprite2; // Sprite kedua
    public ParticleSystem particleEffect; // Efek partikel
    [SerializeField] public string tag; // Tag untuk prefab
}
