using NUnit.Framework;
using PageObjects;
using PageObjects.paie.parametres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace Tests.paie.parametre.Grilles
{
    [TestFixture]
    public class GrillesTest:TestBase
{
        [Test]
        public void AjouterGrille()
        {
            Random r = new Random();
            var code = r.Next().ToString();
            var libelleFr = "libelle1";
            var libelleAr = "libelle2";
            var obsF = "obs";
            var obsA = "obs";
            var descFr = "ddescF";
            var descAr = "descAr";   
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var GrillesPage=homePage.GoToGrillesPages();
            if (!GrillesPage.VerifierCodeExist(code))
            {
                GrillesPage.AjouterGrilles(code,libelleFr,libelleAr,obsF,obsA,descFr,descAr);

            }
            //verification
            Assert.IsTrue(GrillesPage.VerifierCodeExist(code), "ajout n'a pas marché");

        }
        [Test]
        public void DeleteProp()
        {
            LoginAsAdmin(); var homePage = new HomePage(WebDriver);
            var propPage = homePage.GoToGrillesPages();
            var code = propPage.getFirstCode();
            if (propPage.VerifierCodeExist(code))
            {
                propPage.Delete(code);
            }
            Assert.IsFalse(propPage.VerifierCodeExist(code), "Delete success");
        }
        [Test]
        public void deleteGrille()
        {
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var GrillesPage = homePage.GoToGrillesPages();
            var firstCode = GrillesPage.getFirstCode();
            GrillesPage.DeleteGrille();
            //verification du delete
            Assert.IsFalse(!GrillesPage.VerifierCodeExist(firstCode), "delete with success");

        }
        [Test]
        public void EditGrille() { 
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var GrillePage = homePage.GoToGrillesPages();
            GrillePage.updateGrille("234", "libelleFr", "libelleAr", "obsF", "obsA","descF","descAr");
         
        }

    }
}
