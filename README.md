# Chapter 4: Show Inventory - Logic Breakdown

This section handles the display of the player's current items. It performs a state check on the `inventory` array to determine whether to list items or display a specific "empty" message.

## A. State Check and Iteration

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`if (inventory.Length == 0)`** | **State Check (Empty)** | N/A | Checks if the array contains zero elements. If true, prints `MsgEmptyInventory`. |
| **`else`** | **State Check (Populated)** | N/A | Executes only if the array contains at least one item. |
| **`for (int i = 0; ...)`** | **Traversal** | `i` | Initializes a loop counter starting at index 0. |
| **`i < inventory.Length`** | **Boundary Condition** | N/A | Ensures the loop runs exactly as many times as there are items, preventing an `IndexOutOfRangeException`. |
| **`Console.WriteLine(...)`** | **Display** | N/A | Prints the string stored at the current index `inventory[i]`. |

---

## B. Test Cases

### **Test Case 1: Limit Case (Empty Inventory)**
**Scenario:** The player attempts to view the inventory before buying any items. The array is initialized but has a length of 0.
*Initial State: `inventory` = `new string[0]`.*

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Check) | `Length`=0 | 0 == 0 $\rightarrow$ **TRUE** |
| **2** (Output) | - | **Output:** "Your inventory is empty." |
| **3** (End) | - | **Action:** Break out of switch. |

### **Test Case 2: Normal Case (Multiple Items)**
**Scenario:** The player has purchased two items (e.g., a Dagger and a Potion).
*Initial State: `inventory` = `{"Iron Dagger", "Healing Potion"}` (Length = 2).*

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (Check) | - | `Length`=2 | 2 == 0 $\rightarrow$ **FALSE** |
| **2** (Header) | - | - | **Output:** "Your inventory contains:" |
| **3** (Loop) | 1 | `i`=0 | 0 < 2 $\rightarrow$ **TRUE** |
| **4** (Print) | 1 | `inventory[0]` | **Output:** "Iron Dagger" |
| **5** (Loop) | 2 | `i`=1 | 1 < 2 $\rightarrow$ **TRUE** |
| **6** (Print) | 2 | `inventory[1]` | **Output:** "Healing Potion" |
| **7** (Loop) | 3 | `i`=2 | 2 < 2 $\rightarrow$ **FALSE** (Loop Ends) |
