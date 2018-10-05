# Nicholas Leonard
<br/>
## Homework 2

Once again, I have never used javaScript or jQuery before but I found the process fun and fairly straight forward. For this assignment, I had to make another webpage and then use javascript and jquery to modify it in some way. Therefore, I decided to do a letter counter that would take an input string from the user and then return a jquery generated table with the total counts of each letter used. I had a lot of fun doing it and it turned out pretty well. I also had to use a seperate branch in git to do this "feature" and then merge it back into the main branch when we were finished. That was cool because I got some experience with branching and actual work flow control.

### Important Links
Here is the link to my github repository that holds all the source code for this assignment.<br/>
[Github Repository](https://github.com/NicholasLeonard/NicholasLeonard.github.io)

This is the link to the page that I made for this assignment. Please, give it a try.<br/>
[Letter Counter](index.html)

This link will take you back to my home Portfolio page.<br/>
[Home](../index.md)

<br/>
### Step 1. Creating a new feature branch in git for Hwk2.

The first thing I had to do was create a new branch to work on so I could git (hehe) some experience with branching and to keep this work from contaminating everything I had done before. So using the git branching command, I created a new branch and checked it out so that I could work on that branch instead of the master branch.
```bash
git branch hw2

git checkout hw2
```

<br/>
### Step 2-3. Planning and Design

After I created the new working branch and checked it out, I had to decide what it was I wanted to do and if I was going to add it to my original website. I decided not to add it to the website I made for assignment 1 because I wanted to keep each assignment isolated so that they could be shown individually. I did, however, decide to use most of the stylings in my CSS file from the original website.

Once I decided that I was not going to add it to the first website, I had to decide what I was going to do. The requirement was that it had to read input from the user in some way and then display something. I had to do this by using javascript and jquery to modify existing elements and add new elements to the page. I decided to create a simple tallier that would read in an input string from the user and then generate a table that showed the total number of each letter that was used in the string.

I also had to consider how I wanted to design the site. I decided to just have one main container with the input area in a form and the table appearing in a <code><div></code> element beneath the form.

![picture](../Portfolio_Photos/blog2_0.jpg)