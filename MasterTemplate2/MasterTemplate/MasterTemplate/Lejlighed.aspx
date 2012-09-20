<%@ Page Title="Lejlighed" Language="C#" AutoEventWireup="true" CodeBehind="Lejlighed.aspx.cs" MasterPageFile="~/Site.master" Inherits="MasterTemplate.Lejlighed" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title></title>

</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="add">
        <h1>Billig 2V andelslejlighed i Vanløse til salg</h1>
        <h2>Lille andelsforening med sund økonomi og lave fællesudgifter</h2>
        <div id="mainFigures">
            <table id="figures">
                <tbody>
                    <tr>
                        <td>Adresse</td>
                        <td>Ålekistevej 58 st. tv., 2720 Vanløse</td>
                    </tr>
                    <tr>
                        <td>Størrelse</td>
                        <td>51 m<sup>2</sup></td>
                    </tr>
                    <tr>
                        <td>Værdi iflg. seneste regnskab</td>
                        <td>333.948,75 kr.</td>
                    </tr>
                    <tr>
                        <td>Månedlige fællesudgifter</td>
                        <td>3.063,75 kr.</td>
                    </tr>
                    <tr>
                        <td>Heraf aconto varme</td>
                        <td>300 kr.</td>
                    </tr>
                    <tr>
                        <td>Forventede forbedringer (MAX)</td>
                        <td>20.000 kr.</td>
                    </tr>
                    <tr>
                        <td>Afstand til indkøb</td>
                        <td>50 m</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <p><em>Du har nu mulighed for at købe en særdeles velindrettet 2-værelses lejlighed på 51 m<sup>2</sup>, til en attraktiv pris. Lejligheden er beliggende på Ålekistevej tæt på Damhussøen og dejlige grønne arealer med gode løbemuligheder. Der er desuden gode muligheder for gratis parkering lige foran hoveddøren og så behøver du kun at krydse vejen for at klare de daglige indkøb i SuperBrugsen.<br />
        Der er desuden kort afstand til Shopping i såvel Danmarks bedste storcenter, Rødovre Centret, samt det nye shoppingcenter, Galleri A, ved Vanløse station, som ventes at stå færdigt i 2013.<br />
        Der er gode transportmuligheder med buslinie 22 kørende lige til døren. Ligeledes stopper buslinie 14 og natbussen på den nærliggende Jydeholmen, og Metro og S-tog kører regelmæssigt fra hhv. Vanløse st. og Flintholm st. ca. 1 km væk<br />
        <br />
        Samtlige af lejlighedens rum er adskilt af en fordelingsgang som giver gode muligheder for opbevaring af overtøj og sko.<br />
        Lejligheden har et lille badeværelse, som ikke er så småt at du bliver nødt til at tage bad i toiletkummen, men samtidig ikke er så stort at det optager unødige kvadratmeter fra resten af lejligheden.<br />
        Køkkenet er for ca. 10 år siden moderniseret og har masser af hyldeplads. Af hårde hvidevarer medfølger glaskeramisk komfur fra Zanussi, Køleskab fra XYZ med indbygget rummelig fryser, microbølgeovn fra Idéline samt en vandbesparende opvaskemaskine fra Siemens<br />
        Soveværelset ligger uforstyrret ud til en dejlig gårdhave med gode muligheder for at grill og fællesspisning. Gårdhaven deles med gårdens øvrige omkringliggende boligforeninger. Soveværelset har et stort og rummeligt klædeskab fra gulv til loft til den pladskrævende garderobe.<br />
        Til lejligheden hører et kælderrum med gode opbevaringsmuligheder af forskelligt indbo. Der er desuden mulighed for cykelparkering i kælderen samt billig tøjvask i foreningens vaskeri.
         </em></p>
         <br />
         <h2>Hvorfor flytter vi?</h2>
         <p>Perry har boet i lejligheden siden oktober 2000, mens Sabine flyttede ind i februar 2007. Vi har begge været rigtigt glade for at bo i lejligheden og ikke mindst for at bo i Vanløse med de fantastiske muligheder det giver.<br />
         Vi har altid haft en drøm om et hus med mere plads og egen have og da vi står overfor en familieforøgelse, er tiden moden til at finde noget nyt.<br /> 
         Det er vemodigt at flytte netop nu, hvor der sker mange spændende ting i Vanløse, men omvendt er vi klar til nye eventyr tættere på resten af familien.<br />
         Det vi kommer til at savne mest er at have alt indenfor rækkevidde. Vi har brugt Damhussøen og -engen meget til gode gåture i efterårsvinden, Rødovre Centret til de store indkøb og juleshopping, samt Metroen til at komme let til lufthavnen når vi skulle på ferie. <br />
         Vi har desuden nydt godt af den dejlige og nyrestaurerede biograf på Jernbane Allé og den tilhørende restaurant. Vi har desuden sat pris på at bo i en relativ rolig bydel i København, trods det at lejligheden ligger ud til Ålekistevej. 
         </p>
         <div id="MaxEighty">
            <asp:Label ID="Label1" runat="server" Text="Belåning i procent af lejlighedens værdi"></asp:Label>
            <select id="LoanPercentage">
                <option></option>
            </select>
            <asp:Label ID="Label2" runat="server" Text="Stiftelsesomkostninger"></asp:Label>
            <select id="InitialCost">
                <option></option>
            </select>
            <asp:Label ID="Label3" runat="server" Text="Lånets løbetid"></asp:Label>
            <select id="LoanPeriod">
                <option></option>
            </select>
            <asp:Label ID="Label4" runat="server" Text="Pålydende rente"></asp:Label>
            <select id="Interest">
                <option></option>
            </select>
            <asp:Button ID="Button1" runat="server" Text="Beregn ydelse" />
        </div>
        <div id="EightyToHundred">
            <select id="LoanPercentage2">
                <option></option>
            </select>
            <select id="InitialCost2">
                <option></option>
            </select>
            <select id="LoanPeriod2">
                <option></option>
            </select>
            <select id="Interest2">
                <option></option>
            </select>
        </div> 
    </div>
    
    
</asp:Content>
