# Assignment 04: การเรียนรู้ Data Structures สำหรับ Game Development

## 🎯 จุดประสงค์การเรียนรู้

- เรียนรู้การใช้งาน LinkedList ใน C#
- เข้าใจการทำงานของ Hashtable และ Dictionary
- นำ Data Structures มาใช้ในการแก้ปัญหาในเกม
- จัดการข้อมูลแบบไดนามิกและมีประสิทธิภาพ
- เขียน code ที่ปลอดภัยและมีประสิทธิภาพในการจัดการข้อมูล

## 📚 โครงสร้างของ Assignment

- **Lecture Methods (3 methods)** - การ implement ฝึกหัดด้วย Data Structures พื้นฐาน พร้อมกันในห้องเรียน
- **Assignment Methods (11 methods)** - การประยุกต์ใช้ Data Structures ในสถานการณ์เกม

---

## ⚙️ การตั้งค่าและการรันใน Unity

1. เปิด scene `Lecture` สำหรับแบบฝึกหัด Lecture หรือ scene `Assignment` สำหรับแบบฝึกหัด Assignment
2. สำหรับแบบฝึกหัด Assignment ให้กำหนดข้อมูลใน Inspector ของ component `Assignment` ตาม field ที่ระบุในแต่ละข้อ
3. เปิดไฟล์ component ที่เกี่ยวข้อง แล้วเอา comment ออกจาก method ที่ต้องการทดสอบเพียงข้อเดียวใน `Start()` เช่น `// AS01_CountWords();` เป็น `AS01_CountWords();`
4. กด Play และดูผลลัพธ์ใน Console

`Lecture.cs` มีแบบฝึกหัด Lecture 3 ข้อ ซึ่งไม่มี input จาก Inspector ส่วน `Assignment.cs` มีแบบฝึกหัด 11 ข้อ โดยทุก method ไม่มี parameter และอ่าน input จาก serialized field ใน Inspector

### รูปแบบข้อมูลใน Inspector

- `IntLinkedListInput` และ `StringLinkedListInput`: กรอกสมาชิกใน array `values`
- `StringIntDictionaryInput`: เพิ่มสมาชิกใน array `entries` แล้วกรอก `key` และ `value` ของแต่ละรายการ
- `GameEventLinkedListInput`: เพิ่มสมาชิกใน array `values` แล้วกรอก `eventType`, `name` และ `priority` ของแต่ละ event

> **หมายเหตุเรื่องลำดับผลลัพธ์:** `Dictionary` และ `Hashtable` ไม่รับประกันลำดับข้อมูลตอนวนลูป ดังนั้น Test Case ของสองโครงสร้างนี้ให้ตรวจสอบว่ามีข้อความครบทุกบรรทัด โดยลำดับของบรรทัดอาจแตกต่างจากตัวอย่างได้ ส่วนผลลัพธ์จาก LinkedList และ event queue ต้องเรียงตามลำดับที่แสดงใน Test Case

## Lecture Methods

Methods เหล่านี้แสดงแนวคิด Data Structures พื้นฐาน Implement เพื่อฝึกหัดแต่จะไม่มีการให้คะแนน

### 1. LCT01_SyntaxLinkedList

**วัตถุประสงค์:** แสดงการประกาศและใช้งาน LinkedList พื้นฐาน รวมถึงการเพิ่ม ลบ และเข้าถึงข้อมูล

**Method Signature:**
```csharp
void LCT01_SyntaxLinkedList()
```

**Logic ที่ต้อง implement:**
> **แนวคิด:** `LinkedList<T>` เก็บข้อมูลเป็นโหนดที่เชื่อมต่อกัน จึงสามารถเข้าถึงโหนดแรกและโหนดสุดท้ายได้โดยตรง ลองแสดงผลในแต่ละขั้นเพื่อสังเกตว่าการเพิ่มและลบข้อมูลเปลี่ยนลำดับของโหนดอย่างไร

**ขั้นตอนแนะนำ:**
1. สร้างตัวแปร `LinkedList<string>` ว่างหนึ่งตัวเพื่อเก็บข้อความ
2. เพิ่ม `Node 1` และ `Node 2` ที่ท้ายลิสต์ด้วย `AddLast()` ตามลำดับ
3. เพิ่ม `Node 0` ที่ต้นลิสต์ด้วย `AddFirst()` แล้วใช้ลูป `foreach` แสดงสมาชิกทั้งหมด
4. อ่านโหนดแรกด้วย `First` และโหนดสุดท้ายด้วย `Last`; ใช้ `Find()` เพื่อค้นหาโหนดตามข้อความที่กำหนด
5. ใช้ `Find("Node 1")` หาโหนดเป้าหมาย แล้วเพิ่ม `Before Node 1` ด้วย `AddBefore()` และ `After Node 1` ด้วย `AddAfter()`
6. ใช้ `RemoveFirst()` เพื่อลบ `Node 0` จากนั้นใช้ `Remove("Node 2")` เพื่อลบ `Node 2` และแสดงผลลิสต์อีกครั้ง

