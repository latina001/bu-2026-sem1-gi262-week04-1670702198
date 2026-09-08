using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
             LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            // [Node 1] -> null
            linkedList.AddLast("Node 1");
            // [Node 1] -> [Node 2] ->null
            linkedList.AddLast("Node 2");
            // [Node 0] -> [Node 1] -> [Node 2] ->null
            linkedList.AddFirst("Node 0");

            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Value);
            Debug.Log(node1.Next.Value);
            Debug.Log(node1.Previous.Value);

            var firstNode = linkedList.First;
            var lastNode = linkedList.Last;
            Debug.Log(firstNode.Previous);
            Debug.Log(firstNode.Next);

            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");

            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.Remove("Node 1.5");

            linkedList.Clear();

            Debug.Log("----");
            foreach (var item in linkedList)
            {
                Debug.Log(item);
            }
        }

        public void LCT03_SyntaxHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("Potion", 5);
            table.Add(5, "Potion");

            foreach (var item in table)
            {
                Debug.Log($"Item {item}");
            }
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inv = new Dictionary<string, int>();

            inv.Add("Potion", 5);
            inv.Add("Banana", 1);
            inv.Add("Apple", 10);


            inv["Apple"] = 0;

            inv["Apple"] = 1;

            int potion = inv["Potion"];
            Debug.Log("Potion: " + potion);

            //int apple2 = inv["Apple2"];
            //Debug.Log("Apple2: " +  apple2);

            bool hasPotion = inv.ContainsKey("Potion");
            Debug.Log("hasPotion: " + hasPotion);

            inv.Remove("Banana");

            foreach (KeyValuePair<string, int> kvp in inv)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                Debug.Log($"{key} => {value}");
            }

            inv.Clear();
        }

        #endregion
    }
}
