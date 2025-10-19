# 🎯 Design Patterns in C# with .NET 10 — A Practical Series

Welcome to the **Design Patterns in C# with .NET 10** series!  
This repository brings **progressive, real-world examples** of the most important design patterns — each demonstrated with clean, modern C# code using **.NET 10**, **Minimal APIs**, and **best practices**.

The goal of this series is to help developers **understand not just “how” to use a pattern, but “when” and “why”** — with emphasis on clarity, maintainability, and testability.

---

## 🧩 Index of Patterns
Each pattern will have:
- A detailed article (concept + use cases)
- A runnable `.NET 10` sample project under `/src/<pattern-name>`
- Optional unit tests and diagrams under `/tests` and `/docs`

| # | Pattern | Category | Status |
|---|----------|-----------|--------|
| 1 | [Singleton](#1-singleton-pattern) | Creational | ✅ Completed |
| 2 | Factory Method | Creational | 🔜 Coming soon |
| 3 | Abstract Factory | Creational | 🔜 Coming soon |
| … | *(More patterns will be added progressively)* | | |

---

## 1️⃣ Singleton Pattern

### 📖 Overview
The **Singleton** pattern ensures a class has only one instance and provides a global access point to it.  
It’s particularly useful for objects that must be **shared across the entire application** (such as configuration providers, logging services, or caching layers).

In this example, we build a **Minimal API (.NET 10)** that demonstrates:
- Loading configuration data **once** from a JSON file;
- Guaranteeing **thread-safe** initialization;
- Verifying that **all API requests** share the **same instance**.

---

### 🏗️ Implementation

#### Project structure
DesignPatterns.SingletonDemo/
├── Program.cs
├── AppSecretsSingleton.cs
├── appsettings.secrets.json