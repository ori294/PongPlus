# Pong +++++++

## Prerequisites

1. [Install git](https://git-scm.com/download/) on your machine
2. [Sign up](http://www.github.com) to github

## Install

1. Clone the project on your machine:

    ```bash
    git clone https://github.com/asafam/PongPlus.git
    ```

2. Check the status of your project - you may be asked to provide credentials.

    ```bash
    git status
    ```

## Develop

1. Start with pulling the most recent updates to your local project. Do it everytime someone says he upload new changes:

    ```bash
    git pull origin master
    ```

2. Git works with a main branch called `master` and many sub branches which you can open. So, before you start making changes - create a local branch on your machine:

    ```bash
    git checkout -b <branch_name>
    ```

3. Check you are in working on your current branch and **not on `master`**. This command should print on which branch are you working in (make sure it is the *branch_name* you set). This command will also display which changes you've set.

    ```bash
    git status
    ```

4. When you feel ready, commit your changes to your local branch run:

    ```bash
    git checkout . ; git commit -m "add a short description for what you've done"
    ```

5. Now that you finished commiting your changes on your **local** branch, upload your branch with the changes to github.

    ```bash
    git push origin <branch_name>
    ```

6. Go to the project's [_branches_](https://github.com/asafam/PongPlus/branches) tab on github, and click _New pull request_. If you feel ready to add your changes to the project, click _Merge_

7. We're almost done, after you :

    ```bash
    git push origin <branch_name>
    ```
