using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.paie.parametres
{
    public class GrillesPage : PageBase
    {
        public GrillesPage(IWebDriver webDriver) : base(webDriver)
        { }
        private const string CODES_FROM_COLUMN = "//*[@id=\"pr_id_4-table\"]/tbody/tr[*]/td[3]";
        private const string CODE_INPUT = "//*[@id=\"code\"]";
        private const string NEW_BUTTONG = "/html/body/app-root/app-layout/div/div[2]/div/app-grille/tsi-generic-crud/div/p-toolbar/div/div/button[1]";
        private const string LibelleFR_INPUT = "libelleFr";
        private const string Libelle_Ar_INPUT = "libelleAr";
        private const string OBSERVATION_AR = "observationAr";
        private const string OBSERVATION_FR = "observationFr";
        private const string FIRST_CODE = "//*[@id=\"pr_id_4-table\"]/tbody/tr[1]/td[3]/span";
        private const string DELETE_BUTTON = "//*[@id=\"pr_id_4-table\"]/tbody/tr[2]/td[2]/div/button";
        private const string DELETE_SAVE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-grille/form/tsi-modal-footer/div/button[2]";
        private const string CONFIRM_BUTTON = "/html/body/app-root/p-confirmdialog/div/div/div[3]/button[2]";
        private const string DESCRIPTION_Fr_INPUT = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-grille/form/div/fieldset/div[6]/tsi-text-area/textarea";
        private const string DESCRIPTION_Ar_INPUT = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-grille/form/div/fieldset/div[7]/tsi-text-area/textarea";
        private const string SAVE_BUTTON = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-grille/form/tsi-modal-footer/div/button[2]/span[2]";
        private const string EDIT_BUTTON = "//*[@id=\"pr_id_4-table\"]/tbody/tr[1]/td[1]/div/button";
        private const string SAVE_UPDATE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-grille/form/tsi-modal-footer/div/button[2]";
 

        public void AjouterGrilles(string code, string libelleFr, string libelleAr, string obsF, string obsA, string descFr, string descAr)
        {
            var NewBtnG = WaitForElementIsVisible(By.XPath(NEW_BUTTONG));
            NewBtnG.Click();
            var codeInput = WaitForElementIsVisible(By.XPath(CODE_INPUT));
            codeInput.SendKeys(code);
            var libellleFR_INPUT = WaitForElementIsVisible(By.Id(LibelleFR_INPUT));
            libellleFR_INPUT.SendKeys(libelleFr);
            var libelleAr_INPUT = WaitForElementIsVisible(By.Id(Libelle_Ar_INPUT));
            libelleAr_INPUT.SendKeys(libelleAr);
            var observation_Fr = WaitForElementIsVisible(By.Id(OBSERVATION_FR));
            observation_Fr.SendKeys(obsF);
            var observation_Ar = WaitForElementIsVisible(By.Id(OBSERVATION_AR));
            observation_Ar.SendKeys(obsA);
            var description_Fr = WaitForElementIsVisible(By.XPath(DESCRIPTION_Fr_INPUT));
            description_Fr.SendKeys(descFr);
            var description_Ar = WaitForElementIsVisible(By.XPath(DESCRIPTION_Ar_INPUT));
            description_Ar.SendKeys(descAr);

            var saveBtn = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
            saveBtn.Click();
            Thread.Sleep(2000);
        }
        public void DeleteGrille()
        {
            var DeleteBtn = WaitForElementIsVisible(By.XPath(DELETE_BUTTON));
            DeleteBtn.Click();
            var Save_Delete = WaitForElementIsVisible(By.XPath(DELETE_SAVE));
            Save_Delete.Click();
            Thread.Sleep(2000);
            var ConfirmBtn = WaitForElementIsVisible(By.XPath(CONFIRM_BUTTON));
            ConfirmBtn.Click();
        }
        public void updateGrille(string code, string libelleFr, string libelleAr, string obsF, string obsA, string descFr, string descAr)
        {
            var updateBtn = WaitForElementIsVisible(By.XPath(EDIT_BUTTON));
            updateBtn.Click();
            var codeInput = WaitForElementIsVisible(By.XPath(CODE_INPUT));
            var libellleFR_INPUT = WaitForElementIsVisible(By.Id(LibelleFR_INPUT));
            var libelleAr_INPUT = WaitForElementIsVisible(By.Id(Libelle_Ar_INPUT));
            var observationF_INPUT=WaitForElementIsVisible(By.Id(OBSERVATION_FR));
            var observationA_INPUT= WaitForElementIsVisible(By.Id(OBSERVATION_AR));
            var descriptionF_INPUT= WaitForElementIsVisible(By.XPath(DESCRIPTION_Fr_INPUT));
            var descriptionAr_INPUT= WaitForElementIsVisible(By.XPath(DESCRIPTION_Ar_INPUT));


            codeInput.Clear();
            codeInput.SendKeys(code);

            libellleFR_INPUT.Clear();
            libellleFR_INPUT.SendKeys(libelleFr);

            libelleAr_INPUT.Clear();
            libelleAr_INPUT.SendKeys(libelleAr);

            observationF_INPUT.Clear();
            observationF_INPUT.SendKeys(obsF);


            observationA_INPUT.Clear();
            observationA_INPUT.SendKeys(obsA);



            descriptionF_INPUT.Clear();
            descriptionF_INPUT.SendKeys(descFr);

          

          

            descriptionAr_INPUT.Clear();
            descriptionAr_INPUT.SendKeys(descAr);

            var saveUpdate = WaitForElementIsVisible(By.XPath(SAVE_UPDATE));
            saveUpdate.Click();
            Thread.Sleep(2000);


        }
        public bool VerifierCodeExist(string code)
        {
            for (int i = 1; i <= GetNumberPagesBySize(); i++)
            {
                //nombre de ligne
                var codes = _webDriver.FindElements(By.XPath(CODES_FROM_COLUMN));
                foreach (var element in codes)
                {
                    if (element.Text.Equals(code))
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
        public void Delete(string code)
        {
            var codes = _webDriver.FindElements(By.XPath(CODES_FROM_COLUMN));

            foreach (var c in codes)
            {
                if (c.Text.Equals(code))
                {

                    var deleteBtn = WaitForElementIsVisible(By.XPath("//span[contains(text(),'" + code + "')]/../../../td[2]"));
                    deleteBtn.Click();

                    var saveBtn = WaitForElementIsVisible(By.XPath(DELETE_SAVE));
                    saveBtn.Click();
                    Thread.Sleep(2000);
                    var verifDeleteBtn = WaitForElementIsVisible(By.XPath(CONFIRM_BUTTON));
                    verifDeleteBtn.Click();
                }
            }
        }
        public string getFirstCode()
        {
            var firstCode = WaitForElementIsVisible(By.XPath(FIRST_CODE));
            return firstCode.Text;
        }
        public string getDefaultCode()
        {
            var firstCode = WaitForElementIsVisible(By.XPath(FIRST_CODE));
            return firstCode.Text;
        }
    }
}
