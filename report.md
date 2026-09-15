# Searching and Sorting: Report

Replace every bracketed prompt with your own work. Delete this line and any
prompt you have answered. **The finished report must be no more than two pages
of data and your own reflection.** Padding counts against you.

| | |
|---|---|
| Name | |
| Date | |
| Data | phonebook.csv, 200 contacts |

---

## 1. Searching unsorted data

| Field | Target | Case | Matches | Comparisons |
|---|---|---|---|---|
| LastName | | first record (best case) | | |
| LastName | | last record (worst case) | | |
| LastName | | absent value | | |
| Mobile | | absent value | | |

**Reflection.** [How many comparisons does a linear search need when the value is
absent, and why is that number the same for every absent value? Compare your
best case and worst case figures against the theoretical O(1) and O(n). Does a
search that finds nine matches cost more than one that finds none?]

## 2. Sorting

| Algorithm | Input shape | Comparisons | Swaps or moves |
|---|---|---|---|
| [Level 1 choice] | as supplied | | |
| [Level 1 choice] | already sorted | | |
| [Level 1 choice] | reverse sorted | | |
| [Level 2 choice] | as supplied | | |
| [Level 2 choice] | already sorted | | |
| [Level 2 choice] | reverse sorted | | |

**Reflection.** [Which algorithm did less work, and on which input shape? Which
one was hurt most by already sorted data, and which was helped by it? Quote your
own figures. State the best, average and worst case complexity of each algorithm
you implemented and say whether your counts agree with it.]

## 3. Searching sorted data

| Field | Target | Result | Comparisons |
|---|---|---|---|
| LastName | [a surname that appears several times] | index | |
| LastName | [absent value] | -1 | |
| Mobile | [a number from the file] | index | |
| FirstName | [a name that appears several times] | index | |

Linear search on the same targets, for comparison:

| Target | Comparisons (linear) | Comparisons (binary) |
|---|---|---|
| | | |

**Reflection.** [How many comparisons did binary search need against 200
contacts, and how does that compare with log2(200)? How do you guarantee the
first occurrence when a surname is duplicated? Sorting cost you the comparisons
in part 2: how many searches must you perform before sorting first pays for
itself?]

## 4. Insight

**One paragraph.** [What is the single most useful thing these figures taught you
about choosing an algorithm? Write about something your own numbers show, not
something you read.]
