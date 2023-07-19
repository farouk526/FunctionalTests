using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using PageObjects.paie.parametres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace Tests.Comptabilite_Generale.Parametres.Journaux_comptables
{
    [TestFixture]
    public class JournalComptableTest:TestBase
{
        [Test]
        public void AjouterJournalComptable()
        {
            Random r = new Random();
            var code = r.Next().ToString();
            var libelle = "libelle1";
            var dateVerrouillage = "12/07/2023";
            var compteAssocie = "1";
            var type = "Achats";
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();

            if (!JournauxComptablesPage.VerifierCodeExist(code))
            {
                JournauxComptablesPage.AjouterJournalComptable(code, libelle, dateVerrouillage, compteAssocie, type);

            }
            Assert.IsTrue(JournauxComptablesPage.VerifierCodeExist(code), "ajout n'a pas marché");
        }
        [Test]
        public void DeleteJournalComptable()
        {

            LoginAsAdmin();
            var code = 34;
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();
            JournauxComptablesPage.DeleteJournalByCode(code);

        }
        [Test]
        public void UpdateJournalComptable()
        {
            LoginAsAdmin();
            var code = 34;
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();
            var libelle = "libelle1";
            var dateVerrouillage = "1/07/2023";
            var compteAssocie = "1";
            var type = "Achats";
            JournauxComptablesPage.UpdateJournalByCode(code, libelle, dateVerrouillage, compteAssocie, type);
        }
        [Test]
        public void SearchByCode()
        {
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();
            var code = "5";
            JournauxComptablesPage.SearchByCode(code);
        }
        [Test]
        public void SearchByLibelle()
        {
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();
            var libelle = "BNA LAFAYETTE RECETTE";
            JournauxComptablesPage.SearchByLibelle(libelle);
        }
        [Test]
        public void SearchByType()
        {
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();
            var type = "";
            JournauxComptablesPage.SearchByType(type);
        }
        [Test]
        public void SearchByDateVerouillage()
        {
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();
            var date = "31-12-2014";
            JournauxComptablesPage.SearchByDateVerrouillage(date);
        }
        [Test]
        public void SearchForValue()
        {
            var value = "REDRESSEMENTS COMPTABLES";
            LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
            var JournauxComptablesPage = homePage.GoToJornauxComptable();

            JournauxComptablesPage.SearchByValue(value);
        }
    }
   
}
