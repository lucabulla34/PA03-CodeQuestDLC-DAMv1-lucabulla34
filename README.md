# Chapter 7: Decode Ancient Scroll - Logic Breakdown

This section is a logic puzzle mini-game. It presents the user with three specific string manipulation tasks. The player must choose an operation to perform on specific parts of the "scroll" text. Progress is tracked via flags (`stepOne`, `stepTwo`, `stepThree`) to determine when the puzzle is fully solved.

## A. String Manipulation and Progress Logic

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`TryParse`** | **Input Validation** | `action`, `isAction` | Converts user menu selection to an integer. |
| **`switch (action)`** | **Task Router** | N/A | Directs the code to one of the three specific algorithms based on user input. |
| **`Replace(' ', '\0')`** | **Task 1: Decipher** | `stepOne` | Replaces all spaces in the string with a null character, visually simulating a "deciphered" continuous text. Sets the `stepOne` completion flag to 1. |
| **`foreach` + `Contains`** | **Task 2: Count** | `counter`, `stepTwo` | Iterates through every character in the text. If the character exists in the `vowels` string, `counter` increments. Sets `stepTwo` to 1. |
| **`foreach` + `Contains`** | **Task 3: Extract** | `extractedNumbers`, `stepThree` | Iterates through the text. If the character exists in the `numbers` string, it is concatenated to the result string. Sets `stepThree` to 1. |
| **`if (!isAction || ...)`** | **Error Handling** | N/A | Checks if the input was invalid (text) OR if the number chosen was outside the 1-3 range. |
| **`progress >= 3`** | **Win Condition** | `progress` | Sums up the step flags. If the total is 3 or higher, the "Congratulations" message is displayed. |

---

## B. Test Cases

### **Test Case 1: Normal Case (Task 2 - Vowel Counting)**
**Scenario:** The user selects Option 2 to count the vowels in the provided text.
*Initial State:* `ScrollPartTwo` = "Ancient magic", `vowels` = "aeiouAEIOU", `counter` = 0.

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (Input) | - | `action`=2 | Valid input $\rightarrow$ **TRUE** |
| **2** (Loop) | 1 | `char`='A' | Vowels contains 'A'? $\rightarrow$ **TRUE** (`counter`=1) |
| **3** (Loop) | 2 | `char`='n' | Vowels contains 'n'? $\rightarrow$ **FALSE** |
| **4** (Loop) | 3 | `char`='c' | Vowels contains 'c'? $\rightarrow$ **FALSE** |
| **5** (Loop) | 4 | `char`='i' | Vowels contains 'i'? $\rightarrow$ **TRUE** (`counter`=2) |
| **6** (Output) | - | `counter` | **Output:** "2 magical runes (vowels) found" |
| **7** (Flag) | - | `stepTwo` | Set to **1**. |

### **Test Case 2: Limit Case (Puzzle Completion)**
**Scenario:** The user has already completed tasks 1 and 2. They now select task 3 to finish the game. This tests the summation logic.
*Initial State:* `stepOne` = 1, `stepTwo` = 1, `stepThree` = 0, `action` = 3.

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Switch) | `case 3` | Execute extraction logic. |
| **2** (Flag) | `stepThree`=1 | Task marked complete. |
| **3** (Error Check) | 3 < 1 OR 3 > 3 | **FALSE** (No error). |
| **4** (Calc) | `progress` | 1 + 1 + 1 = 3. |
| **5** (Win Check) | `progress` >= 3 | 3 >= 3 $\rightarrow$ **TRUE** |
| **6** (Output) | - | **Output:** "Congratulations! You have successfully decoded..." |

### **Test Case 3: Error Case (Out of Range Input)**
**Scenario:** The user enters the number "5". While it is a valid integer (so `isAction` is true), it is not a valid menu option.
*Initial State:* `action` = 0, `isAction` = false.

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Input) | `action`=5 | `isAction`=**TRUE** (It is a number). |
| **2** (If isAction) | - | Enters `if` block. |
| **3** (Switch) | `action`=5 | No matching `case`. Skips to end of switch. |
| **4** (Error Check) | `action` > 3 | 5 > 3 $\rightarrow$ **TRUE** |
| **5** (Output) | - | **Output:** "Invalid option. Try again!" |