**Test Case:**
- **Input:** ไม่มี parameters
- **ข้อมูลที่ใช้ใน method:** เริ่มจาก `Node 0`, `Node 1`, `Node 2`; เพิ่ม `Before Node 1` และ `After Node 1` รอบ `Node 1`; จากนั้นลบ `Node 0` และ `Node 2`
- **Expected Output:** ต้องแสดงลำดับเริ่มต้น `Node 0`, `Node 1`, `Node 2`, ค่าโหนดแรกและสุดท้าย, ผลตรวจสอบว่า `firstNode.Previous` และ `lastNode.Next` เป็น `null`, ลำดับหลังเพิ่มโหนด และลำดับสุดท้าย `Before Node 1`, `Node 1`, `After Node 1`

### 2. LCT02_SyntaxHashTable

**วัตถุประสงค์:** แสดงการใช้งาน Hashtable รวมถึงการเพิ่ม เข้าถึง และลบข้อมูล

**Method Signature:**
```csharp
void LCT02_SyntaxHashTable()
```

**Logic ที่ต้อง implement:**
> **แนวคิด:** `Hashtable` เก็บ key และ value เป็นชนิด `object` จึงใช้ key ได้หลายชนิด เมื่ออ่าน value ออกมาให้แปลงชนิดข้อมูล (cast) ให้ตรงกับชนิดที่ต้องการก่อนนำไปใช้

**ขั้นตอนแนะนำ:**
1. สร้าง `Hashtable` ว่างหนึ่งตัว
2. เพิ่ม key `1` ที่มี value เป็น `Apple`, key `2` ที่มี value เป็น `Banana` และ key `"bad-fruit"` ที่มี value เป็น `Rotten Tomato`
3. อ่านข้อมูลจาก key ที่รู้ค่าแน่นอน แล้วแปลง value ที่ได้เป็น `string` ก่อนแสดงผล
4. ใช้ `foreach` กับ `DictionaryEntry` เพื่ออ่านและแสดงทุกคู่ key-value ในตาราง
5. ใช้ `ContainsKey(2)` ตรวจสอบ key `2` แล้วใช้ `Remove(1)` ลบ key `1` และแสดงผลหลังลบ

**Test Case:**
- **Input:** ไม่มี parameters
- **ข้อมูลที่ใช้ใน method:** `{1: "Apple", 2: "Banana", "bad-fruit": "Rotten Tomato"}` และลบ key `1` หลังตรวจสอบ key `2`
- **Expected Output:** ต้องมี `fruit1: Apple`, `fruit2: Banana`, `badFruit: Rotten Tomato`, `found 2` และข้อมูลทั้ง 3 รายการก่อนลบ; หลังลบต้องเหลือเฉพาะ key `2` และ `"bad-fruit"` โดยไม่กำหนดลำดับบรรทัด

### 3. LCT03_SyntaxDictionary

**วัตถุประสงค์:** แสดงการใช้งาน Dictionary รวมถึงการเพิ่ม เข้าถึง และลบข้อมูล

**Method Signature:**
```csharp
void LCT03_SyntaxDictionary()
```

**Logic ที่ต้อง implement:**
> **แนวคิด:** `Dictionary<TKey, TValue>` ระบุชนิดของ key และ value ตั้งแต่สร้าง จึงปลอดภัยกว่า `Hashtable` ในเรื่องชนิดข้อมูล ใช้ `ContainsKey()` ก่อนอ่านหรือแก้ไขข้อมูลด้วย key ที่อาจไม่มีอยู่

**ขั้นตอนแนะนำ:**
1. สร้าง `Dictionary<int, string>` ว่าง เพื่อกำหนดให้ key เป็นตัวเลขและ value เป็นข้อความ
2. เพิ่ม `{1: "Apple", 2: "Banana"}` ด้วย `Add()` และเพิ่ม `{3: "Cherry"}` ด้วย indexer
3. ใช้ `foreach` กับ `KeyValuePair` เพื่อแสดง key และ value ทุกคู่
4. ตรวจสอบ key ที่ต้องการด้วย `ContainsKey()`; หากพบจึงอ่านและแสดง value ของ key นั้น
5. อ่าน key ทั้งหมดจาก `Keys` แล้ววนแสดงทีละ key
6. ลบ key `3` ด้วย `Remove()` แล้วแสดงจำนวนข้อมูลที่เหลือซึ่งต้องเป็น 2 จากนั้นใช้ `Clear()` เพื่อล้างข้อมูลโดยไม่ต้องแสดงจำนวนอีกครั้ง

