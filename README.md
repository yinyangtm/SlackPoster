# SlackPoster

[![SlackPoster](https://img.shields.io/nuget/v/SlackPoster)](https://www.nuget.org/packages/SlackPoster/)


Post a message to Slack easily.

Slackへメッセージを投稿します。

---

## Getting started

Install SlackPoster nuget package.

NuGet パッケージ マネージャーからインストールしてください。

- [SlackPoster](https://www.nuget.org/packages/SlackPoster/)

> ```powershell
> Install-Package SlackPoster
> ```

---

## Basic Usage

```c#
// Init
var sp = new SlackPost("WEB HOOK URL");

// Post Message
sp.PostMessage("hello world.")

```


