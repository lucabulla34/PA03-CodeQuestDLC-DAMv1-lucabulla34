# Chapter 6: Show Attacks by LVL - Logic Breakdown ✨

This section displays the list of spells unlocked by the wizard. It uses a **Jagged Array** (`string[][] levels`) to store lists of spells corresponding to specific levels. The logic maps the player's current level (`wizardLevel`) to the correct array index.

## A. Index Mapping and Safety Logic

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`int maxLevelIndex...`** | **Bounds Definition** | `maxLevelIndex` | Calculates the last valid index of the array (Length 5 -> Index 4). |
| **`int targetIndex...`** | **Index Alignment** | `targetIndex` | Converts the 1-based `wizardLevel` to a 0-based array index (e.g., Level 1 $\rightarrow$ Index 0). |
| **`if (targetIndex > max...)`** | **Overflow Protection** | `targetIndex` | **Crucial Safety:** Checks if the requested level exceeds the available content (e.g., Level 10 vs Max Level 5). |
| **`targetIndex = max...`** | **Clamping** | `targetIndex` | If out of bounds, forces the index to the maximum available (4), ensuring the program doesn't crash or show empty data. |
| **`for (int i...)`** | **Sub-Array Iteration** | `i` | Iterates through the specific array of strings found at `levels[targetIndex]`. |
| **`Console.Write`** | **Display** | N/A |  Prints the name of each spell in the sub-array. |

---

## B. Test Cases

### **Test Case 1: Normal Case (Standard Retrieval)**
**Scenario:** The wizard is **Level 2**. The system retrieves the spells for the second tier.
*Initial State: `wizardLevel` = 2, `levels[1]` contains {"Fireball", "Ice Ray", "Arcane Shield"}.*

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (Calc Max) | - | `max`=4 | - |
| **2** (Calc Target)| - | `target`=1 | 2 - 1 = 1. |
| **3** (Safety) | - | `target`=1 | 1 > 4 $\rightarrow$ **FALSE** |
| **4** (Loop) | 1 | `i`=0 | Output: "- Fireball" |
| **5** (Loop) | 2 | `i`=1 | Output: "- Ice Ray" |
| **6** (Loop) | 3 | `i`=2 | Output: "- Arcane Shield" |

### **Test Case 2: Limit Case (Level Cap Overflow)**
**Scenario:** The wizard has hypothetically reached **Level 10** (via debugging or future updates), but the content only exists up to Level 5 (Index 4). This tests the safety clamp.
*Initial State: `wizardLevel` = 10.*

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Calc Max) | `max`=4 | Array Length is 5. |
| **2** (Calc Target)| `target`=9 | 10 - 1 = 9. |
| **3** (Safety) | `target`=9 | 9 > 4 $\rightarrow$ **TRUE** |
| **4** (Correction) | `target`=4 | **Action:** Index clamped to 4. |
| **5** (Loop) | `levels[4]` | **Output:** Displays Level 5 spells (Cataclysm, etc.). No crash occurs. |