**Test Case:**
- **Input:** ไม่มี parameters
- **ข้อมูลที่ใช้ใน method:** `{1: "Apple", 2: "Banana", 3: "Cherry"}` และลบ key `3` ก่อนเรียก `Clear()`
- **Expected Output:** ต้องมี `Dictionary has 3 keys`, `has key 1 : True`, `value of key 1 : Apple`, `All keys in dictionary:` พร้อม key `1`, `2`, `3` และ `Dictionary has 2 keys`; ลำดับของ key อาจแตกต่างจากตัวอย่างได้

XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

## Assignment Methods

Methods เหล่านี้เป็นการประยุกต์ใช้ Data Structures ในสถานการณ์เกม และจะมีการให้คะแนน

### AS01_CountWords

**วัตถุประสงค์:** นับจำนวนคำใน array ของ strings โดยใช้ Dictionary

**Method Signature:**
```csharp
void AS01_CountWords()
```

**Input ใน Inspector:** กำหนด array ของคำใน field `as01Words` โดยใช้ข้อมูลจากแต่ละ Test Case

**Logic ที่ต้อง implement:**
> **แนวคิด:** สร้าง dictionary ว่างเพื่อเก็บจำนวนครั้งที่พบคำ แล้ววนอ่านคำทีละคำ หากมี key นั้นอยู่แล้วให้เพิ่มค่าเดิม มิฉะนั้นให้เริ่มต้นที่ 1

**ขั้นตอนแนะนำ:**
1. สร้าง `Dictionary<string, int>` ว่างสำหรับเก็บคำและจำนวนครั้งที่พบ
2. วนลูป `for` ผ่าน `words` และเก็บคำปัจจุบันไว้ในตัวแปรชั่วคราว
3. ใช้ `ContainsKey()` ตรวจสอบว่าคำนั้นเคยพบแล้วหรือไม่
4. หากเคยพบแล้ว ให้เพิ่มค่า count เดิมขึ้น 1; หากยังไม่พบ ให้เพิ่มคำนี้ด้วยค่าเริ่มต้น 1
5. หลังนับครบแล้ว นำ `Keys` และ `Values` ไปเป็น array แล้ววนลูปแสดงคำกับจำนวนครั้งที่พบในตำแหน่งเดียวกัน

**Test Cases:**
> ผลลัพธ์ต้องมีคำและจำนวนครบทุกบรรทัด แต่ลำดับของคำอาจแตกต่างจากตัวอย่างได้

1. **Input:** `["apple", "banana", "apple", "cherry", "banana", "apple"]`
   **Expected Output:**
   ```
   word: 'apple' count: 3
   word: 'banana' count: 2
   word: 'cherry' count: 1
   ```

2. **Input:** `["hello", "world", "hello"]`
   **Expected Output:**
   ```
   word: 'hello' count: 2
   word: 'world' count: 1
   ```

3. **Input:** `["test"]`
   **Expected Output:**
   ```
   word: 'test' count: 1
   ```

### AS02_CountNumber

**วัตถุประสงค์:** นับจำนวนตัวเลขใน array ของ integers โดยใช้ Dictionary

**Method Signature:**
```csharp
void AS02_CountNumber()
```

**Input ใน Inspector:** กำหนด array ของตัวเลขใน field `as02Numbers` โดยใช้ข้อมูลจากแต่ละ Test Case

**Logic ที่ต้อง implement:**
> **แนวคิด:** วิธีทำเหมือนการนับคำ แต่ใช้ตัวเลขเป็น key ของ dictionary ระวังว่าตัวเลขติดลบและศูนย์ก็เป็น key ได้เช่นกัน

**ขั้นตอนแนะนำ:**
1. สร้าง `Dictionary<int, int>` ว่างสำหรับเก็บตัวเลขและจำนวนครั้งที่พบ
2. วนลูป `for` ผ่าน `numbers` และอ่านตัวเลขปัจจุบันทีละตัว
3. ตรวจสอบตัวเลขปัจจุบันด้วย `ContainsKey()`
4. หากมี key นี้แล้ว ให้เพิ่ม count เดิมขึ้น 1; หากยังไม่มี ให้เพิ่ม key ใหม่ด้วยค่า 1
5. เมื่อนับครบ ให้แปลง `Keys` และ `Values` เป็น array แล้วแสดงตัวเลขและ count ที่ตำแหน่งเดียวกัน

**Test Cases:**
> ผลลัพธ์ต้องมีตัวเลขและจำนวนครบทุกบรรทัด แต่ลำดับของตัวเลขอาจแตกต่างจากตัวอย่างได้

1. **Input:** `[1, 2, 3, 2, 1, 3, 1]`
   **Expected Output:**
   ```
   number: 1 count: 3
   number: 2 count: 2
   number: 3 count: 2
   ```

2. **Input:** `[5, 5, 5]`
   **Expected Output:**
   ```
   number: 5 count: 3
   ```

3. **Input:** `[0, -1, 2, 0, -1]`
   **Expected Output:**
   ```
   number: 0 count: 2
   number: -1 count: 2
   number: 2 count: 1
   ```

