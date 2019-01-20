2018-19 Class Project Inception: Discussion Hub
=====================================

## Vision Statement

For informed users who need more information on a topic from multiple view points, the Rialo site is a central discussion site for users so that they can civilly discuss any topic and pose questions related to those topics. This site will provide a forum for users to discuss topics from other sites that do not host discussion forums such as CNN. Unlike the news sites that host these articles, users can have discussion and debate about these topics from multiple news sources. Our product will allow users to view articles from multiple sites to allow users to get the full story and perspective on a particular topic.

## Summary of Our Approach to Software Development

Our approach to software development involves the Disciplined Agile Delivery method intermixed with key elements of other approaches. Namely SCRUM. We generally use the MVC 5 software architecture and outside database support. We believe in the quality of work produced by a small team of collaborating, respectful, and singly located development professionals.

## Initial Vision Discussion with Stakeholders

People like to talk; people like to discuss and argue.  People like to state their opinions and read thoughts of others.  But there are real problems with how it is happening on the Web.  Just take a look at YouTube or Twitter comments.  That's not a discussion and it's not often useful, productive or even civil.  Social media is not the place to talk about things.  The Internet should be a place where people can *communicate*.  Let's make a site where people can do that!

Places like Reddit and Kialo already have a handle on general topic discussions, so we won't try to do that.  Enthusiasts often have their own sites with discussion and comment sections (e.g. Slashdot) and have formed close-knit communities that work well.  We don't want to do that either.  Here's our idea, using an example:

Let's say I just read this article on CNN, [American endurance athlete becomes the first person to cross Antarctica solo](https://www.cnn.com/2018/12/27/world/colin-obrady-antarctica-solo-trip-trnd/index.html), about a guy from Oregon who skied *across* Antarctica.  The thing is, is that he didn't and he wasn't the first.  His claims should be challenged and the article/journalist is disingenuous by not at least bringing this up.  People reading this article should know there are serious questions about it.  Someone should comment on this to point it out and spark further discussion.   There is no way to do this.  CNN does not have a comment section.  Even if it did, do I want to create an account there just so I can make a quick comment?  I'd have to do that everywhere on the web where I had a question or wanted to comment.  How would I know if my question was answered?  

We want a centralized discussion site that can be found easily and where an individual can maintain an account, build a history, expertise, level of trust, etc.  It should make it easy to create or find a discussion page about any news article, post or web site.  It should provide features for the user to follow their discussions without ever going back to the original website.  It should allow them to create and maintain their own identity that is separate from any social media identity.

## Initial Requirements Elaboration and Elicitation

### Questions

1. How do we link a discussion on the site to one or more articles/pages?

    We were thinking via URL.

2. How will users find out that there is a discussion on the site for the article/page they're currently viewing?
   
    How about a browser plug-in?  It could send the URL of the current page to our API to see if a discussion page exists and provide an easy way for them to navigate to our page.

    Or the user can copy the URL and paste it into a search bar on our site.

3. Clearly we need accounts and logins.  Our own, or do we allow logging in via 3rd party, i.e. "Log in with Google" or ...?  

    Login via 3rd party, requires support for Google, Yahoo, Facebook,... etc.
4. Do we allow people to comment anonymously?  Read anonymously? 
    We will require signin to comment but the site can be visited and viewed without login.
5. Do we allow people to sign up with a pseudonym or will we demand/enforce real names?
    Pseudonym is fine because it will be whatever the 3rd party has it as.
6. What is it important to know about our users?  What data should we collect? Should we collect data?
    Viewstatistics, age, ethnic, ip address, location, company. Important info is age for content selection, nationality for language selection, and location for targeted adds.
7. If there are news articles on multiple sites that are about the same topic should we have separate discussion pages or just one?
    One discussion page.
8. What kind of discussion do we want to create? Linear traditional, chronological, ranked, or ?
    Ranked discussion with the option to view chronologically.
9. Should we allow image/video uploads and host them ourselves?
    Not initially. Look in to adding it as a later feature.
10. Will there be a text limit on each post? If so, how large will it be?
    The initial post will be limited to 5000 characters, response posts will be limited to 1000 characters.
11. How are we generating revenue?
    Rent ad space. Premium accounts. Account currency.
12. How will the website be moderated?
    Series of user moderators, corporate moderators, and a moderating algorithm.
13. Can posts be edited or deleted? If so, by whom?
    Posts can be edited and deleted by the original poster. The post will still be visible it will just say deleted. All posts may be deleted by moderators and the post will say deleted by moderator.
