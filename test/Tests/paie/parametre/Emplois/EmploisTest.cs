using NUnit.Framework;
using PageObjects;
using PageObjects.paie.parametres;
using test;

namespace Tests.paie.parametre.Emplois;
[TestFixture]
public class EmploisTest : TestBase
{
    [Test]
    public void AjouterEmplois()
    {
        Random r = new Random();
        var code = r.Next().ToString();
        var libelleFr = "libelle1";
        var libelleAr = "libelle2";
        LoginAsAdmin();
        var homePage = new HomePage(WebDriver);
        var emploisPage = homePage.GoToEmploisPage();
        if(!emploisPage.VerifierCodeExist(code))
        {
            emploisPage.AjouterEmployee(code, libelleFr, libelleAr);
        
        }
        //verification
        Assert.IsTrue(emploisPage.VerifierCodeExist(code), "ajout n'a pas marché");

    }
    [Test]
    public void DeleteEmplois()
    {
        LoginAsAdmin();
        var homePage = new HomePage(WebDriver);
        var emploisPage = homePage.GoToEmploisPage();
        var firstCode = emploisPage.getFirstCode();
        emploisPage.DeleteEmployee();
        //verification du delete
        Assert.IsFalse(!emploisPage.VerifierCodeExist(firstCode), "delete with success");
        
       
    }

    [Test]
    public void UpdateEmplois()
    {
        LoginAsAdmin();
        var homePage = new HomePage(WebDriver);
        var emploisPage = homePage.GoToEmploisPage();
        emploisPage.ModifierEmployee("18","Newlibelle1", "Newlibelle2");

    }
}