### AS03_CheckValidBrackets

**วัตถุประสงค์:** ตรวจสอบความถูกต้องของวงเล็บใน string โดยใช้ Dictionary และ LinkedList

**Method Signature:**
```csharp
void AS03_CheckValidBrackets()
```

**Input ใน Inspector:** กำหนด string ที่ต้องตรวจสอบใน field `as03Input`

**Logic ที่ต้อง implement:**
> **แนวคิด:** ใช้ `LinkedList<char>` เสมือน stack โดยเพิ่มวงเล็บเปิดไว้ท้ายลิสต์ และนำวงเล็บเปิดล่าสุดออกจากท้ายลิสต์เมื่อพบวงเล็บปิด ตัวอักษรที่ไม่ใช่วงเล็บควรถูกข้ามไป

**ขั้นตอนแนะนำ:**
1. สร้าง dictionary ที่จับคู่วงเล็บเปิดกับวงเล็บปิด และสร้าง `LinkedList<char>` ว่างเป็น stack
2. วนอ่านตัวอักษรทีละตัวใน `input`
3. หากตัวอักษรเป็นวงเล็บเปิด ให้เพิ่มลงท้าย stack ด้วย `AddLast()`
4. หากตัวอักษรเป็นวงเล็บปิด ให้ตรวจสอบก่อนว่า stack ว่างหรือไม่; ถ้าว่างให้สรุปว่า `Invalid` ทันที
5. หาก stack ไม่ว่าง ให้เปรียบเทียบวงเล็บปิดกับวงเล็บเปิดใน `stack.Last`; ถ้าไม่ตรงกันให้สรุปว่า `Invalid`, ถ้าตรงกันจึงนำวงเล็บเปิดนั้นออก
6. หลังอ่านครบทุกตัวอักษร ให้เป็น `Valid` เฉพาะเมื่อ stack ว่าง; หากยังเหลือวงเล็บเปิดอยู่ให้เป็น `Invalid`

**Test Cases:**
1. **Input:** `"()"`
   **Expected Output:** `Valid`

2. **Input:** `"([{}])"`
   **Expected Output:** `Valid`

3. **Input:** `"(]"`
   **Expected Output:** `Invalid`

4. **Input:** `"abc(def)ghi"`
   **Expected Output:** `Valid`

5. **Input:** `""`
   **Expected Output:** `Valid`

6. **Input:** `"("`
   **Expected Output:** `Invalid`

7. **Input:** `")"`
   **Expected Output:** `Invalid`

### AS04_PrintReverseLinkedList

**วัตถุประสงค์:** พิมพ์ LinkedList ในลำดับย้อนกลับโดยไม่แก้ไข list เดิม

**Method Signature:**
```csharp
void AS04_PrintReverseLinkedList()
```

**Input ใน Inspector:** กรอกข้อมูล list ใน field `as04List` (`IntLinkedListInput`) ที่ array `values`

**Logic ที่ต้อง implement:**
> **แนวคิด:** ไม่ต้องสร้างลิสต์ใหม่หรือกลับด้านลิสต์ ให้เริ่มที่ `list.Last` แล้วเดินตาม `Previous` ไปทีละโหนดจนถึง `null` เพื่อรักษาลำดับเดิมของลิสต์ไว้

**ขั้นตอนแนะนำ:**
1. `IntLinkedListInput.GetLinkedList()` จะสร้างลิสต์ให้เสมอ จึงตรวจสอบว่า `list.Count` เท่ากับ 0; หากใช่ ให้แสดงข้อความสำหรับลิสต์ว่างและจบการทำงาน
2. สร้างตัวแปรโหนดปัจจุบันให้เริ่มที่ `list.Last`
3. ใช้ลูป `while` ทำงานตราบใดที่โหนดปัจจุบันไม่เป็น `null`
4. ในแต่ละรอบ ให้แสดง `Value` ของโหนดปัจจุบัน แล้วเลื่อนตัวแปรไปที่ `Previous`
5. เมื่อตัวแปรเป็น `null` แสดงว่าอ่านถึงโหนดแรกแล้ว และลิสต์เดิมไม่ถูกแก้ไข

**Test Cases:**
1. **Input:** LinkedList with [1, 2, 3, 4, 5]
   **Expected Output:**
   ```
   5
   4
   3
   2
   1
   ```

2. **Input:** LinkedList with [42]
   **Expected Output:** `42`

3. **Input:** Empty LinkedList
   **Expected Output:** `List is empty`

### AS05_FindMiddleElement

**วัตถุประสงค์:** หา element กลางของ LinkedList โดยใช้ two-pointer technique

**Method Signature:**
```csharp
void AS05_FindMiddleElement()
```

**Input ใน Inspector:** กรอกข้อมูล list ใน field `as05List` (`StringLinkedListInput`) ที่ array `values`

