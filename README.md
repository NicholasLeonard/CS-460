# Toaster Code

## Motto

Delivering crisp slices of code

## Team Description

This is the repository for the Toaster Code development team. This repository houses all of our code for our Senior project as well as documents and files for each milestone we achieve

## Power Level Vision Statement

For people who want to get in shape or work out, the RPG-lite workout is a workout planning platform that integrates RPG elements into a workout plan. The web-app gives the user a workout plan customized and curated by them while providing a gamified interface and spin to all fitness activities that resembles a role playing game. Unlike other gamified applications, our product will both focus only on a fitness experience and provide the user with state recommend workouts in a fun, social format.

## Power Level Description

With this project, we aim to provide an RPG element to user's normal workout routine, which can help get their minds off of the workouts they are doing. We believe that working out is not fun for some individuals and we hope to change that. We hope to provide various workouts through dungeons that will earn you gear and experience for your character. Combined with proper workout tutorials for those unfamiliar with regular workout schedules and the ability to integrated your pre-existing fit-bit data, we hope to provide a fun and goal driven way to maintain your body while still meeting safety and national standards.

## Current State

Five Sprints in. Basic working fashion.

## How to access

This is not something you have to build it is a website hosted on Microsoft Azure. Just follow the URL below and you are on your way to sleighing monsters and getting into shape.

https://powerlevel.azurewebsites.net

If the site is no longer deployed, follow [this](https://bitbucket.org/Hexamoy/toastercode/src/master/) link to download the source files and run it locally.

#### Setup

1. Download site to a local repository.

2. Make sure there is a packages folder in every directory that contains a `.sln` file and place it at the same level as the file.

3. Open the `.sln` file in visual studios and build the project. When prompted to restore missing nuget packages, make sure to do so.

4. Right click on the App_Data folder and click add new item. Select SQL Server Database and name it `toaster.mdf`. This should make a `.mdf` file, which works as a local database.

5. Double click on the new database file so that the project recognizes it and opens the server explorer window.

6. While still in the App_Data folder, open the subfolder labeled Up and double click on the `UP.sql` to open the file.

7. Once the `UP.sql` file is open, click on the connect button near the top of the editor beneath the file tabs and three over to the left of the little search box. Once the connect window opens, select local, MSSQLLocalDB (if this option doesn't appear, you need to install database workload for visual studio). In the botom tab where it says `<default>`, select the path to the local `.mdf` file you created. Then hit connect.

8. Once the `UP.sql` file is connected to your local database, click on the execute button (green, right facing triangle) to populate your database.

9. Outside of your repository, create a file called `Web.SECRETS.config` and add the following to the file. (you'll have to get the values from us)

```csharp
<appSettings>
    <add key="FitbitClientId" value="" />
    <add key="FitbitClientSecret" value="" />
    <add key="mailAccount" value="" />
    <add key="mailPassword" value="" />
</appSettings>
```

Once the database file has been populated with Powerlevel's data and the secrets file has been created, you are ready to run the website. Hit `ctrl + F5` to build and run the website.

## Designers and Inceptors

This project was conceived and built by the current members of Western Oregon University Senior Team Toaster Code. Those members are:

* Alex Bishop
* Chi Li
* Jace Woods
* Nicholas Leonard

## Team Rules and Guidelines

1. All problems will be brought up to those involved. No beating around the bush and no behind the back talk. We want to be productive here and we want to be friends. It is best just to get it in the open.

2. COMMENT YOUR CODE!!!! Please comment your code. It matters so very much to Alex and we don't want to hurt him.
    General Commenting Rules:
		    -Standard Code Blocks at the start of all major functions  [see](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments)

3. Please follow the processes and guidelines listed on the processes and guidelines page for contributing code and understanding our formatting and coding standards. It is very important that we are consistent.

4. Always finish your code on time to the best of your ability. We understand that life happens and you can't always meet your deadlines, but the point is to finish what you start. Do your absolute best.

## Team Song

It is important for every team to have a song and an anthem. [Here](https://www.youtube.com/watch?v=helzmv4sPH8) is ours.

## Contributing

For those who are contributing code. Please follow the guidelines listed in the guideline page. Follow the link below.
[Processes and Guidelines](Milestone_5/processes_and_guidelines.md)

## Node.js Presentation

[Node.js](https://docs.google.com/presentation/d/1w6v8UUcAvWzoZQ_TJcF2Jstvfe7mZQhQqySSDWPtLGE/edit#slide=id.gcb9a0b074_1_0)