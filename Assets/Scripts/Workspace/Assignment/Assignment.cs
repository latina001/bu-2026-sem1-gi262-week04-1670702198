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
             AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
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
            // ขั้นที่ 1: dictionary จับคู่วงเล็บเปิด -> วงเล็บปิด และ stack ว่าง
            Dictionary<char, char> pairs = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };
            LinkedList<char> stack = new LinkedList<char>();
            bool isValid = true;

            // ขั้นที่ 2: วนอ่านทีละตัวอักษร
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                // ขั้นที่ 3: วงเล็บเปิด -> เพิ่มท้าย stack
                if (pairs.ContainsKey(c))
                {
                    stack.AddLast(c);
                }
                // วงเล็บปิด (ตรวจว่าเป็น value ใน dictionary)
                else if (pairs.ContainsValue(c))
                {
                    // ขั้นที่ 4: stack ว่าง -> Invalid ทันที
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    // ขั้นที่ 5: เทียบกับวงเล็บเปิดล่าสุด
                    char lastOpen = stack.Last.Value;
                    if (pairs[lastOpen] != c)
                    {
                        isValid = false;
                        break;
                    }

                    stack.RemoveLast(); // ตรงกัน -> นำออก
                }
                // ตัวอักษรอื่นที่ไม่ใช่วงเล็บ -> ข้ามไป
            }

            // ขั้นที่ 6: Valid เฉพาะเมื่อ stack ว่าง
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
            // ขั้นที่ 1: ตรวจสอบลิสต์ว่าง
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            // ขั้นที่ 2: เริ่มที่โหนดสุดท้าย
            LinkedListNode<int> current = list.Last;

            // ขั้นที่ 3: วนตราบใดที่ยังไม่เป็น null
            while (current != null)
            {
                // ขั้นที่ 4: แสดงค่า แล้วถอยไปโหนดก่อนหน้า
                Debug.Log(current.Value);
                current = current.Previous;
            }

            // ขั้นที่ 5: current เป็น null = อ่านถึงโหนดแรกแล้ว ลิสต์เดิมไม่ถูกแก้ไข
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            // ขั้นที่ 1: ตรวจสอบลิสต์ว่าง
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            // ขั้นที่ 2: slow และ fast เริ่มที่โหนดแรกทั้งคู่
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            // ขั้นที่ 3: วนต่อเมื่อ fast และ fast.Next ไม่เป็น null
            while (fast != null && fast.Next != null)
            {
                // ขั้นที่ 4: slow เดิน 1 โหนด, fast เดิน 2 โหนด
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            // ขั้นที่ 5: slow อยู่ที่โหนดกลาง
            Debug.Log($"Middle element: {slow.Value}");
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            // ขั้นที่ 1: คัดลอก dict1 ไปเป็น mergedDictionary (ไม่แก้ dict1 เดิม)
            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            // ขั้นที่ 2: วนอ่านทีละคู่ key-value จาก dict2
            foreach (KeyValuePair<string, int> pair in dict2)
            {
                // ขั้นที่ 3: ตรวจสอบว่ามี key นี้อยู่แล้วหรือไม่
                if (mergedDictionary.ContainsKey(pair.Key))
                {
                    // ขั้นที่ 4: มีแล้ว -> บวกค่าเดิมกับค่าจาก dict2
                    mergedDictionary[pair.Key] += pair.Value;
                }
                else
                {
                    // ขั้นที่ 5: ยังไม่มี -> เพิ่ม key ใหม่
                    mergedDictionary.Add(pair.Key, pair.Value);
                }
            }

            // ขั้นที่ 6: แสดงทุกคู่ key-value
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
            // ขั้นที่ 1: มีสมาชิกมากกว่า 1 ตัวจึงต้องตรวจ duplicates
            if (list.Count > 1)
            {
                // ขั้นที่ 2: dictionary บันทึกตัวเลขที่เคยพบแล้ว
                Dictionary<int, bool> seen = new Dictionary<int, bool>();

                // ขั้นที่ 3: เริ่มที่โหนดแรก
                LinkedListNode<int> current = list.First;

                while (current != null)
                {
                    // ขั้นที่ 4: เก็บโหนดถัดไปไว้ก่อน เพราะ current อาจถูกลบ
                    LinkedListNode<int> next = current.Next;

                    // ขั้นที่ 5: เคยพบแล้ว -> ลบ / ยังไม่เคยพบ -> บันทึกลง dictionary
                    if (seen.ContainsKey(current.Value))
                    {
                        list.Remove(current);
                    }
                    else
                    {
                        seen.Add(current.Value, true);
                    }

                    // ขั้นที่ 6: ไปโหนดถัดไปที่เก็บไว้
                    current = next;
                }
            }

            // แสดงสมาชิกที่เหลือ
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
            // ขั้นที่ 1: ตรวจสอบ input ว่าง
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input is empty");
                return;
            }

            // ขั้นที่ 2: นับความถี่ของทุกตัวเลข (วนรอบแรก)
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

            // ขั้นที่ 3: เริ่มจากตัวเลขตัวแรกและ count ของมัน
            int topNumber = numbers[0];
            int topCount = counts[topNumber];

            // ขั้นที่ 4: วนตามลำดับเดิมอีกรอบ (วนรอบสอง)
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentCount = counts[numbers[i]];

                // ขั้นที่ 5: อัปเดตเฉพาะเมื่อ "มากกว่า" เท่านั้น (เท่ากันคงตัวที่พบก่อน)
                if (currentCount > topCount)
                {
                    topNumber = numbers[i];
                    topCount = currentCount;
                }
            }

            // ขั้นที่ 6: แสดงผล
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
            throw new System.NotImplementedException();
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