**Logic ที่ต้อง implement:**
> **แนวคิด:** ให้ตัวชี้ `slow` และ `fast` เริ่มที่โหนดแรก ทุกครั้งที่วนลูป `slow` เดิน 1 โหนด ส่วน `fast` เดิน 2 โหนด สำหรับลิสต์ที่มีจำนวนสมาชิกคู่ ให้เลือกสมาชิกตรงกลางด้านหลังตามตัวอย่าง `A, B, C, D` ซึ่งได้ `C`

> **ทำไมไม่ใช้ `Count`:** ใน C# สามารถใช้ `list.Count` แล้วเดินไปที่ตำแหน่ง `list.Count / 2` ได้ ซึ่งเป็นวิธีที่ง่ายและให้คำตอบถูกต้องสำหรับโจทย์นี้เช่นกัน อย่างไรก็ตาม แบบฝึกหัดนี้กำหนดให้ใช้ `slow` และ `fast` เพื่อฝึกการเดินผ่านโหนดด้วยตัวชี้สองตัว (two-pointer technique) ซึ่งเป็นแนวคิดที่นำไปใช้ต่อได้กับปัญหาอื่น เช่น การตรวจหาวงวนใน LinkedList

**ทำไมจึงหาโหนดกลางได้:** `fast` เดินเร็วกว่า `slow` สองเท่า เมื่อ `fast` เดินถึงท้ายลิสต์ `slow` จึงเดินมาได้เพียงครึ่งทางพอดี และอยู่ที่โหนดกลาง ไม่จำเป็นต้องนับจำนวนสมาชิกก่อน

**ลองติดตามการเดินของตัวชี้:**

สำหรับลิสต์จำนวนคี่ `[A, B, C]`

| รอบ | `slow` | `fast` |
| --- | --- | --- |
| เริ่มต้น | A | A |
| เดินรอบที่ 1 | B | C |
| หยุด เพราะ `fast.Next` เป็น `null` | B | C |

ดังนั้นคำตอบคือ `B`

สำหรับลิสต์จำนวนคู่ `[A, B, C, D]`

| รอบ | `slow` | `fast` |
| --- | --- | --- |
| เริ่มต้น | A | A |
| เดินรอบที่ 1 | B | C |
| เดินรอบที่ 2 | C | ถึงท้ายลิสต์ |

ดังนั้นคำตอบคือ `C` ซึ่งเป็นโหนดกลางด้านหลังตามกติกาของแบบฝึกหัดนี้

> **ข้อควรระวัง:** ก่อนให้ `fast` เดิน 2 ก้าว ต้องตรวจสอบทั้ง `fast` และ `fast.Next` ว่าไม่เป็น `null` เสมอ มิฉะนั้นโปรแกรมอาจเกิด error เมื่อพยายามอ่าน `Next` ของโหนดที่ไม่มีอยู่

**ขั้นตอนแนะนำ:**
1. `StringLinkedListInput.GetLinkedList()` จะสร้างลิสต์ให้เสมอ จึงตรวจสอบว่า `list.Count` เท่ากับ 0; หากใช่ ให้แสดงข้อความสำหรับลิสต์ว่างและจบการทำงาน
2. สร้างตัวแปรโหนด `slow` และ `fast` ให้เริ่มต้นที่ `list.First` ทั้งคู่
3. วนลูปต่อเมื่อ `fast` และ `fast.Next` ไม่เป็น `null` เพื่อให้ `fast` เดินได้อย่างปลอดภัย 2 ก้าว
4. ในแต่ละรอบ ให้เลื่อน `slow` ไปที่ `slow.Next` หนึ่งครั้ง และเลื่อน `fast` ไปที่ `fast.Next.Next` หนึ่งครั้ง
5. เมื่อลูปจบ ให้แสดง `slow.Value`; สำหรับจำนวนสมาชิกคู่ วิธีนี้จะได้สมาชิกตรงกลางด้านหลังตาม Test Case

**Test Cases:**
1. **Input:** `["A", "B", "C"]`
   **Expected Output:** `B`

2. **Input:** `["A", "B", "C", "D"]`
   **Expected Output:** `C`

3. **Input:** `["A"]`
   **Expected Output:** `A`

4. **Input:** Empty LinkedList
   **Expected Output:** `List is empty`

### AS06_MergeDictionaries

**วัตถุประสงค์:** รวมสอง Dictionary โดยรวมค่าของ keys ที่ซ้ำกัน

**Method Signature:**
```csharp
void AS06_MergeDictionaries()
```

**Input ใน Inspector:** กรอก dictionary แรกใน `as06FirstDictionary` และ dictionary ที่สองใน `as06SecondDictionary` โดยแต่ละ field ใช้ `StringIntDictionaryInput` และ array `entries`

