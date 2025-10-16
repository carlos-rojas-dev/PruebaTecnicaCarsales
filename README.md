# 🧪 Rick and Morty App — Angular + .NET Core (C#)

Este proyecto reúne dos repositorios complementarios:

1. **Frontend:** Aplicación desarrollada en **Angular**, encargada de la interfaz de usuario y la visualización de datos.
2. **Backend:** API desarrollada en **.NET Core C#**, responsable del consumo de la [API pública de Rick and Morty](https://rickandmortyapi.com/documentation/#rest) y de la exposición de endpoints internos para el cliente Angular.

---

## 🧩 Objetivo

El propósito de este proyecto es **demostrar una arquitectura escalable y mantenible**, basada en los **principios SOLID**, que integre comunicación entre Angular y .NET Core para consumir información de personajes, episodios universo de *Rick and Morty*.

---

## ⚙️ Arquitectura General

┌───────────────────────────┐
│         Angular           │
│   (Frontend - UI Layer)   │
│   - Components / Pages     │
│   - Services (HTTPClient)  │
│   - Routing / Guards       │
└──────────────┬────────────┘
               │
     HTTP / JSON (REST API)
               │
┌──────────────┴────────────┐
│        .NET Core API       │
│ (Backend - Application/API)│
│                            │
│   - Controllers             │
│   - Services (Domain Layer) │
│   - Clients (Rick&Morty API)│
│   - Repositories / Models   │
│   - Dependency Injection     │
└──────────────┬────────────┘
               │
     Rick & Morty Public API

---

## 🧱 Estructura de Repositorios

### 🔹 **Frontend (Angular)**

**Repositorio:** `rickandmorty-angular-client`

**Principales características:**
- Uso de `HttpClient` para el consumo del backend.
- Implementación de servicios desacoplados bajo principios **SRP (Single Responsibility)**.
- Componentes reutilizables para listar personajes, episodios y ubicaciones.
- Manejo de estados y rutas modulares.

---

### 🔹 **Backend (C# .NET Core)**

**Repositorio:** `rickandmorty-dotnet-api`

**Patrón de diseño aplicado:**  
✅ **SOLID Principles**
- **S (Single Responsibility):** Cada clase tiene una única responsabilidad (por ejemplo, `RickAndMortyClient` solo maneja la comunicación HTTP).  
- **O (Open/Closed):** Las clases son extensibles sin ser modificadas (inyección de dependencias y abstracciones).  
- **L (Liskov Substitution):** Los servicios implementan interfaces genéricas.  
- **I (Interface Segregation):** Interfaces pequeñas y específicas para cada tipo de entidad (Personajes, Episodios, Locaciones).  
- **D (Dependency Inversion):** Uso intensivo de inyección de dependencias (`IServiceCollection`).

---

## 🧠 Ejemplo de Flujo de Datos

1. El **frontend Angular** realiza una solicitud a `/api/{id}/episodes`.
2. El **backend .NET Core** recibe la solicitud en `EpisodesController`.
3. El controlador invoca un **servicio de aplicación** (`EpisodeService`).
4. El servicio utiliza un **cliente HTTP especializado** (`RickAndMortyClient`) para consumir la API pública.
5. Los datos se mapean a **DTOs** internos y se devuelven al cliente Angular.
6. Angular muestra los personajes y detalles del episodio en la interfaz.

---

## 🚀 Configuración del Proyecto

### 🔧 Backend (.NET Core)
```bash
# Clonar repositorio
git clone https://github.com/carlos-rojas-dev/PruebaTecnicaCarsales.git
cd API 

# Restaurar dependencias
dotnet restore

# Ejecutar la API
dotnet run
```

Por defecto la API se ejecuta en:
```
https://localhost:7176
```

---

### 🖥️ Frontend (Angular)
```bash
cd front

# Instalar dependencias
npm install

# Ejecutar servidor de desarrollo
ng serve
```

La aplicación se ejecutará en:
```
http://localhost:4200
```

---

## 🧩 Tecnologías Utilizadas

### 🔸 **Frontend**
- Angular 18+
- TypeScript
- RxJS / Observables 

### 🔸 **Backend**
- .NET 8 (C#)
- HttpClientFactory
- Dependency Injection 
- Newtonsoft.Json (Serialización)
 
---

## 👨‍💻 Autor
**Carlos Rojas**  
Desarrollador Full Stack  
📧 contacto: [carlos.rojas.ti@hotmail.com]  
🌐 [https://rickandmortyapi.com](https://rickandmortyapi.com)

---

> 💡 *“Aplicando los principios SOLID, no solo construimos software funcional, sino software sostenible.”*
