# .NET Coding Assessment (December 2021)

This is my submission for a technical assessment as part of a software developer position that I applied for during December 2021. The challenge was to create a .NET Core application that inputs a string and displays all of the possible 'palindrome partitions'. That is, all of the possible combinations of palindrome substrings.

The assessment instructions were sent as an E-Mail which I interpreted into a [markdown file](./instructions.md) for public viewing. I also included specific implementation details and a description of how I approached the task.

---

## Timeline

* **Friday 3rd:** The assessment E-Mail was sent.

* **Monday 6th:** To start things off, I did a mock-up of the algorithm in Node JS. My local development environment is geared more towards Node JS so I used that as a sandbox instead of rushing straight into .NET Core. I have included this mock-up in this repository so you are welcome to look at it but keep in mind that it isn't meant to be serious.

* **Tuesday 7th:** Now that I was familiar with the algorithm, I was able to do an implementation in .NET Core. I did this from scratch rather than referring to the Node JS mock-up but at least I took the time to prepare beforehand.

* **Thursday 9th:** I wrote most of the unit tests on that day. To me, writing unit tests for software is a separate project in itself.

* **Friday 10th:** This day was for final polish. I completed the rest of the unit tests, double-checked all of the code, wrote the documentation, and made my final submission.

* **Monday 13th:** The assessment was due to be submitted by this date.

* **Monday 20th:** Submission was publicly released to GitHub.

---

## Running

To run the script, navigate to the `./net-solution/PalindromePartitions` folder and execute `dotnet run <input-text>`

For the unit tests, I chose to use [NUnit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit). To run them, navigate to the `./net-solution` folder and execute `dotnet test`

I only included the Node JS mock-up for archive purposes and it is not meant to be serious. If you're that curious about it, navigate to `./mockup` and run `node index <input-text>`

---

## Disclaimer

This submission is licensed under CC-BY 4.0. You can do whatever you want with it as long as attribution is given. The hiring manager has allowed me to publicly share my submission provided that I do not disclose the name of the company.
