using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Network;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Comptabilite_Generale.Parametres;

public class JournauxComptablesPage : PageBase
{
    public JournauxComptablesPage(IWebDriver webDriver) : base(webDriver)
    {
    }
    private const string NEW_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/p-toolbar/div/div[1]/button[1]";
    private const string CODE_INPUT = "code";
    private const string LIBELLE_INPUT = "libelle";
    private const string DATE_VERROUILLAGE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-journal/tsi-form/form/fieldset/fieldset/div/div[3]/div[2]/tsi-date-picker/p-calendar/span/input";
    private const string COMPTE_ASSOCIE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-journal/tsi-form/form/fieldset/fieldset/div/div[4]/div[2]/tsi-search-combo/p-dropdown";
    private const string COMPTE_ASSOCIE_TEXT = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";
    private const string Type_By_TEXT = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";
    private const string SAVE_BUTTON = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-journal/tsi-form/form/fieldset/tsi-modal-footer/div/button[2]";
    private const string TYPE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-journal/tsi-form/form/fieldset/fieldset/div/div[5]/div[2]/tsi-search-combo/p-dropdown";
    private const string CODES_FROM_COLUMN = "//*[@id=\"pr_id_4-table\"]/tbody/tr[1]/td[*]/tsi-integer-display/span";
    
    private const string FIRST_CODE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/tbody/tr[1]/td[3]/tsi-integer-display/span";
    private const string CONFIRM_BUTTON = "/html/body/app-root/p-confirmdialog/div/div/div[3]/button[2]";
    private const string TABLE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table";
    private const string DELETE_SAVE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-journal/tsi-form/form/fieldset/tsi-modal-footer/div/button[2]";
    private const string SEARCH_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[2]/div/p-button/button";
    private const string SEARCH_INPUT = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[2]/div/tsi-text-box/input";
    private const string DELETE_BY_TEXT = "//tsi-integer-display/span[text()={0}]/../../../td[2]/div/button";
    private const string UPDATE_BY_TEXT = "//tsi-integer-display/span[text()={0}]/../../../td/div/button";
   
    private const string FILTER_BUTTON_TYPE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[7]/p-columnfilter/div/button[1]";
    private const string FILTER_BUTTON_LIBELLE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[4]/p-columnfilter/div/button[1]";
    private const string FILTER_BUTTON_DATE_VEROUILLAGE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[5]/p-columnfilter/div/button[1]";
    private const string FILTER_BUTTON_COMPTE_ASSOCIE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[6]/p-columnfilter/div/button[1]";
    private const string FILTER_BUTTON_CODE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[3]/p-columnfilter/div/button[1]";
    private const string SEARCH_BY_CODE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[3]/p-columnfilter/div/p-columnfilterformelement/input";
    private const string SEARCH_BY_LIBELLE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[4]/p-columnfilter/div/p-columnfilterformelement/input";
    private const string SEARCH_BY_DATE_VERROUILLAGE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[5]/p-columnfilter/div/p-columnfilterformelement/input";
    private const string SEARCH_BY_COMPTE_ASSOCIE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[6]/p-columnfilter/div/p-columnfilterformelement/input";
    private const string SEARCH_BY_TYPE = "/html/body/app-root/app-layout/div/div[2]/div/app-journals/tsi-generic-crud/div/tsi-generic-grid/div/div[3]/p-table/div/div[2]/table/thead/tr[2]/th[7]/p-columnfilter/div/p-columnfilterformelement/input";
    public void AjouterJournalComptable(string code,string libelle,string dateVerrouillage,string compteAssocie,string type)
    {
        var NewBtn = WaitForElementIsVisible(By.XPath(NEW_BUTTON));
        NewBtn.Click();
        var codeInput = WaitForElementIsVisible(By.Id(CODE_INPUT));
        codeInput.SendKeys(code);
        var libelleInput = WaitForElementIsVisible(By.Id(LIBELLE_INPUT));
        libelleInput.SendKeys(libelle);
        var dateVerrouillagePicker = WaitForElementIsVisible(By.XPath(DATE_VERROUILLAGE));
        dateVerrouillagePicker.SendKeys(dateVerrouillage);
        dateVerrouillagePicker.SendKeys(Keys.Tab);
        var compteAssocieCombo = WaitForElementIsVisible(By.XPath(COMPTE_ASSOCIE));
        compteAssocieCombo.Click();

        var comptebytext = _webDriver.FindElement(By.XPath(string.Format(COMPTE_ASSOCIE_TEXT, compteAssocie)));
        comptebytext.Click();


        var typeCombo = WaitForElementIsVisible(By.XPath(TYPE));
        typeCombo.Click();
        var Typebytext = WaitForElementIsVisible(By.XPath(string.Format(Type_By_TEXT,type)));
        Typebytext.Click();
        var SaveButton = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
        SaveButton.Click();



    }

