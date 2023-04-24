# mono2023
Testar MonoGame. Detta projekt använder MonoGame 3.8.1 och kräver Visual Studio 2022.

## Setup MonoGame 2022 with Visual Studio 2022. 
På [MonoGames sida](https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_windows.html) finns instruktioner för hur man sätter upp MonoGame 3.8.1 med Visual Studio 2022. En bra bok att använda med detta projekt är [MonoGame Mastery](https://www.apress.com/gp/book/9781484263082), de finns även på [GitHub](https://github.com/Apress/monogame-mastery).

## Koncept
### GameStates
Det finns olika lägen som spelet kan finnas i. Varje GameState har funktioner för att rita ut och uppdatera entiteter. Varje GameState ansvarar även för att ladda in media (som bilder, musik osv.) som behövs. Det finns två states idag, SplashState och GameplayState. 

### Event Component System (ECS)
Detta projekt använder [Monogame Exteneded](https://github.com/craftworkgames/MonoGame.Extended) för att implementera ett [Event Component System](https://www.gamedev.net/articles/programming/general-and-gameplay-programming/understanding-component-entity-systems-r3013/). System ska ligga under mappen System och komponenter ska ligga under mappen Components. Här finns en lista på mer dokumentation som är bra att ha.
- [Monogame.Extended.Entities dokumentation.](https://www.monogameextended.net/docs/features/entities/entities/)
- [PartumGames exempel på ECS.](https://github.com/PartumGames/ECS-Demo)
- [Bra youtube video som förklarar konceptet](https://www.youtube.com/watch?v=Z-CILn2w9K0)
#### RenderSystem
Detta system är ansvarar för att rita ut saker på skärmen. Det verkar inte som att lösningen för skalning mot olika upplösningar av fönstret som tas upp i boken MonoGame Mastery funkar, så jag har därför utgått från [lösningen i denna youtube video](https://www.youtube.com/watch?v=-5ELPrIJNvA). 

## Läs vidare
- [MonoGame Samples](https://github.com/MonoGame/MonoGame.Samples)
