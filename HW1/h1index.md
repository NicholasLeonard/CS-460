# Nicholas Leonard


## Homework 1

I have never used any of these programs before, so this whole project was a new experience for me. It was a great experience of learning new tools and experimenting to cement the process in my head.


### Step 1. Setting up git and making a github account and repository.

The first thing I had to do was actually download git from the provided link in the homework page. Once I had downloaded and installed git and created the remote repository on github, I had to clone the repository onto my local machine.

```bash
git clone https://github.com/NicholasLeonard/NicholasLeonard.github.io.git
```
After I made the clone, I had to run two git config commands to properly set my git username and email to match with my github profile.

```bash
git config --global user.name "Nicholas Leonard"
git config --global user.email nleonard17@wou.edu
```

After that, I did an initial commit with the first page of my website.

```bash
git add wk1Website.html

commit 5a36acf9ae9cf36f35dbe4e9cdb4ddbc4c1d63cd
Author: Nicholas Leonard <nleonard17@wou.edu>
Date:   Tue Sep 25 12:32:34 2018 -0700

    First stages of html page for website 1
```


### Step 2. Coding a Multipage Website using HTML, CSS, and Bootstrap.


For this assignment, we had to have multiple pages as well as use two different kinds of lists, a table, and show the use of single column and multicolumn layouts. I decided to have a single column for my home page where I detailed what the website was about and then use multiple columns in later pages.

```html
<div class="container pushdown">
        <h1>My First Experience</h1>
        <div class="row">
            <div class="col">
                <p> Welcome to my first ever webpage! It has been a long time coming but 
                    here it finally is. As is fitting, this webpage will hold some of my 
                    first ever stuff. Have fun clicking through and learning a little about
                    me.</p>
            </div>
        </div>
    </div>
```
I wanted the text to appear in a box on top of the regular background so I put it into a container to allow for more specific custimization options. We also had to use bootstrap 4 for formatting but were not aloud any absolute links. Thus, I downloaded the bootstrap 4 zip from the link provided in the homework and put the files in my local repository.

![picture](../Portfolio_Photos/bootstrapfiles.png)


To get Bootstrap to work with my pages, I also had to include the necessary links in the head element of my HTML document. I also had to use a CSS file, which I also linked in the head of the document.

```html
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>First Official Webpage</title>
    <!--Necessary BootStrap 4 links-->
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--My CSS code link-->
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script src="main.js"></script>
</head>
```

One of the assignment requirements was for us to include some form of link navigation so that we could access all the pages for our website. I decided that an active tab system would be an appropriate choice and it also gave me an opportunity to use a list to meet one of the other requirements. Therefore, I included the HTML coding for a navbar and navigation functionality.

```html
<nav class="navbar">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="wk1Website.html">Home</a>
            </li>

            <li class="nav-item">
                <a class="nav-link" href="wk1Websitepg1.html">Pictures</a>
            </li>

            <li class="nav-item">
                <a class="nav-link" href="wk1Websitepg2.html">About</a>
            </li>
        </ul>
    </nav>
```