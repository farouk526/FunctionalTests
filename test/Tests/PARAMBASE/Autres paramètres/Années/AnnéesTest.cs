using NUnit.Framework;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace PARAMBASE.Autres_paramètres.Années
{
    [TestFixture]
    public class AnnéesTest:TestBase
{
        [Test]
        public void AjouterAnnées()
        {
            Random r = new Random();
            var numero = r.Next().ToString();
           
            var libelleFr = "libelle1";
            var libelleAr = "libelle2";
            var smig = "4.00 TND";
            var montantftp = "4.99 TND";
            var fraisProf = "33%";
            var pourcentage = "4%";
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var AnnéesPage = homePage.GoToAnneePages();
           
                AnnéesPage.AjouterAnnee(numero, libelleFr, libelleAr, smig, montantftp,fraisProf,pourcentage);

           
            //verification
            Assert.IsTrue(AnnéesPage.VerifierNumeroExist(numero), "ajout n'a pas marché");

        }
    }
}
