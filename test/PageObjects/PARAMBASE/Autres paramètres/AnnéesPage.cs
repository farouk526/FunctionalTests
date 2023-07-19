using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.PARAMBASE.Autres_paramètres
{
    public class AnnéesPage:PageBase
{
        public AnnéesPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        private const string NEW_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-annees/tsi-generic-crud/div/p-toolbar/div/div/button[1]/span[2]";
        private const string NUMERO_INPUT = "numero";
        private const string LibelleFR_INPUT = "libelleFr";
        private const string Libelle_Ar_INPUT = "libelleAr";
        private const string SMIG_INPUT = "Smig";
        private const string MONTANTTFP_INPUT = "MontantTfp";
        private const string FRAIS_PROFESSIONELS = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-annee/form/fieldset/div/div[4]/div[2]/tsi-rate-input/p-inputnumber/span/input";
        private const string POURCENTAGE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-annee/form/fieldset/div/div[4]/div[2]/tsi-rate-input/p-inputnumber/span/input";
        private const string NUMEROS_FROM_COLUMN = "";
        private const string SAVE_BUTTON = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-annee/form/tsi-modal-footer/div/button[2]";

        public void AjouterAnnee(string numero, string libelleFr,string libelleAr,string smig,string montantftp,string fraisProf,string pourcentage)
        {
            var NewBtn = WaitForElementIsVisible(By.XPath(NEW_BUTTON));
            NewBtn.Click();
            var numeroInput = WaitForElementIsVisible(By.Name(NUMERO_INPUT));
            numeroInput.SendKeys(numero);
            var libellleFR_INPUT = WaitForElementIsVisible(By.Id(LibelleFR_INPUT));
            libellleFR_INPUT.SendKeys(libelleFr);

            var libelleAr_INPUT = WaitForElementIsVisible(By.Id(Libelle_Ar_INPUT));
            libelleAr_INPUT.SendKeys(libelleAr);

            var smigInput= WaitForElementIsVisible(By.Name(SMIG_INPUT));
            smigInput.SendKeys(smig);

            var MontantFTP_INPUT = WaitForElementIsVisible(By.Name(MONTANTTFP_INPUT));
            MontantFTP_INPUT.SendKeys(montantftp);
            var FraisProf_INPUT = WaitForElementIsVisible(By.XPath(FRAIS_PROFESSIONELS));
            FraisProf_INPUT.SendKeys(fraisProf);

            var POURCENTAGE_INPUT = WaitForElementIsVisible(By.XPath(POURCENTAGE));
            POURCENTAGE_INPUT.SendKeys(POURCENTAGE);
            var saveBtn = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
            saveBtn.Click();







        }


        public bool VerifierNumeroExist(string numero)
        {
            for (int i = 1; i <= GetNumberPagesBySize(); i++)
            {
                //nombre de ligne
                var codes = _webDriver.FindElements(By.XPath(NUMEROS_FROM_COLUMN));
                foreach (var element in codes)
                {
                    if (element.Text.Equals(numero))
                    {
                        return true;
                    }
                }
                if (i != GetNumberPagesBySize())
                {
                    GoToNextPage();
                }

            }
            return false;

        }

    }
}
