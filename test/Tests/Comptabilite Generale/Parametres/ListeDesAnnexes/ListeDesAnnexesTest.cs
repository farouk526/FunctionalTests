using NUnit.Framework;
using PageObjects;
using PageObjects.Comptabilite_Generale.Parametres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace Tests.Comptabilite_Generale.Parametres.ListeDesAnnexes;

[TestFixture]
public class ListeDesAnnexesTest:TestBase
{
    [Test]
    public void AjouterListeDesAnnexes()
    {
        var code = "";
        var libelle = "libelle";
        var observation = "";
        LoginAsAdmin();
        var homePage = new HomePage(WebDriver);
        var ListeDesAnnexesPage = homePage.GoToListeDesAnnexes();
        ListeDesAnnexesPage.AjouterListeDesAnnexes(code, libelle, observation);
        Assert.IsTrue(ListeDesAnnexesPage.Verifier(), "code and libelle is required ");

       

    }
    public void DeleteListeDesAnnexes()
    {

    }
}
