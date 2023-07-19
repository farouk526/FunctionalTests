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
    public class GrillesTest : TestBase
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
            var GrillesPage = homePage.GoToGrillesPages();
            if (!GrillesPage.VerifierCodeExist(code))
            {
                GrillesPage.AjouterGrilles(code, libelleFr, libelleAr, obsF, obsA, descFr, descAr);

            }
            //verification
            Assert.IsTrue(GrillesPage.VerifierCodeExist(code), "ajout n'a pas marché");

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
        public void deleteGrille2()
        {
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var GrillesPage = homePage.GoToGrillesPages();
            var firstCode = GrillesPage.getDefaultCode();
            GrillesPage.Delete(firstCode);
            //verification du delete
            Assert.IsFalse(!GrillesPage.VerifierCodeExist(firstCode), "delete with success");

        }
        [Test]
        public void EditGrille()
        {
            Random r = new Random();
            var c = r.Next().ToString();
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var GrillePage = homePage.GoToGrillesPages();
            var code = GrillePage.getFirstCode();
            if (GrillePage.VerifierCodeExist(code))
            {
                GrillePage.updateGrille(c, "libelleFr", "libelleAr", "obsF", "obsA", "descF", "descAr");

                Assert.IsTrue(GrillePage.VerifierCodeExist(c), "Modification success");

            }

        }
    }
}
