# DevHobby.CSharpDelegates

Kod źródłowy towarzyszący serii YouTube **„Delegaty w C# — od zera do produkcji”**
([dev-hobby.pl](https://dev-hobby.pl)). Format serii: **jeden przykład = jeden odcinek** —
docelowo około 40 samodzielnych lekcji, od pierwszego `delegate` po wzorce
produkcyjne (Strategy, eventy, middleware w stylu ASP.NET Core, `Expression<Func<T>>`).

Każdy projekt w tym repozytorium to kod w takiej postaci, w jakiej kończy się dany odcinek —
**dokładnie ten sam kod, co na nagraniu i w towarzyszącym wpisie na blogu.** Żadnych ulepszeń
ani zmian nazw dla porządku.

## Struktura repozytorium

```
DevHobby.CSharpDelegates/
├─ DevHobby.CSharpDelegates.sln
├─ DevHobby.L01-ButtonOnGamepad/          odcinek 1 — void ()
│  ├─ DevHobby.L01-ButtonOnGamepad.csproj
│  ├─ Program.cs                         ← kod finalny, gotowy do uruchomienia
│  └─ steps/                             ← migawki narracyjne z nagrania (poglądowe)
├─ DevHobby.L02-HelloWorldDelegates/      odcinek 2 — void (string)
│  ├─ DevHobby.L02-HelloWorldDelegates.csproj
│  ├─ Program.cs
│  └─ steps/
├─ DevHobby.L03-GreetingProvider/         odcinek 3 — string ()
│  ├─ DevHobby.L03-GreetingProvider.csproj
│  ├─ Program.cs
│  └─ steps/
└─ DevHobby.L04-SimpleCalculator/         odcinek 4 — int (int, int)
   ├─ DevHobby.L04-SimpleCalculator.csproj
   ├─ Program.cs
   └─ steps/
```

- **`Program.cs`** w każdym projekcie to wersja finalna ta, którą widzisz uruchomioną
  pod koniec odcinka. To jedyny plik, który się kompiluje i uruchamia w danym projekcie.
- **`steps/`** to kolejne stany kodu z nagrania (punkt startowy, budowanie krok po kroku,
  wersja z pułapkami, szkielet zadania domowego). Pliki są wyłączone
  z kompilacji (`<Compile Remove="steps/**" />` w `.csproj`) — służą do czytania, nie do
  uruchamiania obok `Program.cs` (dwa pliki z `Main` w jednym projekcie dają
  `CS0017: Program has more than one entry point`).

## Wymagania

- **.NET SDK 10.0 lub nowszy.** Kod nie korzysta z niczego specyficznego dla najnowszych
  wersji języka — jeśli potrzebujesz .NET 6 albo 7, 8, 9 zmień `<TargetFramework>` w `.csproj`
  na `net6.0` / `net7.0`, / `net8.0`, / `net9.0`,  zadziała bez zmian w kodzie.

## Jak uruchomić

```bash
git clone <adres-tego-repo>
cd DevHobby.CSharpDelegates

dotnet run --project DevHobby.L01-ButtonOnGamepad
dotnet run --project DevHobby.L02-HelloWorldDelegates
dotnet run --project DevHobby.L03-GreetingProvider
dotnet run --project DevHobby.L04-SimpleCalculator
```

Albo otwórz `DevHobby.CSharpDelegates.sln` w Visual Studio / Rider / VS Code, ustaw projekt
startowy na wybrany odcinek i uruchom `F5`.

## Mapa odcinków

| Odc. | Temat | Kształt delegata | Projekt | Wideo | Blog |
|---|---|---|---|---|---|
| 01 | Przycisk na padzie | `void ()` | [`DevHobby.L01-ButtonOnGamepad`](DevHobby.L01-ButtonOnGamepad/) | [YouTube](https://www.youtube.com/watch?v=xahHC93omPs) | [dev-hobby.pl](https://dev-hobby.pl/csharp/delegaty-w-csharp-dlaczego-metode-przypisujesz-bez-nawiasow/) |
| 02 | „Hello World” delegatów | `void (string)` | [`DevHobby.L02-HelloWorldDelegates`](DevHobby.L02-HelloWorldDelegates/) | [YouTube](https://www.youtube.com/watch?v=11OfggMw9so) | [dev-hobby.pl](https://dev-hobby.pl/csharp/delegat-z-parametrem-csharp/) |
| 03 | Generator powitań | `string ()` | [`DevHobby.L03-GreetingProvider`](DevHobby.L03-GreetingProvider/) | [YouTube](https://www.youtube.com/watch?v=acUVI2kOtB0) | [dev-hobby.pl](https://dev-hobby.pl/csharp/delegat-zwracajacy-wartosc-csharp/) |
| 04 | Prosty kalkulator | `int (int, int)` | [`DevHobby.L04-SimpleCalculator`](DevHobby.L04-SimpleCalculator/) | [YouTube](https://www.youtube.com/watch?v=3tV1z7PwtCY) | [dev-hobby.pl](https://dev-hobby.pl/csharp/delegat-z-wieloma-parametrami-csharp/) |

Cztery pierwsze odcinki budują **Poziom 0 — Mechanika delegatów**: te same trzy kroki
(definiujesz → przypisujesz → wywołujesz), za każdym razem z inną sygnaturą — zero
parametrów, jeden, wartość zwracana, a od odcinka 4 więcej niż jeden parametr naraz.
Kolejne odcinki dokładają delegaty jako pola i argumenty, multicast (`+=`/`-=`),
`Func`/`Action`, eventy i wzorce projektowe oparte na delegatach.
Repozytorium rośnie razem z serią — każdy nowy odcinek dokłada własny folder `DevHobby.LNN-...`.

## Konwencje kodu w tym repo

- **Solution:** `DevHobby.CSharpDelegates`. **Projekty:** `DevHobby.LNN-NazwaPoAngielsku`
  — prefiks `DevHobby.` (marka repo, zapobiega kolizjom namespace przy referencjonowaniu
  z innych projektów), potem `LNN` (numer odcinka zawsze dwucyfrowy — `L01`, nie `L1`,
  inaczej sortowanie alfabetyczne rozjeżdża się przy dwucyfrowych numerach odcinków),
  potem myślnik i nazwa w PascalCase **bez** myślników wewnątrz (np. `DevHobby.L01-ButtonOnGamepad`,
  nie `DevHobby.L01-Button-On-Gamepad`). `<RootNamespace>` w `.csproj` odzwierciedla tę samą
  konwencję, tylko bez myślnika przed numerem (`DevHobby.L01ButtonOnGamepad`).
- Identyfikatory w kodzie (klasy, metody, zmienne) — po angielsku, tak jak w realnym
  kodzie produkcyjnym. Komentarze po polsku, bo to na nich uczysz się mechaniki krok po kroku.
- Numery błędów kompilatora cytowane w komentarzach (`CS0029`, `CS0123`, `CS0407`...)
  pochodzą z realnych komunikatów wygenerowanych podczas nagrywania — nie są parafrazowane.

## Materiały towarzyszące

- 🎥 **YouTube:** [@mariuszjurczenko](https://www.youtube.com/@mariuszjurczenko) 
      — pełne odcinki z timingiem rozdziałów.
- 📖 **Blog:** [dev-hobby.pl/blog](https://dev-hobby.pl/blog/) 
      — wersje tekstowe każdego odcinka z sekcjami pułapek (numery `CS####`), 
        tabelami porównawczymi i interaktywnymi wstawkami do przeklikania.
- 📘 **Darmowa roadmapa Junior .NET Developer:** [dev-hobby.pl/lista-vip](https://dev-hobby.pl/lista-vip/).

## Zgłaszanie błędów

Jeśli kod w tym repo nie kompiluje się, nie działa zgodnie z opisanym w komentarzu 
oczekiwanym outputem, albo różni się od tego, co pokazano w wideo — otwórz issue.

## Licencja

Kod udostępniony jako materiał edukacyjny do serii „Delegaty w C#”. 
Możesz go swobodnie klonować, uruchamiać i wykorzystywać do nauki własnej 
oraz w materiałach edukacyjnych z podaniem źródła.
