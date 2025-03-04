using UnityEngine;


[CreateAssetMenu(fileName = "newObject", menuName = "CreateObject")]
public class ObjectDataSO : ScriptableObject
{
    public Sprite bubbleSprite;
    public Sprite popSprite;

    public ParticleSystem popParticle;

    public GameObject objectPrefab;
    public string objectName;

}
