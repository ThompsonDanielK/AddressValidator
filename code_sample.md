Thank you for considering a software engineering position at Empora. This problem was designed to be not too big, and not too small, but hopefully "just right". We understand that our candidates have busy schedules, so there is no due date. As you complete the code sample, please do not hesitate to contact us if you have any questions.

# Overview

### Delivery

Please send us a compressed file through a file-sharing site (Google Drive, iCloud, Dropbox, etc.) or through a public github repository.

### Documentation

As a part of your code sample, include a README that describes:
* How to run your code.
* How to run your tests.
* The thought process behind your decisions.
### Problem Description

Create a command-line program that validates a US address against the following API and outputs either the corrected address or `Invalid Address`

https://www.address-validator.net/free-trial-registration.html

1. The tool must run in a console window/terminal.
2. The input should be piped in or read from a file: e.g. `cat file.csv | node program.js` or `ruby program.rb file.csv`
3. The input format is CSV with the following fields: `Street Address`, `City`, and `Postal Code`
4. The output should include the original address and the corrected address joined with `, ` and seperated by a ` -> ` (see below).
5. The free trial of the API only allows for 100 address checks. You are not permitted to pay for additional checks. A testing suite can quickly exhaust all 100 checks, but there are several testing strategies that can help mitigate this issue - one potential strategy is [stub or mock](https://martinfowler.com/articles/mocksArentStubs.html).

### Example IO

Given a file with the following contents:

```
Street Address, City, Postal Code
123 e Maine Street, Columbus, 43215
1 Empora St, Title, 11111
```

Your output should be:

```
123 e Maine Street, Columbus, 43215 -> 123 E Main St, Columbus, 43215-5207
1 Empora St, Title, 11111 -> Invalid Address
```

# Considerations

### Programming Language

You are welcome to use any programming language.  We are not interested in your familiarity with the idioms of any specific language, but rather your familiarity with the idioms of the language with which you are most comfortable.

### Size

This problem could be solved via a script written in a single file, but that would not give us much insight into your abilities as a software engineer. We are looking for code that demonstates good design and modeling, so make this submission larger than strictly necessary.

### API Keys

When evaluating your work sample, we will use our own API key. Your solution should allow us to easily switch out your API key for our own API key.

### Evaluation

When evaluating your code sample, we will consider the following:
1. How well the code is organized (e.g. low coupling of logically different components)
2. How well the code is tested.
3. How easy it would be to build additional functionality on top of the code.
4. Whether or not the code is easy to read and well-explained.
