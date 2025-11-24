# Chapter 5: Buy Items (Shop) - Logic Breakdown

This section simulates a shop interface. It handles displaying a catalog, validating user input against available funds (`totalBits`), and managing a dynamic inventory system using manual array resizing.

## A. Catalog Display and Input

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`for` Loop** | **Catalog UI** | N/A | Iterates through `itemsForSale` and `itemsPrice` arrays to display options 1-5 alongside their costs. |
| **`TryParse`** | **Input Validation** | `itemBought`, `isValid` | Attempts to convert user input to an integer. |
| **`isValid && ...`** | **Range Check** | N/A | Verifies the input is a number AND is between 1 and 5. |

## B. Transaction and Inventory Management

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`totalBits - price >= 0`** | **Affordability Check** | N/A | Calculates if the user has enough currency. Allows purchase if result is zero or positive. |
| **`totalBits -= price`** | **Payment** | `totalBits` | Deducts the item cost from the player's wallet. |
| **`new string[len + 1]`** | **Memory Allocation** | `tempInventory` | Creates a temporary array one slot larger than the current inventory. |
| **Copy Loop** | **Data Preservation** | `tempInventory` | Iterates through the old `inventory` and copies every item to the new `tempInventory`. |
| **Assignment** | **Add New Item** | `tempInventory` | Places the purchased item in the final (new) slot of the array. |
| **`inventory = temp`** | **Reference Update** | `inventory` | Updates the global `inventory` variable to point to the new, larger array. |

---

## C. Test Cases

### **Test Case 1: Error Case (Invalid Input Type)**
**Scenario:** The user types a string ("Sword") instead of a number selection.
*Initial State: `totalBits` = 100.*

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Input) | `opString`="Sword" | - |
| **2** (TryParse) | `itemBought`=0, `isValid`=**False** | Conversion Failed. |
| **3** (If Valid) | `isValid`=False | **FALSE** (Skips purchase block). |
| **4** (Error Check) | `!isValid`=True | **TRUE** |
| **5** (Output) | - | **Output:** "Invalid option. Try again!" |

### **Test Case 2: Limit Case (Exact Funds)**
**Scenario:** The user has exactly enough bits to buy the item (Iron Dagger, cost 30). Tests the `>= 0` boundary.
*Initial State: `totalBits` = 30, `inventory` is empty.*

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Input) | `itemBought`=1 | Valid selection. |
| **2** (Funds Check) | 30 - 30 = 0 | 0 >= 0 $\rightarrow$ **TRUE** (Allowed) |
| **3** (Payment) | `totalBits`=0 | Money reduced to zero. |
| **4** (Resize) | `tempInventory` | Size becomes 1. |
| **5** (Add) | `temp[0]`="Iron Dagger" | Item added. |
| **6** (Output) | - | **Output:** "You have purchased: Iron Dagger..." |

### **Test Case 3: Normal Case (Array Expansion)**
**Scenario:** The user buys an item (Potion) when they *already* have an item (Dagger) in their inventory. Tests the copy/resize logic.
*Initial State: `totalBits` = 50, `inventory` = {"Iron Dagger"}.*

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (Funds Check) | - | 50 - 10 = 40 | 40 >= 0 $\rightarrow$ **TRUE** |
| **2** (Resize) | - | `tempInventory` | Size becomes 2 (1 + 1). |
| **3** (Copy Loop) | 1 | `temp[0]` = `inv[0]` | "Iron Dagger" copied to new array. |
| **4** (Add New) | - | `temp[1]` = "Healing Potion" | New item added to end. |
| **5** (Reference) | - | `inventory` | Now points to array length 2. |
| **6** (Output) | - | `totalBits`=40 | **Output:** Purchase successful. |
