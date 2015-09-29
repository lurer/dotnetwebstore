Fokus for løsningen:
ALLE prosjekter blir større enn ved første øyekast. Jeg har derfor tatt hensyn til dette og laget løsningen så løst koblet som mulig.
Det vil si at det er flere prosjektet i løsningen som har et veldig snevert fokusområde, men de er tatt i bruk for å:
 - Gjøre det enkelt å gjenbruke kode.
 - Logisk adskille objekter fra hverandre.
 - Gjøre det enkelt for Controllere til å utføre operasjoner på Business-objekter, via "Transaksjoner" og "Services".
 - Ta høyde for at prosjektet en dag skulle stykkes opp i mindre deler eller spres over flere fysiske maskiner.
 - Ta høyde for fremtidig funksjonalitet. Feks RestAPI, mulighet for å implementere API mot andre tjenester osv.
 - Følge det jeg mener/tror er normen i arbeidslivet.

Oppbyggning av løsningen:
- MVC-prosjektet skal ikke vite om annet enn Business-objekter(BOL), BLL-laget og DataServices.
- BLL-prosjektet opererer via DataServices-prosjektet for å gjøre CRUD. 
	Referanse til BOL, DAL og DataServices. (Les om utfordringen nedenfor)
- DataServices-prosjektet tar i mot Business-objekter og lagrer dem via Entity Framework. Samme andre veien. Referanser til BOL og DAL
- BOL-prosjektet har bare definisjonen av Business-objektene. Ingen referanser til andre prosjekter
- DAL-prosjektet har bare definisjonen av Db-objektene. Ingen referanser til andre prosjekter.


Nøkkelfunksjonalitet:
- CRUD av Business-objekter er "oneliners" i controllerne
- Utstrakt bruk av abstrakte klasser, interfaces og Generiske metoder i BLL og DataServices for å gjenbruke kode og holde vedlikehold til et minimum.
- Veldig klar "separation of concern". Det er ingen tvetydighet hva et objekt skal gjøre og hvordan det gjøres.
- Passord Hashes vis BLL.PasswordUtility før det lagres i databasen. 
- Sider er tilgjenglige/utilgjenglige avhengig av hvilken rolle brukeren har.


Utfordringer:
- For å ha høyest mulig gjenbruk av kode så har AbstractService to generiske typer. R = businessmodel, T = dbmodell.
	- Dette fungerer fint, men ikke uten at BLL får referanse til DAL. For at BLL skal kunne bruke "Serviceene" så må DAL være referenced.
	- Alternativet ville være å implementere alle CRUD-operasjonene i hver Service, uten stor bruk av Generics.
	- Jeg endte opp med fokus på gjenbruk av kode og BLL har referanse til DAL, noe jeg opprinnelig ønsket å unngå.