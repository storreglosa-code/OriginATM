# 🏧 OriginATM — Simulador de Cajero Automático

OriginATM es una aplicación web desarrollada con .NET 8 y MVC que simula el comportamiento de un cajero automático. Permite a los usuarios autenticarse con su número de tarjeta y PIN, consultar el saldo y realizar retiros.

---

## ✨ Funcionalidades

- 🔐 Inicio de sesión con número de tarjeta + PIN
- 💰 Consulta de saldo disponible
- 💳 Retiros con validación de fondos
- 🧾 Registro de operaciones
- 🐳 Deploy automático vía Docker Compose

---

## 🛠️ Tecnologías Utilizadas

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server 2022
- Docker y Docker Compose
- C#
- Bootstrap (UI simple)
- JavaScript
- HTML5
- CSS3

---

## 🧱 Arquitectura del Proyecto

El proyecto sigue una estructura por capas con separación de responsabilidades:

- `OriginATM.Web`: Proyecto principal MVC
- `OriginATM.Dominio`: Entidades y enums.
- `OriginATM.Repository`: Implementaciones de Patrón Repository.
- `OriginATM.Infraestructura`: DbContext y configuración de Entity Framework.

---

## 🚀 ¿Cómo correr la aplicación?

> ⚠️ Requisitos: Docker Desktop

```bash
git clone https://github.com/storreglosa-code/OriginATM.git
cd OriginATM
docker-compose up --build
