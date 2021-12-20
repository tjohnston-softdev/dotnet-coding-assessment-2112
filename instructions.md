# Technical Test

This test is to evaluate your coding skills and logical thinking with a small cognitive project.

Create a .NET Core command line application that calculates palindrome partitions. The application takes a single string as an argument and displays all possible palindrome partitions.

For example, "aab" would return:

* "a,a,b"
* "aa,b"

For another example, "geeks" would return:

* "g,e,e,k,s"
* "g,ee,k,s"

You can use online sources to help with this project. [Wikipedia](https://en.wikipedia.org/wiki/Palindrome) has a detailed explanation of what a palindrome is.

In your submission, please provide the following:

1. A Git repository with the full commit history.
2. Command line to parse strings and return results.
3. Unit tests with your preferred unit testing framework.
4. Mocking with your preferred mock framework.
5. A brief explanation as to why you choose a specific approach.

**Please return your solution by 13th December 2021**

---

# Implementation Details

* This solution takes the form of a command line application.
* Text input is entered as an argument when executing the `run` command. It is not possible to read text from an external file.
* Possible combinations are displayed to the console line-by-line.
* Output is not saved to an external file.
* The input text:
	* Cannot be longer than 100 characters.
	* Must only contain alphanumeric characters. (letters and numbers)
* Letters are case-sensitive, but the palindrome checking is not.
* A substring with only a single character, such as 'e', counts as a palindrome.
* Only the first 100 results will be displayed to the console. Further results are truncated.
* Unit tests were developed using the [NUnit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit) framework.
* I have not included dedicated mock-ups per se, but I have taken care to test the functions and underlying class schemas as thoroughly as possible.

---

# Algorithm

As per the assessment instructions, this is an explanation of the algorithm I developed to find palindrome partitions.

First, the input string is split by character to create the initial partition. This is because a single-character string still counts as a palindrome. This split will be used as the basis for further combinations as they are found. For example, `tacocat` is partitioned as `t,a,c,o,c,a,t`

I have created a dedicated [Partition](./net-solution/PalindromePartitions/Classes/Partition.cs) class. It is really just a wrapper for a `List<string>` object that stores the different substrings in that partition. I mainly did this for readability because a nested list object would be very confusing, but the *Partition* class does have functionality of its own. The class can return a set of substrings, join them together, and derive new objects by merging substrings together that form a palindrome. Results are stored as a `List<Partition>` object.

Now that we have our initial partition in the list, the main part of the algorithm can begin. *Partition* objects are iterated over as they are discovered. As existing partitions are visited, new ones can be derived by merging substrings into what becomes a palindrome.

The merge loop attempts to merge an increasing number of substrings across the given partition. At first, it merges two at a time, moving across the partition. When the end is reached, the loop starts again with a larger range.

The best way to explain this is with a pattern:

```
0-1
1-2
2-3
...
0-2
1-3
2-4
...
0-3
1-4
2-5
...
[etc]
```

When substrings are merged, it checks if the merged string is a palindrome. If it is, we can derive it into a new partition by removing those substrings and replacing it with the full string. For example:

```
Before: g,e,e,k,s
After: g,ee,k,s
```

Once all possible derivatives are made from the current partition, the main loop starts reading the next one. Partitions are visited in the order they are discovered so the loop will continue until no more partitions are made and the end of the collection is reached.

---
