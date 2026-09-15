# Searching and Sorting: Report

| | |
|---|---|
| Name | Abdulla Al Harun |
| Date | 15 September 2026 |
| Data | phonebook.csv, 200 contacts |

---

## 1. Searching unsorted data

| Field | Target | Case | Matches | Comparisons |
|---|---|---|---:|---:|
| LastName | Bjerke | first record (best case) | 9 | 200 |
| LastName | Hansen | last record (worst case) | 7 | 200 |
| LastName | Aardal | absent value | 0 | 200 |
| Mobile | 00000000 | absent value | 0 | 200 |

**Reflection.**  
My linear search used 200 comparisons in all four tests. This is because my
method searches through the whole array so that it can return all matches, not
only the first one. This is important for names because the same name can appear
several times. For example, Bjerke had 9 matches but still needed 200
comparisons. Aardal had no matches and also needed 200 comparisons. In theory,
linear search can have a best case of O(1) if it stops after finding the first
match, and the worst case is O(n). In my implementation I need all matches, so
the complete array is checked.

## 2. Sorting

| Algorithm | Input shape | Comparisons | Swaps or moves |
|---|---|---:|---:|
| Insertion Sort | as supplied | 9691 | 9494 |
| Insertion Sort | already sorted | 199 | 0 |
| Insertion Sort | reverse sorted | 19571 | 19411 |
| Merge Sort | as supplied | 1282 | 1544 |
| Merge Sort | already sorted | 812 | 1544 |
| Merge Sort | reverse sorted | 890 | 1544 |

**Reflection.**  
The biggest difference was with Insertion Sort. It only needed 199 comparisons
and 0 moves when the data was already sorted, but reverse sorted data needed
19571 comparisons and 19411 moves. Merge Sort was more consistent. It used 1282
comparisons on the original data, 812 when already sorted and 890 when reverse
sorted. Insertion Sort has O(n) best case and O(n²) average and worst case.
Merge Sort has O(n log n) in the best, average and worst cases. My results show
this difference quite clearly. For moves, I counted shifts in Insertion Sort.
For Merge Sort, I counted contacts copied from the temporary array back to the
main array.

## 3. Searching sorted data

| Field | Target | Result | Comparisons |
|---|---|---:|---:|
| LastName | Amundsen | 2 | 8 |
| LastName | Aardal | -1 | 7 |
| Mobile | 49502717 | 100 | 7 |
| FirstName | Andreas | 4 | 8 |

Linear search on the same type of targets, for comparison:

| Target | Comparisons (linear) | Comparisons (binary) |
|---|---:|---:|
| Bjerke | 200 | 8 |
| Jacobsen | 200 | 8 |
| Hansen | 200 | 8 |
| Aardal | 200 | 7 |

**Reflection.**  
Binary search needed only 7 or 8 comparisons with 200 contacts. This makes
sense because log2(200) is about 7.64. When binary search finds a duplicate, I
do not stop immediately. I save the index and continue searching to the left.
This gives the first occurrence. For example, Amundsen was returned at index 2
and the previous surname was Aas.

For the break-even point, I used Merge Sort on the supplied data. Sorting needed
1282 comparisons. A linear search needs 200 comparisons, while binary search
needs about 8. For q searches:

1282 + 8q < 200q

1282 < 192q

q > 6.68

This means that after about 7 searches, sorting once and then using binary search
becomes cheaper than doing repeated linear searches.

## 4. Insight

The most useful thing I learned from my results is that the input data matters a
lot when choosing an algorithm. Insertion Sort was very good when the data was
already sorted, with only 199 comparisons and no moves, but it became much more
expensive with reverse sorted data. Merge Sort was much more stable for the
different input shapes. I also saw that binary search is much faster than my
linear search, but the data has to be sorted first. So the faster search is most
useful when I am going to search the same data several times.

## AI use

I used AI for support with some difficult parts of the assignment.

1. How can Binary Search return the first/lowest index when there are duplicate values?
2. How should comparisons and moves be counted consistently for Insertion Sort and Merge Sort?
3. How can I calculate when sorting once and using Binary Search becomes cheaper than repeated Linear Search?