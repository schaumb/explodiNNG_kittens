using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryStore : MonoBehaviour
{

    public GameObject[] Boxes;

    public Dictionary<KittyBox, KittyBox> MemoryPairs = new Dictionary<KittyBox, KittyBox>();

    // Use this for initialization
    void Start()
    {
        GameObject[] RandomizedBoxes = Boxes.OrderBy(box => Random.Range(0, Boxes.Length)).ToArray();

        for (var i = 0; i < RandomizedBoxes.Length; i += 2)
        {
            var pairOne = RandomizedBoxes[i].GetComponent<KittyBox>();
            var pairTwo = RandomizedBoxes[i + 1].GetComponent<KittyBox>();
            MemoryPairs.Add(pairOne, pairTwo);
            MemoryPairs.Add(pairTwo, pairOne);
        }
    }

    internal void Selected(KittyBox kittyBox)
    {
        var pair = this.MemoryPairs[kittyBox];
        Debug.Log(string.Format("Gameobject attached to selected KittyBox is named: {0}, its pair is named: {1}", kittyBox.gameObject.name, pair.gameObject.name));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