### Interviews
    DQ. How much traffic are you expecting on the site?
    SA. The range of 2 - 4 million users daily.
    SQ. Is that a reasonable expectation for traffic?
    DA. You are unlikly to get that much traffic right off but we can architecture for that amount of traffic. This kind will require high end servers.
    SQ. How can we increase traffic?
    DA. We can utilize ads on different websites to increase traffic on ours.
    SQ. Aren't ads bad?
    DA. Yes. But you need to make an initial investment in the website to create traffic.
    SR. Hmmm. Okay. I guess I get it now.

    DQ. What kind of interface are you looking for?
    SA. Looking for user friendly, easy to use. With professional and formal looking design.
    DQ. Do you want a specific color scheme that you're looking for?
    SA. Easy on the eyes no flashy colors no bright colors.
    DQ. How do you want the other pages linked?
    SA. Navigation bar at the top and the footer where you can select what page to go to. When you are on the bottom there should be a button that takes you to the top of the page next to the scroll bar.

    DQ. Is there a desire or a plan for a mobile site?
    SA. Yes.
    
## List of Needs and Features

1. A great looking landing page with info to tell the user what our site is all about and how to use it.  Include a link to and a page with more info.  Needs a page describing our company and our philosophy.
2. The ability to create a new discussion page about a given article/URL.  This discussion page needs to allow users to write comments.
3. The ability to find a discussion page.
4. User accounts
5. A user needs to be able to keep track of things they've commented on and easily go back to those discussion pages.  If someone rates or responds to their comment we need to alert them.
6. Allow users to identify fundamental questions and potential answers about the topic under discussion.  Users can then vote on answers.
7. Premium accounts remove all rented ad space and doubles character limits. Allow users to see their view history, allow animated icons, and a special premium icon.
8. Moderator capabilities.
9. Posts made by users need to be able to be deleted.
10. Users need to be able to change the language used on the website.
## Initial Modeling

### Use Case Diagrams

### Other Modeling

## Identify Non-Functional Requirements

1. User accounts and data must be stored indefinitely.
2. Site and data must be backed up regularly and have failover redundancy that will allow the site to remain functional in the event of loss of primary web server or primary database.  We can live with 1 minute of complete downtime per event and up to 1 hour of read-only functionality before full capacity is restored.
3. Site should never return debug error pages.  Web server must never return 404's.  All server errors must be logged.  Users should receive a custom error page in that case telling them what to do.
4. Must work in all languages and countries.  English will be the default language but users can comment in their own language and we may translate it.
5. We must have a way of preventing bots from accessing and registering on the site.

## Identify Functional Requirements (User Stories)

E: Epic  
F: Feature  
U: User Story  
T: Task  

1. [U] As a visitor to the site I would like to see a fantastic and modern homepage that tells me how to use the site so I can decide if I want to use this service in the future.
   1. [T] Create starter ASP dot NET MVC 5 Web Application with Individual User Accounts and no unit test project
   2. [T] Switch it over to Bootstrap 4
   3. [T] Create nice homepage: write content, customize navbar
   4. [T] Create SQL Server database on Azure and configure web app to use it. Hide credentials.
2. [U] Fully enable Individual User Accounts
   1. [T] Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP script
   2. [T] Configure web app to use our db with Identity tables in it
   3. [T] Create a user table and customize user pages to display additional data
3. [F] Allow logged in user to create new discussion page
    1. [U] As a logged in user, I want to create a discussion page so that I can have a conversation about it with other users.
4. [F] Allow any user to search for and find an existing discussion page
5. [E] Allow a logged in user to write a comment on an article in an existing discussion page
   1. [F] Display a list of current discussion topics in most recent order.
        1. [U] As a logged in user, I want to be able to view the current list of topics.
            1. [T] Query database to display topics.
            2. [T] Create sorting capability for topics.
        2. [U] As a logged out user, I want to view the current list of topics.
            1. [T] Query database to display topics.
            2. [T] Check logged in status. Remove sorting feature if logged out.
   2. [F] Display selected topic and current comments.
        1. [U] As a visitor to the site, I want to browse the comments on a topic I select. 
6. [E] Allow users to view their comment history and alert them when one of their comments or discussions has been commented on or rated.
    1. [F] Have a history page that displays a given users comment history.
        1. [U] As a logged in user, I want to visit my history page that displays all comments and discussions I have started in chronological order.
    2. [F] The history page can be viewed in chronological, most popular, or least popular comments order.
        1. [U] As a logged in user, I want to sort my history page by chronological order.
        2. [U] As a logged in user, I want to sort my history page by most popular comments or discussions.
        3. [U] As a logged in user, I want to sort my history page by least popular comments or discussions.
    3. [F] Have an alert system that messages the user when their comments and discussions have been commented on.
        1. [U] As a logged in user, I want to see a notification when someone comments on my discussions or comments.
        2. [U] As a logged out user, I want to receive an email when someone comments on my discussions or comments.
    4. [F] Have an alert system that messages the user when their comments and discussions have been rated.
        1. [U] As a logged in user, I want to see a notification when someone rates my comment or discussion.
        2. [U] As a logged out user, I want to receive an email when someone rates my comment or discussion.
7. [U] As a robot I would like to be prevented from creating an account on your website so I don't ask millions of my friends to join your website and add comments about male enhancement drugs.
## Initial Architecture Envisioning

## Agile Data Modeling

## Timeline and Release Plan