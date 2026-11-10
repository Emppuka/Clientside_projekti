# LifeManagementApp

LifeManagementApp on .NET MAUI -sovellus, jonka tarkoituksena on auttaa käyttäjää hallitsemaan päivittäisiä tehtäviä ja seuraamaan säätilaa yhdestä käyttöliittymästä.

## Tekoälyn käyttö

Projektin aikana käytettiin Microsoft Copilotia apuna:

- MVVM-rakenteen suunnittelussa
- SQLite- ja Entity Framework Core -integraation toteutuksessa
- .NET MAUI -käyttöliittymän rakentamisessa
- virheiden etsinnässä ja korjaamisessa
- README-dokumentaation laatimisessa

Kaikki ratkaisut testattiin, ymmärrettiin ja tarvittaessa muokattiin ennen niiden lisäämistä projektiin.

## Käytetyt teknologiat

- .NET MAUI
- C#
- MVVM
- CommunityToolkit.Mvvm
- Dependency Injection
- SQLite
- Entity Framework Core
- Open-Meteo REST API
- Git ja GitHub

## Ominaisuudet

### TODO-lista

- Tehtävien lisääminen
- Tehtävien poistaminen
- Tehtävien muokkaaminen
- Prioriteetin valinta (Korkea, Normaali, Matala)
- Tehtävien automaattinen lajittelu prioriteetin perusteella
- Tehtävien pysyvä tallennus SQLite-tietokantaan

### Etusivu

- Kolmen tärkeimmän tehtävän näyttäminen
- Ajankohtaisen sään näyttäminen
- Lämpötilan näyttäminen
- Tuulen nopeuden näyttäminen
- Kitesurffauskelin arviointi tuulen nopeuden perusteella

### Tallennus

- SQLite-tietokanta
- Entity Framework Core
- Tehtävät säilyvät sovelluksen sulkemisen jälkeen

## Teknologiat

Projektissa on käytetty seuraavia teknologioita:

- .NET MAUI
- C#
- MVVM-arkkitehtuuri
- CommunityToolkit.Mvvm
- Dependency Injection
- SQLite
- Entity Framework Core
- Open-Meteo REST API

## Arkkitehtuuri

Projektissa käytetään MVVM-rakennetta:

```text
Models
├── TodoItem

Services
├── WeatherService
├── TodoService

ViewModels
├── HomeViewModel
├── TodoViewModel

Views
├── HomePage
├── TodoPage

Data
├── AppDbContext
```

## Tietokantarakenne

### TodoItem

| Kenttä | Selitys |
|---------|---------|
| Id | Tehtävän tunnus |
| Title | Tehtävän nimi |
| Priority | Prioriteetti |
| CreatedAt | Luontiaika |
| IsCompleted | Valmistumistieto |

## Prioriteetit

| Arvo | Selitys |
|--------|--------|
| 0 | Korkea |
| 1 | Normaali |
| 2 | Matala |

## Käyttöönotto

1. Kloonaa repositorio

```bash
git clone <repository-url>
```

2. Avaa projekti Visual Studiossa

3. Palauta NuGet-paketit

4. Käynnistä sovellus

Tietokanta luodaan automaattisesti ensimmäisellä käynnistyskerralla.

## Oppimistavoitteet

Projektin aikana harjoiteltiin:

- REST API:n käyttöä
- JSON-datan käsittelyä
- MVVM-suunnittelumallia
- Dependency Injectionia
- SQLite-tietokantoja
- Entity Framework Corea
- Data Bindingia
- .NET MAUI -sovelluskehitystä

## Kehittäjä

Emppu K

Syksy 2026

Client Side Programming