    public void DeleteJournalComptable()
    {
        var table=WaitForElementIsVisible(By.XPath(TABLE));
        table.Click();
        int rows = GetNumberOfRows();
        int deleteRowIndex = rows / 2;
        int deleteColIndex = 2; 
        var deleteButton = table.FindElement(By.XPath($".//tr[{deleteRowIndex}]/td[{deleteColIndex}]/div/button"));
        deleteButton.Click();

        var Save_Delete = WaitForElementIsVisible(By.XPath(DELETE_SAVE));
        Save_Delete.Click();
        var ConfirmBtn = WaitForElementIsVisible(By.XPath(CONFIRM_BUTTON));
        ConfirmBtn.Click();
    }

    public void DeleteJournalByCode(int code)
    {
     
        var selectedCode= WaitForElementIsVisible(By.XPath(string.Format(DELETE_BY_TEXT, code)));
        selectedCode.Click();
        var SaveButton = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
        SaveButton.Click();
        var confirmButton = WaitForElementIsVisible(By.XPath(CONFIRM_BUTTON));
        confirmButton.Click();

    }
    public void UpdateJournalByCode(int code,string libelle,string dateVerrouillage, string compteAssocie, string type)
    {

        var selectedCode = WaitForElementIsVisible(By.XPath(string.Format(UPDATE_BY_TEXT, code)));
        selectedCode.Click();
       
        var libelleInput = WaitForElementIsVisible(By.Id(LIBELLE_INPUT));
        libelleInput.Clear();
        libelleInput.SendKeys(libelle);
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        IWebElement clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(DATE_VERROUILLAGE)));
        //var dateVerrouillagePicker = WaitForElementIsVisible(By.XPath(DATE_VERROUILLAGE));
        clickableElement.Clear();
        clickableElement.SendKeys(dateVerrouillage);
        //dateVerrouillagePicker.Clear();
        clickableElement.SendKeys(Keys.Tab);
      
   
       
       
     
        
        //var compteAssocieCombo = WaitForElementIsVisible(By.XPath(COMPTE_ASSOCIE));
       
        //compteAssocieCombo.Click();
        //var comptebytext = WaitForElementIsVisible(By.XPath(string.Format(COMPTE_ASSOCIE_TEXT, compteAssocie)));
        //comptebytext.Click();
       
        //var typeCombo = WaitForElementIsVisible(By.XPath(TYPE));
        //typeCombo.Click();
        //var Typebytext = WaitForElementIsVisible(By.XPath(string.Format(Type_By_TEXT, type)));
        //Typebytext.Click();

        var SaveButton = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
        SaveButton.Click();
        var confirmButton = WaitForElementIsVisible(By.XPath(CONFIRM_BUTTON));
        confirmButton.Click();

    }


    public void SearchByCode(string code)
    {
        bool codeFound = false;
       
        var codeSearch = WaitForElementIsVisible(By.XPath(SEARCH_BY_CODE));
        codeSearch.SendKeys(code);
        var filterButtonByCode = WaitForElementIsVisible(By.XPath(FILTER_BUTTON_CODE));
         filterButtonByCode.Click();
      
        
           IWebElement ulCodes = _webDriver.FindElement(By.XPath("/html/body/div/ul"));

            IList<IWebElement> liCodes = ulCodes.FindElements(By.TagName("li"));
            filterButtonByCode.Click();



        for (int i = 0; i < liCodes.Count; i++)
        {

            WaitForElementIsVisible(By.XPath(FILTER_BUTTON_CODE)).Click();



            IWebElement ulOfCode = _webDriver.FindElement(By.XPath("/html/body/div/ul"));
            IList<IWebElement> listOfLiCode = ulOfCode.FindElements(By.TagName("li"));

            IWebElement liCode = ulOfCode.FindElement(By.XPath("//li[contains(text(), '" + listOfLiCode[i].Text + "')]"));

            codeFound = true;
            if (codeFound) { 
            liCode.Click();
           }
            else break;


        }
     
        

        
    }
    public void SearchByLibelle(string libelle)
    {
        bool libelleFound = false;

        var codeSearch = WaitForElementIsVisible(By.XPath(SEARCH_BY_LIBELLE));
        codeSearch.SendKeys(libelle);
        var filterButtonByLibelle = WaitForElementIsVisible(By.XPath(FILTER_BUTTON_LIBELLE));
        filterButtonByLibelle.Click();




        IWebElement ulLibelles = _webDriver.FindElement(By.XPath("/html/body/div/ul"));

        IList<IWebElement> liLibelle = ulLibelles.FindElements(By.TagName("li"));
        filterButtonByLibelle.Click();



        for (int i = 0; i < liLibelle.Count; i++)
        {

            WaitForElementIsVisible(By.XPath(FILTER_BUTTON_LIBELLE)).Click();



            IWebElement ulOfLibelle = _webDriver.FindElement(By.XPath("/html/body/div/ul"));
            IList<IWebElement> listOfLiLibelle = ulOfLibelle.FindElements(By.TagName("li"));

            IWebElement liLibelles = ulOfLibelle.FindElement(By.XPath("//li[contains(text(), '" + listOfLiLibelle[i].Text + "')]"));

            libelleFound = true;
            if (libelleFound)
            {
                liLibelles.Click();
            }
            else break;


        }

    }
    public void SearchByDateVerrouillage(string dateVerrouillage)
    {
        bool dateVerrouillageFound = false;

        var dateVerrouillageSearch = WaitForElementIsVisible(By.XPath(SEARCH_BY_DATE_VERROUILLAGE));
        dateVerrouillageSearch.SendKeys(dateVerrouillage);
        var filterButtonByDateVerrouillage = WaitForElementIsVisible(By.XPath(FILTER_BUTTON_DATE_VEROUILLAGE));
        filterButtonByDateVerrouillage.Click();




        IWebElement ulDateVerrouillage = _webDriver.FindElement(By.XPath("/html/body/div/ul"));

        IList<IWebElement> liDateVerrouillage = ulDateVerrouillage.FindElements(By.TagName("li"));
        filterButtonByDateVerrouillage.Click();



        for (int i = 0; i < liDateVerrouillage.Count; i++)
        {

            WaitForElementIsVisible(By.XPath(FILTER_BUTTON_DATE_VEROUILLAGE)).Click();



            IWebElement ulOfDateVerrouillage = _webDriver.FindElement(By.XPath("/html/body/div/ul"));
            IList<IWebElement> listOfLiDateVerrouillage = ulOfDateVerrouillage.FindElements(By.TagName("li"));

            IWebElement liDateVerrouillages = ulOfDateVerrouillage.FindElement(By.XPath("//li[contains(text(), '" + listOfLiDateVerrouillage[i].Text + "')]"));

            dateVerrouillageFound = true;
            if (dateVerrouillageFound)
            {
                liDateVerrouillages.Click();
            }
            else break;


        }
    }
    public void SearchByCompteAssocié(string CompteAssocié)
    {
        bool CompteAssociéFound = false;

        var CompteAssociéSearch = WaitForElementIsVisible(By.XPath(SEARCH_BY_COMPTE_ASSOCIE));
        CompteAssociéSearch.SendKeys(CompteAssocié);
        var filterButtonByCompteAssocié = WaitForElementIsVisible(By.XPath(FILTER_BUTTON_COMPTE_ASSOCIE));
        filterButtonByCompteAssocié.Click();




        IWebElement ulCompteAssocié = _webDriver.FindElement(By.XPath("/html/body/div/ul"));

        IList<IWebElement> liCompteAssocié = ulCompteAssocié.FindElements(By.TagName("li"));
        filterButtonByCompteAssocié.Click();



        for (int i = 0; i < liCompteAssocié.Count; i++)
        {

            WaitForElementIsVisible(By.XPath(FILTER_BUTTON_CODE)).Click();



            IWebElement ulOfCompteAssocié = _webDriver.FindElement(By.XPath("/html/body/div/ul"));
            IList<IWebElement> listOfLiCompteAssocié = ulOfCompteAssocié.FindElements(By.TagName("li"));

            IWebElement liCompteAssocie = ulOfCompteAssocié.FindElement(By.XPath("//li[contains(text(), '" + listOfLiCompteAssocié[i].Text + "')]"));

            CompteAssociéFound = true;
            if (CompteAssociéFound)
            {
                liCompteAssocie.Click();
            }
            else break;


        }
    }
    public void SearchByType(string type)
    {
        bool TypeFound = false;

        var TypeSearch = WaitForElementIsVisible(By.XPath(SEARCH_BY_TYPE));
        TypeSearch.SendKeys(type);
        var filterButtonByType = WaitForElementIsVisible(By.XPath(FILTER_BUTTON_TYPE));
        filterButtonByType.Click();




        IWebElement ulType = _webDriver.FindElement(By.XPath("/html/body/div/ul"));

        IList<IWebElement> liType = ulType.FindElements(By.TagName("li"));
        filterButtonByType.Click();



        for (int i = 0; i < liType.Count; i++)
        {

            WaitForElementIsVisible(By.XPath(FILTER_BUTTON_TYPE)).Click();



            IWebElement ulOfType = _webDriver.FindElement(By.XPath("/html/body/div/ul"));
            IList<IWebElement> listOfLiType = ulOfType.FindElements(By.TagName("li"));

            IWebElement liTypes = ulOfType.FindElement(By.XPath("//li[contains(text(), '" + listOfLiType[i].Text + "')]"));

            TypeFound = true;
            if (TypeFound)
            {
                liTypes.Click();
            }
            else break;


        }
    }
    public void SearchByValue(string value)
    {
        var searchInput = WaitForElementIsVisible(By.XPath(SEARCH_INPUT));
        searchInput.SendKeys(value);
        var searchbutton = WaitForElementIsVisible(By.XPath(SEARCH_BUTTON));
        searchbutton.Click();
    }
    public string GetFirstCode()
    {
        var firstCode = WaitForElementIsVisible(By.XPath(FIRST_CODE));
        return firstCode.Text;
    }
    public string getDefaultCode()
    {
        var firstCode = WaitForElementIsVisible(By.XPath(FIRST_CODE));
        return firstCode.Text;
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
}
