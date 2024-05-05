# 🧪 Proof-of-Concept for a cloud-native application

## Manifesto

> "Nobody should start to undertake a large project. You start with a small _trivial_ project, and you should never expect it to get large. If you do, you'll just overdesign and generally think it is more important than it likely is at that stage. Or worse, you might be scared away by the sheer size of the work you envision. So start small, and think about the details. Don't think about some big picture and fancy design. If it doesn't solve some fairly immediate need, it's almost certainly over-designed. And don't expect people to jump in and help you. That's not how these things work. You need to get something half-way _useful_ first, and then others will say "hey, that _almost_ works for me", and they'll get involved in the project." — Linus Torvalds

## About

**Cloud-native** refers to an approach to building and running applications that fully exploit the advantages of the cloud computing delivery model. [Cloud-native is about how applications are created and deployed, not where](https://www.ibm.com/topics/cloud-native).

It involves:

- **Microservices**: Small, independent services that communicate over well-defined APIs.
- **Containers**: Lightweight, often used to run microservices, encapsulating the application and its dependencies.
- **Orchestration**: Automated management of containers, often using systems like Kubernetes.
- **DevOps**: Practices that combine software development (Dev) and IT operations (Ops) to shorten the development life cycle.
- **Continuous Integration/Continuous Deployment (CI/CD)**: Automated pipelines that test, build, and deploy code changes more frequently and reliably.

A cloud-native application is designed from the ground up to be elastic and resilient, taking full advantage of distributed computing provided by the cloud. [It's composed of microservices that can be independently deployed and scaled, allowing for faster iterations and better fault isolation](https://cloud.google.com/learn/what-is-cloud-native). [This approach enables organizations to respond quickly to customer demands and market trends](https://aws.amazon.com/what-is/cloud-native/).

### Back-end

- A [Minimal API](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0), made with [ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-8.0?view=aspnetcore-8.0), targeting [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8), inspired by the official [Tutorial: Create a minimal web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio-code).

### Front-end

- TBD

## Credits

- The solution has been coded using [Visual Studio Code](https://code.visualstudio.com/).
- AI assistance provided by [Gemini](https://gemini.google.com/) and [Copilot](https://copilot.microsoft.com/).

## Terms

All trademarks, registered trademarks, service marks, product names, company names, or logos mentioned on this repository are the property of their respective owners. All usage of such terms herein is for identification purposes only and constitutes neither an endorsement nor a recommendation of those items. Furthermore, the use of such terms is intended to be for educational and informational purposes only.