**Logic ที่ต้อง implement:**
> **แนวคิด:** สร้าง dictionary ผลลัพธ์ใหม่จาก `dict1` เพื่อไม่แก้ไข input เดิม จากนั้นวนอ่านทุกคู่ key-value ใน `dict2`; key ที่ซ้ำให้บวกค่า ส่วน key ใหม่ให้เพิ่มเข้าไป

**ขั้นตอนแนะนำ:**
1. สร้าง `mergedDictionary` ใหม่ โดยคัดลอกข้อมูลทั้งหมดจาก `dict1` เพื่อเก็บผลลัพธ์โดยไม่แก้ไข dictionary ต้นฉบับ
2. วนลูปอ่านข้อมูลทีละคู่ key-value จาก `dict2`
3. ตรวจสอบด้วย `ContainsKey()` ว่า `mergedDictionary` มี key ของคู่ปัจจุบันอยู่แล้วหรือไม่
4. หากมี key อยู่แล้ว ให้นำค่าเดิมมาบวกกับ value จาก `dict2` แล้วเก็บค่าที่ได้กลับเข้า key เดิม
5. หากยังไม่มี key นี้ ให้เพิ่ม key และ value จาก `dict2` ลงใน `mergedDictionary`
6. วนลูปแสดงทุกคู่ key-value ใน `mergedDictionary` ตามรูปแบบผลลัพธ์ที่กำหนด

**Test Cases:**
> ผลลัพธ์ต้องมี key และ value ครบทุกคู่ แต่ลำดับของบรรทัดอาจแตกต่างจากตัวอย่างได้

1. **Input:** dict1 = {"apple":3, "banana":2}, dict2 = {"apple":1, "cherry":4}
   **Expected Output:** ประกอบด้วย "key: apple, value: 4", "key: banana, value: 2", "key: cherry, value: 4"

2. **Input:** dict1 = {"a":1, "b":2}, dict2 = {"c":3, "d":4}
   **Expected Output:** ประกอบด้วย "key: a, value: 1", "key: b, value: 2", "key: c, value: 3", "key: d, value: 4"

### AS07_RemoveDuplicatesFromLinkedList

**วัตถุประสงค์:** ลบ duplicates ออกจาก LinkedList โดยเก็บเฉพาะตัวแรก

**Method Signature:**
```csharp
void AS07_RemoveDuplicatesFromLinkedList()
```

**Input ใน Inspector:** กรอกข้อมูล list ใน field `as07List` (`IntLinkedListInput`) ที่ array `values`

**Logic ที่ต้อง implement:**
> **แนวคิด:** ใช้ dictionary เป็นชุดข้อมูลที่บอกว่าเคยพบตัวเลขใดแล้ว ขณะวนผ่าน linked list หากจะลบโหนด ให้เก็บโหนดถัดไปไว้ก่อน เพื่อให้วนลูปต่อได้หลัง `Remove()`

**ขั้นตอนแนะนำ:**
1. `IntLinkedListInput.GetLinkedList()` จะสร้างลิสต์ให้เสมอ หากมีสมาชิกไม่เกิน 1 ตัว ให้แสดงผลตามปกติและไม่ต้องลบข้อมูล
2. สร้าง `Dictionary<int, bool>` ว่างเพื่อบันทึกตัวเลขที่เคยพบ
3. เริ่มที่ `list.First` และวนลูปตราบใดที่โหนดปัจจุบันไม่เป็น `null`
4. เก็บ `current.Next` ไว้ในตัวแปรก่อนเสมอ เพราะโหนดปัจจุบันอาจถูกลบออกจากลิสต์
5. หาก `current.Value` เคยอยู่ใน dictionary แล้ว ให้ลบ `current`; หากยังไม่เคยพบ ให้เพิ่มค่านั้นลงใน dictionary
6. ย้ายไปทำงานกับโหนดถัดไปที่เก็บไว้ แล้ววนแสดงสมาชิกที่เหลือหลังลบข้อมูลซ้ำ

**Test Cases:**
1. **Input:** [1, 2, 2, 3, 3, 3, 4]
   **Expected Output:**
   ```
   1
   2
   3
   4
   ```

2. **Input:** [5, 5, 5, 5]
   **Expected Output:** `5`

3. **Input:** [1, 2, 3, 4]
   **Expected Output:**
   ```
   1
   2
   3
   4
   ```

4. **Input:** [1, 2, 1, 3, 2]
   **Expected Output:**
   ```
   1
   2
   3
   ```

### AS08_TopFrequentNumber

**วัตถุประสงค์:** หาตัวเลขที่ปรากฏบ่อยที่สุดใน array

**Method Signature:**
```csharp
void AS08_TopFrequentNumber()
```

**Input ใน Inspector:** กำหนด array ของตัวเลขใน field `as08Numbers`

