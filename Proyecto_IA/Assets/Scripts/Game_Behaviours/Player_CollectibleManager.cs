using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class  Player_CollectibleManager : MonoBehaviour
{
    public Queue<GameObject> Collectibles = new Queue<GameObject>();
    private List<GameObject> _allList = new List<GameObject>();
    [HideInInspector] public List<GameObject> collectedList = new List<GameObject>();
    private int _collectibleTotal;
    bool madeEnemies;

    private void Start()
    {
        MakeList();
    }

    private void MakeList()
    {
        _allList = GameObject.FindGameObjectsWithTag("Collectible").ToList();
        _collectibleTotal = _allList.Count;
    }

    public void OnCollisionEnter(Collision collision)
    {
        CheckCollectible(collision);
        CheckEnemy(collision);
        

        
    }

    private void CheckCollectible(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Collectible")) return;
        if (Collectibles.Contains(collision.gameObject) || collectedList.Contains(collision.gameObject)) return;
        Collectibles.Enqueue(collision.gameObject);
        
    }

    private void CheckEnemy(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;
        Debug.Log("lost one");
        int last = collectedList.Count;
        collectedList[last-1].GetComponent<Collectible>().StopFollow();
        
    }

    public void Collect(GameObject collectible)
    {
        _allList.Remove(collectible);
        collectedList.Add(collectible);
        GameState();
    }

    public void UnCollect(GameObject collectible)
    {
        _allList.Add(collectible);
        collectedList.Remove(collectible);
        GameState();
    }

    private void GameState()
    {
        //tried using switch. Error: expects a constant value
        if (_allList.Count <= _collectibleTotal *.666f )
        {
            foreach (var collectible in _allList)
            {
                collectible.GetComponent<Collectible>().StartFlee();
            } 
        }
        
        if (_allList.Count <= _collectibleTotal *.333f)
        {
            foreach (var collectible in _allList)
            {
                collectible.GetComponent<Collectible>().StartAvoid();
            }

            int newFirst = 0;
            for (int i = 0; i < 2; i++)
            {
                newFirst ++;
                if (madeEnemies) return;
                collectedList[i].GetComponent<Collectible>().StartChase();
                collectedList[i].tag = "Enemy";
                collectedList.Remove(collectedList[i]);
                _allList.Remove(collectedList[i]);
                
            }

            madeEnemies = true;
            collectedList[newFirst].GetComponent<Collectible>().target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
