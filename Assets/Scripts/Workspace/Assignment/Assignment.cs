using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
             //AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
             //AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
             AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
         
            string[] words = as01Words;

            Dictionary<string, int> counter = new Dictionary<string, int>();

            // Count how many times each word appears
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (counter.ContainsKey(word))
                {
                    counter[word]++;
                }
                else
                {
                    counter[word] = 1;
                }
            }

            // Copy Keys / Values into arrays
            string[] keys = new string[counter.Count];
            int[] values = new int[counter.Count];
            counter.Keys.CopyTo(keys, 0);
            counter.Values.CopyTo(values, 0);

            // Print word and count at the same index
            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"word: '{keys[i]}' count: {values[i]}");
            }
        
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                  int number = numbers[i];
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else 
                {
                counts.Add(number, 1 );
                }
            }
            int[] keys = new int[counts.Count];
            int[] values = new int[counts.Count];
            counts .Keys.CopyTo(keys, 0);
            counts .Values.CopyTo(values, 0);

            for (int i = 0; i < keys.Length; i++) 
            {
                Debug.Log($"Numer{keys[i]} : count{values[i]} : ");
            }


        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            
            Dictionary<char, char> pairs = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };
            LinkedList<char> stack = new LinkedList<char>();
            bool isValid = true;

            
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

              
                if (pairs.ContainsKey(c))
                {
                    stack.AddLast(c);
                }
               
                else if (pairs.ContainsValue(c))
                {
                  
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                   
                    char lastOpen = stack.Last.Value;
                    if (pairs[lastOpen] != c)
                    {
                        isValid = false;
                        break;
                    }

                    stack.RemoveLast(); // ตรงกัน -> นำออก
                }
               
            }

           
            if (stack.Count > 0)
            {
                isValid = false;
            }

            Debug.Log(isValid ? "Valid" : "Invalid");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
           
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

           
            LinkedListNode<int> current = list.Last;

           
            while (current != null)
            {
              
                Debug.Log(current.Value);
                current = current.Previous;
            }

           
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
        
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

          
            while (fast != null && fast.Next != null)
            {
                
                slow = slow.Next;
                fast = fast.Next.Next;
            }

         
            Debug.Log($"Middle element: {slow.Value}");
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
           
            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

         
            foreach (KeyValuePair<string, int> pair in dict2)
            {
               
                if (mergedDictionary.ContainsKey(pair.Key))
                {
                   
                    mergedDictionary[pair.Key] += pair.Value;
                }
                else
                {
                 
                    mergedDictionary.Add(pair.Key, pair.Value);
                }
            }

         
            foreach (KeyValuePair<string, int> pair in mergedDictionary)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
          
            if (list.Count > 1)
            {
              
                Dictionary<int, bool> seen = new Dictionary<int, bool>();

               
                LinkedListNode<int> current = list.First;

                while (current != null)
                {
                  
                    LinkedListNode<int> next = current.Next;

                    
                    if (seen.ContainsKey(current.Value))
                    {
                        list.Remove(current);
                    }
                    else
                    {
                        seen.Add(current.Value, true);
                    }

                   
                    current = next;
                }
            }

            LinkedListNode<int> node = list.First;
            while (node != null)
            {
                Debug.Log(node.Value);
                node = node.Next;
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
           
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input is empty");
                return;
            }

         
            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];

                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts.Add(number, 1);
                }
            }

            int topNumber = numbers[0];
            int topCount = counts[topNumber];

           
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentCount = counts[numbers[i]];

                
                if (currentCount > topCount)
                {
                    topNumber = numbers[i];
                    topCount = currentCount;
                }
            }

            
            Debug.Log($" {topNumber} count: ({topCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
           
            if (inventory.ContainsKey(itemName))
            {
               
                inventory[itemName] += quantity;
            }
            else
            {
                
                inventory.Add(itemName, quantity);
            }

          
            foreach (KeyValuePair<string, int> pair in inventory)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

          
            while (eventQueue.Count > 0)
            {
                
                GameEvent currentEvent = eventQueue.First.Value;

                
                eventQueue.RemoveFirst();
                Debug.Log($"Processing event: {currentEvent.Name}");

                
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                
                switch (currentEvent.EventType)
                {
                    case "enemy":
                        Debug.Log($"Enemy event processed - {currentEvent.Name}");
                        break;
                    case "powerup":
                        Debug.Log($"Power-up event processed - {currentEvent.Name}");
                        break;
                    case "level":
                        Debug.Log($"Level event processed - {currentEvent.Name}");
                        break;
                    default:
                        Debug.LogWarning($"Unknown event type: '{currentEvent.EventType}'");
                        break;
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            
            if (playerStats.ContainsKey(statName))
            {
               
                playerStats[statName] += value;
            }
            else
            {
                
                playerStats.Add(statName, value);
            }

           // แสดงค่าใหม่ของ stat ที่อัปเดต แล้วตามด้วยทุกคู่ key-value
            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");
            foreach (KeyValuePair<string, int> pair in playerStats)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        #endregion
    }
}