**Logic ที่ต้อง implement:**
> **แนวคิด:** นับความถี่ของทุกตัวเลขก่อน แล้ววนดู dictionary เพื่อหาค่าที่มี count สูงสุด เริ่มต้นคำตอบจากตัวเลขตัวแรกที่พบ; หากมีความถี่เท่ากัน ให้คงตัวเลขที่พบก่อนเพื่อให้ตรงกับตัวอย่าง

**ขั้นตอนแนะนำ:**
1. ตรวจสอบว่า `numbers` เป็น `null` หรือไม่มีสมาชิก; หากใช่ ให้แสดงข้อความว่า input ว่างและจบการทำงาน
2. สร้าง dictionary สำหรับนับความถี่ แล้ววนผ่าน `numbers` รอบแรกเพื่อเพิ่ม count ของแต่ละตัวเลข
3. กำหนดตัวเลขที่พบบ่อยที่สุดให้เริ่มเป็น `numbers[0]` และกำหนด count สูงสุดจากค่าของตัวเลขนั้นใน dictionary
4. วนผ่าน `numbers` ตามลำดับเดิมอีกครั้ง แล้วอ่าน count ของตัวเลขปัจจุบันจาก dictionary
5. อัปเดตคำตอบเฉพาะเมื่อ count ปัจจุบันมากกว่า count สูงสุด ห้ามอัปเดตเมื่อเท่ากัน เพื่อคงตัวเลขที่ปรากฏก่อนใน input
6. แสดงตัวเลขที่เลือกและจำนวนครั้งที่พบตามรูปแบบที่กำหนด

**Test Cases:**
1. **Input:** `[1, 2, 3, 2, 2, 1]`
   **Expected Output:** `2 count: 3`

2. **Input:** `[5, 5, 5, 5]`
   **Expected Output:** `5 count: 4`

3. **Input:** `[1, 2, 3, 4]`
   **Expected Output:** `1 count: 1`

4. **Input:** `[]`
   **Expected Output:** `Input array is empty`

### AS09_PlayerInventory

**วัตถุประสงค์:** อัปเดต inventory ของผู้เล่นโดยเพิ่มไอเท็ม

**Method Signature:**
```csharp
void AS09_PlayerInventory()
```

**Input ใน Inspector:** กรอก inventory ใน `as09Inventory` (`StringIntDictionaryInput`) และกำหนด item ที่เพิ่มใน `as09ItemName` กับจำนวนใน `as09Quantity`

**Logic ที่ต้อง implement:**
> **แนวคิด:** inventory คือ dictionary ที่แก้ไขได้โดยตรง ใช้ `ContainsKey(itemName)` เพื่อตัดสินใจว่าจะเพิ่มจำนวนให้รายการเดิม หรือเพิ่มรายการใหม่ จากนั้นวนแสดงทุกคู่ key-value

**ขั้นตอนแนะนำ:**
1. `StringIntDictionaryInput.GetDictionary()` จะสร้าง dictionary ให้เสมอ แม้ `entries` จะว่าง
2. ใช้ `ContainsKey(itemName)` ตรวจสอบว่าไอเท็มที่ต้องการเพิ่มมีอยู่แล้วหรือไม่
3. หากไอเท็มมีอยู่แล้ว ให้นำจำนวนเดิมมาบวกกับ `quantity` แล้วอัปเดต value ของ key เดิม
4. หากยังไม่มีไอเท็มนี้ ให้เพิ่ม `itemName` เป็น key ใหม่และใช้ `quantity` เป็น value เริ่มต้น
5. วนแสดงทุกคู่ key-value ใน `inventory` หลังอัปเดต เพื่อยืนยันผลลัพธ์

**Test Cases:**
> ผลลัพธ์ต้องมีไอเท็มและจำนวนครบทุกคู่ แต่ลำดับของบรรทัดอาจแตกต่างจากตัวอย่างได้

1. **Input:** inventory = `{"sword":1, "potion":5}`, itemName = `"shield"`, quantity = `2`
   **Expected Output:** จะต้องมี `sword: 1`, `potion: 5`, `shield: 2`

2. **Input:** inventory = `{"sword":1, "potion":5}`, itemName = `"potion"`, quantity = `3`
   **Expected Output:** จะต้องมี `sword: 1`, `potion: 8`

3. **Input:** inventory = `{}`, itemName = `"potion"`, quantity = `3`
   **Expected Output:** จะต้องมี `potion: 3`

### AS10_GameEventQueue

**วัตถุประสงค์:** ประมวลผล event ใน queue ของเกม

**Method Signature:**
```csharp
void AS10_GameEventQueue()
```

**Input ใน Inspector:** กรอก queue ใน field `as10EventQueue` (`GameEventLinkedListInput`) ที่ array `values` โดยใช้ `eventType` ได้เฉพาะ `enemy`, `powerup` หรือ `level` ในแบบฝึกหัดนี้ field `priority` ไม่ถูกใช้ และ event ต้องถูกประมวลผลตามลำดับที่กรอกใน Inspector

