:::::::::Fokus for løsningen::::::::::::::

ALLE prosjekter blir større enn ved første øyekast. Behov for videreutvikling og endring uten å måtte redesigne hele løsninger må man alltid t hensyn til.
Løsningen fokuserer da på:
 - Gjøre det enkelt å gjenbruke kode.
 - Logisk adskille objekter fra hverandre.
 - Gjøre det enkelt for Controllere til å utføre operasjoner på Business-objekter, via "Transaksjoner" og "Services".
 - Ta høyde for at prosjektet en dag skulle stykkes opp i mindre deler eller spres over flere fysiske maskiner.
 - Ta høyde for fremtidig funksjonalitet. Feks RestAPI, testing og mulighet for å implementere API mot andre tjenester osv.
 - Følge det jeg tror er normen i arbeidslivet.

Oppbyggning av løsningen:
- MVC-prosjektet skal ikke vite om annet enn Business-objekter(BOL) og BLL-laget.
- BLL-prosjektet sine DataServices gjøre CRUD
	Referanse til BOL, DAL
- BOL-prosjektet har bare definisjonen av Business-objektene. Ingen referanser til andre prosjekter
- DAL-prosjektet har bare definisjonen av Db-objektene. Ingen referanser til andre prosjekter.


Nøkkelfunksjonalitet:
- CRUD av Business-objekter er "oneliners" i controllerne
- Utstrakt bruk av abstrakte klasser, interfaces og Generiske metoder i BLL og DataServices for å gjenbruke kode og holde vedlikehold til et minimum.
- Veldig klar "separation of concern". Det er ingen tvetydighet hva et objekt skal gjøre og hvordan det gjøres.
- GlobalInterceptor i BLL.AuthenticationServices "avskjærer" ALLE forespørsler og sjekker og gir SessionID til bruker.
- Passord Hashes ved hjelp av BLL.PasswordUtility før det lagres i databasen. 
- Sider er tilgjenglige/utilgjenglige avhengig av hvilken rolle brukeren har.
- Ajax
	- Kjøpefunksjonalitet og oppdatering av Handlekurv skjer via ajax-kall. Ajax er brukt litt flere steder også.
	- Ajax-scriptene ligger i Scripts\customscript.js
- Handlekurv/ShoppingCart bruker en unik SessionID som identifikasjon. BLL.AuthenticationServices.GlobalInterceptor passer på at alle 
	sessions har en gyldig SessionID. 
- BaseController er abstrakt Superklasse for alle kontrollere. Her har man noe metoder som brukes til å sende ActionResult med Session-beskjeder som fanger opp i Web.



Utfordringer:
- For å ha høyest mulig gjenbruk av kode så har AbstractService to generiske typer. R = businessmodel, T = dbmodell.
	- Dette fungerer fint, men ikke uten at BLL får referanse til DAL. For at BLL skal kunne bruke "Servicene" så må DAL være referenced.
	- Alternativet ville være å implementere alle CRUD-operasjonene i hver Service, uten stor bruk av Generics.
	- Jeg endte opp med fokus på gjenbruk av kode og BLL har referanse til DAL, noe jeg opprinnelig ønsket å unngå.
- MVC-prosjektet er ikke så oversiktelig som ønskelig. Det har "ballet på seg" underveis, og fokus på gjenbruk av Views med Partial Views er ikke tatt bruk før mot slutten.
- Role-løsningen til .NET liker strings. Ref BLL.AuthenticationServices.WebstoreRoleProvider.
	- CRUD-operasjoner liker helst "int ID"
	- Jeg har løst dette slik at Role-modellen bruker int for sin Key, men har også en String som representerer Id'ens int. 
	- Det vil si at hver User har både en RoleId (int) og en RoleStringId i string-format.
- Foreløpig er det ingen egen ViewUser-model, slik at User-modellen som brukes innehar passordet, og sendes til viewet.
