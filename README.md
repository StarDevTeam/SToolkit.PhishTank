# SToolkit.PhishTank
[![NuGet version](https://badge.fury.io/nu/SToolkit.PhishTank.svg)](https://badge.fury.io/nu/SToolkit.PhishTank)
[![GitHub version](https://badge.fury.io/gh/stdevsu%2FSToolkit.PhishTank.svg)](https://badge.fury.io/gh/stdevsu%2FSToolkit.PhishTank)

## What is PhishTank?
PhishTank is a collaborative clearing house for data and information about phishing on the Internet. Also, PhishTank provides an open API for developers and researchers to integrate anti-phishing data into their applications at no charge.

## Why PhishTank?
* Free Unlimited API. You only need get application key, it takes near 1 minutes.
* Every day ~1500 new phish sites. [More stats here](https://www.phishtank.com/stats.php).

## How to get api key?
* Register and get it [here](https://www.phishtank.com/api_register.php).

## Supported platforms:
* .Net Framework 3.5+.
* .Net Core 1.0+.
* Mono.

## Installation
Via Nuget.
```
Install-Package SToolkit.PhishTank
```

## Usage
Including.
```
using SToolkit.PhishTank;
```

Check site.
```
PhishTankApi api = new PhishTankApi("API_KEY_HERE");
var res = api.Check("http://yandex.ru");
Console.WriteLine($"Url: {res.Url}");
Console.WriteLine($"InDatabase: {res.InDatabase}");
Console.WriteLine($"IsPhish: {res.IsPhish}");
Console.WriteLine($"PhishID: {res.PhishID}");
Console.WriteLine($"PhishPage: {res.PhishPage}");
Console.WriteLine($"Verified: {res.Verified}");
Console.WriteLine($"VerifiedDate: {res.VerifiedDate}");
```

Also for .Net Framework 4.0+ and .Net Core have async method.
```
PhishTankApi api = new PhishTankApi("API_KEY_HERE");
var res = api.CheckAsync("http://yandex.ru");
```

And you can set proxy for requests, its default .net [WebProxy](https://docs.microsoft.com/en-us/dotnet/api/system.net.webproxy) class.
```
PhishTankApi api = new PhishTankApi("API_KEY_HERE");
api.Proxy = new WebProxy("ip:port");
```

# Version history.
* [22.12.2018] (1.0) First public release.
