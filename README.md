[![](https://img.shields.io/nuget/v/soenneker.ipqs.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ipqs.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ipqs.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.ipqs.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.ipqs.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ipqs.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ipqs.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.ipqs.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Ipqs.Client

Reuse a bare HTTP transport for IPQualityScore operation packages such as `Soenneker.Ipqs.Phone`.

## Install

```bash
dotnet add package Soenneker.Ipqs.Client
```

## Register

```csharp
using Soenneker.Ipqs.Client.Registrars;

services.AddIpqsClientUtilAsSingleton();
```

Use `AddIpqsClientUtilAsScoped()` only when each scope should own its transport. Provider instances use isolated cache keys, so disposing one scope removes only its own client.

## Usage

```csharp
using Soenneker.Ipqs.Client.Abstract;

HttpClient client = await ipqsClient.Get(cancellationToken);
```

The returned client intentionally has no base address, authentication header, or IPQS endpoint selected. Higher-level packages construct the complete request URL, including the API key and operation path. Prefer one of those operation packages unless you need to build IPQS requests yourself.

Repeated `Get()` calls on the same provider reuse its client. The provider owns that transport; let the service container dispose the provider rather than disposing the returned instance directly.
