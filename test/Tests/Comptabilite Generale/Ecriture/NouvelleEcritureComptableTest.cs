using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using PageObjects.Comptabilite_Generale.Ecriture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace Tests.Comptabilite_Generale.Ecriture
{
    [TestFixture]
    public class NouvelleEcritureComptableTest:TestBase
     {
       
        [Test]
        public void AjouterNvleEcritComptable()
        {
            var journal = "60 - journal Achat";
            var Debit = "22";
            var credit = "0";
            var origine = "origine";
            var dateE = "06/05/2023 19:45:39";
            var num1 = "200";
            var dateP1 = "07/06/2023 19:45:39";
            var num2 = "200";
            var dateP2 = "08/06/2023 19:45:39";
            var numero = "1";
            var compte = "73020000 - BAIL ESPECE PUBLICITAIRE";
            var affectation = "OLMI";
            var libelle = "libelle";
            var tiere = "AYED JAMEL EDINE";
            var client = "clientB";
            var reference = "reference";
            var numeroSequenece = "123";
            var observation = "observation";
            var credit2 = "20";
             LoginAsAdmin();
            var homePage = new HomePage(WebDriver);
         
            var NvleEcritureComptablePage = homePage.GoToNvleEcritureComptablePage();
         
             NvleEcritureComptablePage.AjouterNouvelleEcritureComptable(journal,origine,dateE, num1, dateP1, num2, dateP2,numero,compte,libelle,tiere,Debit,credit,numeroSequenece,client,reference,affectation,observation,credit2);
        

        }
}
}
