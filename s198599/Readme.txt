:::::::::::: For mappe2 ::::::::::::::
Adminbruker: admin@online.no	Passord: admin123
Generell informasjon:
- Det å avdekke potensielle UseCases til en nettbutikk er ganske vanskelig, med tanke på at vi vet at vi har liten tid på gjennomføring, og dermed ikke ønsker å
ta høyde for mer funksjonalitet enn det vi kan implementere. Følgende punkter er jeg klar over at ikke er implementert, men det krever for mye ombygging av database og system
for at jeg vil ta tiden med å implementere det. Jeg håper det er greit.
	- Boolean true/false på objekter, om det er synlig/aktivert eller ikke. Jeg kan ikke slette objekter med avhengigheter fra databasen.
	- Custom Error sider. Dette skulle vært på plass, og det er ikke så vanskelig.
	- Bedre "drilling" i data. Feks er Ordre-listen under Admin ganske sparsom og lite nyttig. Jeg har en TODO-liste med flere ting som har med brukbarhet å gjøre...
	- Bekrefte sletting av Produkter, varer osv. Modal brukes i andre sammenhenger og er dokumentert at jeg kan. Det burde likevel vært med her...


Logging i database:
	- Logging til database skjer via overriding av SaveChanges i DataContext.cs. Hver av databasemodellene implementerer et interface kalt IAuditedEntity.cs.
	- Dette er en lånt løsning fra http://stackoverflow.com/questions/26355486/entity-framework-6-audit-track-changes
	- Det logges når en entitet blir opprettet og når den endres.
Logging til fil:
	- Det er laget en CustomDbException som arver EntityException. Denne filen har en logToFile()-metode som skrive til loggfil. loggfilen ligger i App_Data-mappen.
	- Alle metoder som kontakter databasen på noen måte har en try/catch, der man catcher CustomDbException.
Enhetstester:
	- Controllerne er laget så enkle som mulig slik at enhetstestene også blir enkle. Veldig mye av testene er like for alle controllerne. Jeg har i stedet
	valgt å bruke Ajax/JQuery i websidene for å hente flere "enkle" objekter i stedet for å enhetsteste en kontroller med veldig komplekse objekter.

Designvalg - teknisk:
	- Det er ikke mulig å slette objekter som har avhengigheter. Altså Produkter som finnes i en Ordre kan ikke slettes. 
	Egentlig Ville jeg hatt en skikkelig database på 3. normalform med fysiske tabeller på mange-til-mange relasjoner og full støtte for historikk, men dette er altså ikke prioritert.

Designvalg - Web og Javascript:
	- Administrasjon av produkter/items har automatisk "varsling" på produkter som det er få igjen av på lager.
	Man får en modal som viser hvilke produkter dette gjelder og man får anledning til å "bestille" i et 10 nye.
	I det man ikke har flere produkter igjen å bestille så forsvinner modalen.
	






-------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------

:::::::::Fokus for løsningen::::::::::::::

Pålogginger i bruk:
Admin-bruker: admin@online.no	Passord: admin123
Kunde (med historikk): truls@online.no	Passord: Test123


ALLE prosjekter blir større enn ved første øyekast. Behov for videreutvikling og endring uten å måtte redesigne hele løsninger må man alltid t hensyn til.
Løsningen fokuserer da på:
 - Gjøre det enkelt å gjenbruke kode.
 - Logisk adskille objekter fra hverandre.
 - Gjøre det enkelt for Kontrollere til å utføre operasjoner på Business-objekter, via "Transaksjoner" og "Services".
 - Ta høyde for fremtidig funksjonalitet. Feks RestAPI, testing og mulighet for å implementere API mot andre tjenester osv.
 - Følge det jeg tror er normen i arbeidslivet.


::::::::::::Oppbyggning av løsningen::::::::::::::
- MVC-prosjektet skal ikke vite om annet enn Business-objekter(BOL) og BLL-laget.
- BLL-prosjektet sine DataServices gjør CRUD
	Referanse til BOL, DAL
- BOL-prosjektet har bare definisjonen av Business-objektene. Ingen referanser til andre prosjekter
- DAL-prosjektet har bare definisjonen av Db-objektene. Ingen referanser til andre prosjekter.

- Opprinnelig ville jeg hatt DB-operasjoner og Context liggende i DAL, og at MVC-prosjektet IKKE skal ha tilgang til DAL. I mitt hode så bør MVC bare snakke med BLL og vite
	om BOL. DAL er noe man ikke har noe forhold til i MVC-prosjektet, og bør dermed ikke være referert til.
	Konklusjon: Det fungerer ikke ettersom Context må være tilgjenglig for MVC. Derfor ligger DB-operasjoner og Context i BLL.


:::::::::::Nøkkelfunksjonalitet:::::::::::::
- CRUD av Business-objekter er "oneliners" i controllerne
- Utstrakt bruk av abstrakte klasser, interfaces og Generiske metoder i BLL for å gjenbruke kode og holde vedlikehold til et minimum.
- Klar "separation of concern". Det er ingen tvetydighet hva et objekt skal gjøre og hvordan det gjøres.
- GlobalInterceptor i BLL.AuthenticationServices "avskjærer" ALLE forespørsler og sjekker og gir SessionID til nye brukere.
- Passord Hashes ved hjelp av BLL.AuthenticationServices.PasswordUtility før det lagres i databasen. (Hentet idé fra nettet. Kommentar i klassen på det)
- Sider er tilgjenglige/utilgjenglige avhengig av hvilken rolle brukeren har.
- Ajax
	- Kjøpefunksjonalitet og oppdatering av Handlekurv skjer via ajax-kall. Ajax er brukt litt flere steder også.
	- "MinSide" brukes Ajax for å laste Ordrehistorikk, og Visning av ordredetaljer skjer også via Ajax og modalt popup.
	- Generelle Ajax-script ligger i \MyScripts\customscript.js
- Handlekurv/ShoppingCart bruker en unik SessionID som identifikasjon. BLL.AuthenticationServices.GlobalInterceptor passer på at alle 
	sessions har en gyldig SessionID. 
- BaseController er abstrakt Superklasse for alle kontrollere. Her finnes noen metoder som brukes til å sende ActionResult med Session-beskjeder som fanges opp i Web.
	- Dette for å slippe å huske syntaksen, samt å forholde seg til session-objektene i hver metode i alle kontrollerne.



:::::::::Utfordringer::::::::::::::
- MVC-prosjektet er ikke så oversiktelig som ønskelig. Det har "ballet på seg" underveis, og fokus på gjenbruk av Views med Partial Views er ikke tatt bruk før mot slutten.
- Role-løsningen til .NET liker strings. Ref BLL.AuthenticationServices.WebstoreRoleProvider.
	- CRUD-operasjoner liker helst "int ID"
	- Jeg har løst dette slik at Role-modellen bruker int for sin Key, men har også en String som representerer Id'ens int. 
	- Det vil si at hver User har både en RoleId (int) og en RoleStringId i string-format.
- Foreløpig er det ingen egen ViewUser-model, slik at User-modellen som brukes innehar passordet, og sendes til viewet.
	- Dette medfører at endring av User ikke fungerer for øyeblikket. User har mange felter som ikke vises i Web-sidene. 
	Når bruker endrer sin konto så står disse feltene til "null" i det Controller får henvendelsen og dermed er ModelState "invalid".
	HAr ikke kommet på en god løsning på dette enda...