**Logic ที่ต้อง implement:**
> **แนวคิด:** ใช้ `LinkedList<GameEvent>` เป็นคิวแบบ FIFO: อ่าน event จาก `First` แล้วค่อย `RemoveFirst()` ทุกครั้งที่ประมวลผล ตรวจสอบ `EventType` เพื่อเลือกข้อความผลลัพธ์ของแต่ละประเภท event โดยไม่ต้องเรียงลำดับตาม `priority`

**ขั้นตอนแนะนำ:**
1. `GameEventLinkedListInput.GetLinkedList()` จะสร้างคิวให้เสมอ จึงตรวจสอบว่า `eventQueue.Count` เท่ากับ 0; หากใช่ ให้แสดง `Event queue is empty` แล้วจบการทำงานโดยไม่พยายามอ่าน `First`
2. ใช้ลูป `while` ทำงานตราบใดที่ `eventQueue.Count` มากกว่า 0
3. อ่าน event ตัวแรกจาก `eventQueue.First.Value` แล้วเก็บไว้ในตัวแปรก่อนนำออกจากคิว
4. ลบ event ตัวแรกด้วย `RemoveFirst()` และแสดงชื่อ event ที่กำลังประมวลผล
5. แสดงจำนวน event ที่เหลือหลังลบ โดยอ่าน `eventQueue.Count`
6. ตรวจสอบ `EventType` ของ event ที่เก็บไว้ แล้วแสดงข้อความที่ตรงกับ event ประเภท `enemy`, `powerup` หรือ `level`

**Test Cases:**
1. **Input:** Queue with events `"enemy":"Goblin appeared"`, `"powerup":"Health boost found"`, `"level":"Reached level 2"`
   **Expected Output:**
   ```
   Processing event: Goblin appeared
   Remaining events in queue: 2
   Enemy event processed - Goblin appeared
   Processing event: Health boost found
   Remaining events in queue: 1
   Power-up event processed - Health boost found
   Processing event: Reached level 2
   Remaining events in queue: 0
   Level event processed - Reached level 2
   ```

2. **Input:** Empty Queue
   **Expected Output:** `Event queue is empty`

### AS11_PlayerStatsTracker

**วัตถุประสงค์:** อัปเดตสถิติของผู้เล่น

**Method Signature:**
```csharp
void AS11_PlayerStatsTracker()
```

**Input ใน Inspector:** กรอก statistics ใน `as11PlayerStats` (`StringIntDictionaryInput`) และกำหนด stat ที่อัปเดตใน `as11StatName` กับค่าที่เพิ่มใน `as11Value`

**Logic ที่ต้อง implement:**
> **แนวคิด:** ใช้ `statName` เป็น key ของ dictionary หาก stat มีอยู่แล้วให้บวก `value` เข้ากับค่าปัจจุบัน มิฉะนั้นให้สร้าง stat ใหม่ด้วยค่าเริ่มต้นเป็น `value` แล้วแสดงสถานะทั้งหมดหลังอัปเดต

**ขั้นตอนแนะนำ:**
1. `StringIntDictionaryInput.GetDictionary()` จะสร้าง dictionary ให้เสมอ แม้ `entries` จะว่าง
2. ใช้ `ContainsKey(statName)` ตรวจสอบว่าสถิติที่ต้องการอัปเดตมีอยู่แล้วหรือไม่
3. หากมี stat นี้อยู่แล้ว ให้นำค่าปัจจุบันมาบวกกับ `value` แล้วบันทึกค่าที่ได้กลับเข้า key เดิม
4. หากยังไม่มี stat นี้ ให้เพิ่ม `statName` เป็น key ใหม่และใช้ `value` เป็นค่าเริ่มต้น
5. แสดงค่าใหม่ของ stat ที่อัปเดต แล้ววนแสดงทุกคู่ key-value ใน `playerStats`

**Test Cases:**
> ต้องแสดงบรรทัด `Updated ...` และ `Current player statistics:` ตามลำดับก่อน จากนั้นต้องมีสถิติและค่าครบทุกคู่ โดยลำดับของบรรทัดสถิติอาจแตกต่างจากตัวอย่างได้

1. **Input:** playerStats = `{"kills":10, "deaths":2}`, statName = `"assists"`, value = `5`
   **Expected Output:** จะต้องมี Updated assists: 5, "Current player statistics:", "kills: 10", "deaths: 2", "assists: 5"
   ```
    Updated assists: 5
    Current player statistics:
    kills: 10
    deaths: 2
    assists: 5
   ```

2. **Input:** playerStats = `{"kills":10, "deaths":2}`, statName = `"kills"`, value = `3`
   **Expected Output:** จะต้องมี "Updated kills: 13", "Current player statistics:", "kills: 13", "deaths: 2"
    ```
    Updated kills: 13
    Current player statistics:
    kills: 13
    deaths: 2
    ```
