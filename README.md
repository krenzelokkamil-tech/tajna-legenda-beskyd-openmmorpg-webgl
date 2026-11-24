# Tajná legenda Beskyd — OpenMMORPG WebGL test

Tato **veřejná technická kopie pro Unity WebGL build** používá skutečný OpenMMORPG v1.5.1 (MIT), nikoli napodobeninu hry. Veškeré herní scény a původní obsah se načítají z veřejného upstream repozitáře jako Git submodule v `Assets/OpenMMORPG`.

Zaměření první fáze: **WebGL singleplayer demo**. Původní scéna `Demo/Scenes/00Init-Singleplayer.unity` je cestou k hratelnému světu bez mapového serveru. Multiplayer vyžaduje samostatný Unity mapový server a bude se testovat až po úspěšném sestavení a vizuální kontrole klienta.

## Zdroj a licence

- OpenMMORPG: <https://github.com/open-mmorpg/OpenMMORPG>
- Konkrétní vydání: `v1.5.1`, commit `e87f9b796168db0d31b1bcbc2f8d40c27813c5ef`
- `LICENSE` a `Third-Party Notices.txt` v submodulu nadále platí, stejně jako `Demo/CREDITS.md` pro grafiku.

## Jak projekt použít

1. Naklonovat repozitář včetně submodulu: `git clone --recurse-submodules <adresa testovacího repozitáře>`.
2. V Unity Cloud Build Automation navolit tento repozitář, Unity **6000.3+**, platformu **WebGL** a cíl `Assets/Editor/OpenMMORPGWebGLBuild.Build`.
3. Pokud Unity Cloud automaticky nestáhne Git submoduly, zapnout checkout submodules před importem.
4. Po sestavení vyzkoušet `Build/WebGL` přes HTTPS ve webovém prohlížeči.

Build skript kontroluje přítomnost hlavních demo scén a nastavuje výchozí demo URP konfiguraci, pokud je asset k dispozici. Není použit žádný vlastní model ani přepsaná verze původní hry.

**Stav:** zdrojový kód .NET backendu a jeho testy ověřeny. Unity/WebGL kompilace tohoto wrapperu zatím neproběhla. Případné kompilační problémy je třeba zjistit z prvního skutečného cloud buildu.

Stávající Tajná legenda Beskyd i ostatní hry KamIva Games zůstávají **nedotčené**.
