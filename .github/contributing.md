# Contributors Guide.

:star: Thanks for taking the time to contribute :star: 

This document outlines the different ways you can contribute to this repository Everything is open to improvement and all of these are guidelines. If you can think of something that can be changed or that is missing from this doc - you can even open a pull request for making that kind of change.

[Code of Conduct](CODE_OF_CONDUCT.md)

[How Can I Contribute?](#how-can-i-contribute)
  * [Reporting Bugs](#reporting-bugs)
  * [Suggesting Enhancements](#suggesting-enhancements)
  * [Labels For Issues](#labels-for-issues)
  * [Pull Requests](#pull-requests)
  * [Your First Code Contribution](#your-first-code-contribution)
  * [Git Commit Messages](#git-commit-messages)

[Licencing](#licencing)


## How Can I Contribute?

### Reporting Bugs

When issuing a bug report please include as many of details on [the bug report template](bug_report.md) as possible. If you find a Closed issue that seems like it is the same thing that you're experiencing, open a new issue and include a link to the original issue in the body of your new one. Please label the any bug report issues with `bug`.

### Suggesting Enhancements

Enhancements may include completely new features and minor improvements to existing functionality. Following these guidelines helps maintainers and the community understand your suggestion and find related suggestions.

First of all please do a search on the issues already present to see if it's an enhancement that hasn't previously been suggested. If it has, maybe join the discussion on the pre-existing issue. This is to help reduce duplication of issues. If it hasn't been raised previously, please include as many details as you can using [the feature request template](./ISSUE_TEMPLATE/feature_request.md). Label the raised feature request as `enhancement`

### Labels For Issues

| Label | Purpose |
| --- |--- |
| up-for-grabs | An issue that is ready and has enough information to be picked up |
| docs | An issue that only relates to writing docs |
| easy | Difficulty level: any level of experience can pick this issue up |
| medium | Difficulty level: some experience of the domain or language will be needed to pick this issue up |
| hard |Difficulty level: a lot of experience of the domain or language will be needed to pick this issue up |
| insane | Difficulty level: you need to be a total wizard to figure this out |
| enhancement | Making things better but without fixing an issue |
| fix | Fixing a pre-existing problem with the code |


### Pull Requests

- Create branch. Give the branch a descriptive name relating to what the work covers.

| PR-prefix | Purpose | Example |
| --- |---| ---|
| enhancement | Making things _better_ but without fixing an issue | enhancement/improve-performance-of-query |
| fix | Fixing a pre-existing problem with the code that isn't an issue | fix/accept-nulls-for-input |

- Open a Pull Request with the details listed in the [pull request template](pull_request_template.md). The sections of this template should show in the body of any new pull request automatically. 

- Make a comment with the pull request in any issues it relates to. (i.e. "Resolves issue #5" )

### Your First Code Contribution?

Efforts will be made to label issues with difficulty level (from `easy` to `insane`) and `up-for-grabs` if they are ready to be picked up by contributors. This is in order to help those who want to contribute but don't necessarily have much experience in doing so.

### Git Commit Messages

Where possible please stick to the following format for your commit messages.

- Use the present tense ("Add feature" not "Added feature")
- Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
- Limit the first line to 72 characters or less
- After the first line, be descriptive about what has been done in the commit.

For reference, [this blog](https://chris.beams.io/posts/git-commit/) encourages a similar style.

## Licencing

If it's something cool, new and funky that you are contributing, please ensure it's covered with an MIT licence.
