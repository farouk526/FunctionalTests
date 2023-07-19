using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Cast;
using OpenQA.Selenium.DevTools.V107.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PageObjects.Comptabilite_Generale.Ecriture;

    public class Nouvelle_Ecriture_ComptablePage : PageBase
{
	public Nouvelle_Ecriture_ComptablePage(IWebDriver webDriver):base(webDriver)
	{

	}

	private const string JOURNAL = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[1]/tsi-search-combo/p-dropdown/div";
    
    private const string COMPTE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[3]/p-celleditor/div/tsi-search-combo/p-dropdown/div";
    private const string COMPTE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[3]/p-celleditor/div/tsi-search-combo/p-dropdown/div";
    private const string NUMERO_ = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[2]/p-celleditor/tsi-integer/p-inputnumber/span/input";
    private const string NUMERO2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[2]/p-celleditor/tsi-integer/p-inputnumber/span/input";
    private const string NUMERO = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[2]/p-celleditor/tsi-integer-display";
    private const string TIERE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[5]/p-celleditor/div/tsi-search-combo/p-dropdown/div";
    private const string TIERE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[5]/p-celleditor/div/tsi-search-combo/p-dropdown/div";
    private const string JOURNAL_BY_TEXT = "//*[@id=\"pr_id_4_list\"]/p-dropdownitem[*]/li[@aria-label='{0}']/span";

    private const string COMPTE_BY_TEXT = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";
    private const string COMPTE_BY_TEXT2 = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";

    private const string TIERE_BY_TEXT = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";
    private const string TIERE_BY_TEXT2 = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";
    private const string AFFECTATION_TRESORERIE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[8]/p-celleditor/div/tsi-search-combo/p-dropdown/div";
    private const string AFFECTATION_TRESORERIE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[8]/p-celleditor/div/tsi-search-combo/p-dropdown";
    private const string NUMERO_SEQUENCE ="/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[9]";
    private const string NUMERO_SEQUENCE_INPUT="/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[9]/p-celleditor/tsi-text-box/input";
    private const string NUMERO_SEQUENCE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[9]";
    private const string NUMERO_SEQUENCE_INPUT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[9]/p-celleditor/tsi-text-box/input";
    private const string REFERENCE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[11]";
    private const string REFERENCE_INPUT="/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr/td[11]/p-celleditor/tsi-text-box/input";

    private const string REFERENCE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[11]";
    private const string REFERENCE_INPUT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[11]/p-celleditor/tsi-text-box/input";

    private const string OBSERVATION = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[13]";
    private const string OBSERVATION_INPUT = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[13]/p-celleditor/tsi-text-box/input";

    private const string OBSERVATION2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[13]";
    private const string OBSERVATION_INPUT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[13]/p-celleditor/tsi-text-box/input";

    private const string CLIENT = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[10]";
    private const string CLIENT_INPUT ="/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr/td[10]/p-celleditor/tsi-text-box/input";

    private const string CLIENT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[10]";

    private const string CLIENT_INPUT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[10]/p-celleditor/tsi-text-box/input";
    private const string LIBELLE_INPUT = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[4]";
    private const string LIBELLE_INPUT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[4]";
    private const string LIBELLE_WRITE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr/td[4]/p-celleditor/tsi-text-box/input";
    private const string LIBELLE_WRITE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[4]/p-celleditor/tsi-text-box/input";
    private const string TABLE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table";
    private const string AFFECTATION = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[12]/p-celleditor/div/tsi-search-combo/p-dropdown/div";
    private const string AFFECTATION_BY_TEXT = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";
    private const string AFFECTATION2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[12]/p-celleditor/div/tsi-search-combo/p-dropdown/div";
    private const string AFFECTATION_BY_TEXT2 = "/html/body/div/div/div/div[2]/ul/p-dropdownitem[*]/li[@aria-label='{0}']";
    private const string COMPTE_ASSOCIE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[3]/tsi-text-box/input";
	private const string ORIGINE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[4]/tsi-text-box/input";
	private const string NUMERO_PIECE1 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[6]/tsi-text-box/input";
	private const string DATE_ECRITURE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[5]/tsi-date-picker/p-calendar/span/input";
	private const string DATE_PIECE1 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[7]/tsi-date-picker/p-calendar/span/input";
	private const string DATE_PIECE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[9]/tsi-date-picker/p-calendar/span/input";
	private const string DEBIT_VALUES= "//*[@id=\"pr_id_5-table\"]/tbody/tr[*]/td[6]/p-celleditor/tsi-currency-societe-display/span";
	private const string CREDIT_VALUES = "//*[@id=\"pr_id_5-table\"]/tbody/tr[*]/td[7]/p-celleditor/tsi-currency-societe-display/span";
	private const string DEBIT_INPUT = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[6]";
    private const string DEBIT_INPUT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[6]";
    private const string DEBIT_WRITE = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[6]/p-celleditor/tsi-currency-societe-input/p-inputnumber/span/input";
    private const string DEBIT_WRITE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[6]/p-celleditor/tsi-currency-societe-input/p-inputnumber/span/input";
    private const string CREDIT_INPUT2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[7]";
    private const string CREDIT_WRITE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[2]/td[7]/p-celleditor/tsi-currency-societe-input/p-inputnumber/span/input";
    private const string VALIDER_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[1]/div/tsi-button/button";
    private const string CREDIT_INPUT = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/p-table/div/div[1]/table/tbody/tr[1]/td[7]/p-celleditor/tsi-currency-societe-input/p-inputnumber/span/input";
	private const string COMPTE_COMBO = "//*[@id=\"pr_id_5-table\"]/tbody/tr[1]/td[3]/p-celleditor/div/tsi-search-combo/p-dropdown";
	private const string NUMERO_PIECE2 = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[8]/tsi-text-box/input";
    private const string PLUS_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[2]/div[11]/p-tabview/div/div[2]/tsi-generic-editable-grid/div/div/button";
    private const string VALID_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-new-ecriture/div/div/div[1]/div/tsi-button/button";
    private const string CANCEL_BUTTON = "/html/body/p-dynamicdialog/div/div/div[2]/app-tsi-error-message/div/div/p-footer/button";
    
   

    public bool CheckValues()
    {
        bool result = false;
        var debits = _webDriver.FindElements(By.XPath(DEBIT_VALUES));
        var credits = _webDriver.FindElements(By.XPath(CREDIT_VALUES));

        float debitSum = 0;
        float creditSum = 0;

        for (int index = 0; index < debits.Count; index++)
        {
            var debitString = debits[index].Text;
            var creditString = credits[index].Text;
            var debitValue1 = float.Parse(debitString, CultureInfo.InvariantCulture);
            
            //var debitValue1 = float.Parse(debitString);
            var creditValue2 = float.Parse(creditString, CultureInfo.InvariantCulture);

                debitSum += debitValue1;
                creditSum += creditValue2;
                Console.WriteLine(debitSum);
            
        }

        if (debitSum==creditSum)
        {
            result = true;
        }

        return result;
    }


 

	public void AjouterNouvelleEcritureComptable(string journal,string origine, string dateE, string num1, string dateP1, string numP2, string dateP2, string numero,string compte,string libelle,string tiere,string Debit, string credit,string numeroSequenece,string client,string reference,string affectation,string observation,string credit2)
	{
        
        var journalInput = WaitForElementIsVisible(By.XPath(JOURNAL));
        journalInput.Click();
        Thread.Sleep(2000);
        var journalByText = _webDriver.FindElement(By.XPath(string.Format(JOURNAL_BY_TEXT, journal)));
        Thread.Sleep(2000);
        journalByText.Click();
        var origine_ = WaitForElementIsVisible(By.XPath(ORIGINE));
        origine_.SendKeys(origine);
        var DateEcriture = _webDriver.FindElement(By.XPath(DATE_ECRITURE));
        DateEcriture.Click();
        DateEcriture.SendKeys(dateE);
        DateEcriture.SendKeys(Keys.Tab);
        var numP1 = WaitForElementIsVisible(By.XPath(NUMERO_PIECE1));
        numP1.SendKeys(num1);
        var DatePiece1 = _webDriver.FindElement(By.XPath(DATE_PIECE1));
        DatePiece1.Click();
        DatePiece1.SendKeys(dateP1);
        DatePiece1.SendKeys(Keys.Tab);
        var numPiece2 = WaitForElementIsVisible(By.XPath(NUMERO_PIECE2));
        numPiece2.SendKeys(numP2);
        var DatePiece2 = _webDriver.FindElement(By.XPath(DATE_PIECE2));
        DatePiece2.Click();
        DatePiece2.SendKeys(dateP2);
        DatePiece2.SendKeys(Keys.Tab);
        var addBtn = WaitForElementIsVisible(By.XPath(PLUS_BUTTON));
        addBtn.Click();
        addBtn.Click();
       
        var numeroInput = WaitForElementIsVisible(By.XPath(NUMERO));
        numeroInput.Click();
        var numero_ = WaitForElementIsVisible(By.XPath(NUMERO_));
        numero_.SendKeys(Keys.Tab);
        var comptecombo = WaitForElementIsVisible(By.XPath(COMPTE));
        comptecombo.Click();    
        Thread.Sleep(2000);
        var comptebytext = _webDriver.FindElement(By.XPath(string.Format(COMPTE_BY_TEXT, compte)));
        comptebytext.Click();
        var Libelle = WaitForElementIsVisible(By.XPath(LIBELLE_INPUT));
        Libelle.Click();
        var LibelleInput = WaitForElementIsVisible(By.XPath(LIBELLE_WRITE));
        LibelleInput.Click();
        LibelleInput.SendKeys(libelle);
        LibelleInput.SendKeys(Keys.Tab);
        var tieres=WaitForElementIsVisible(By.XPath(TIERE));
        tieres.Click();
        Thread.Sleep(2000);
        var tiereByText = _webDriver.FindElement(By.XPath(string.Format(TIERE_BY_TEXT, tiere)));
        tiereByText.Click();
        var debit = WaitForElementIsVisible(By.XPath(DEBIT_INPUT));
        debit.Click();
        var debitInput = WaitForElementIsVisible(By.XPath(DEBIT_WRITE));
        debitInput.Click();
        debitInput.SendKeys(Debit);
        debitInput.SendKeys(Keys.Tab);
        var creditInput = WaitForElementIsVisible(By.XPath(CREDIT_INPUT));
        creditInput.SendKeys(credit);
        creditInput.SendKeys(Keys.Tab);
        var affectationTrésorie= WaitForElementIsVisible(By.XPath(AFFECTATION_TRESORERIE));
        affectationTrésorie.Click();
        var numeroSequence=WaitForElementIsVisible(By.XPath(NUMERO_SEQUENCE));
        numeroSequence.Click();
        var numeroSequenceInput = WaitForElementIsVisible(By.XPath(NUMERO_SEQUENCE_INPUT));
        numeroSequenceInput.Click();
        numeroSequenceInput.SendKeys(numeroSequenece);
        var clientI=WaitForElementIsVisible(By.XPath(CLIENT));
        clientI.Click();
        var clientInput = WaitForElementIsVisible(By.XPath(CLIENT_INPUT));
        clientInput.Click();
        clientInput.SendKeys(client);
        var referenceValue=WaitForElementIsVisible(By.XPath(REFERENCE));
        referenceValue.Click();
        var referenceInput = WaitForElementIsVisible(By.XPath(REFERENCE_INPUT));
        referenceInput.Click();
        referenceInput.SendKeys(reference);
        referenceInput.SendKeys(Keys.Tab);
        var affectationCombo = WaitForElementIsVisible(By.XPath(AFFECTATION));
        affectationCombo.Click();
        Thread.Sleep(2000);
        var affectationByText = _webDriver.FindElement(By.XPath(string.Format(AFFECTATION_BY_TEXT, affectation)));
        affectationByText.Click();
        var observationInput = WaitForElementIsVisible(By.XPath(OBSERVATION));
        observationInput.Click();
        var observationValue= WaitForElementIsVisible(By.XPath(OBSERVATION_INPUT));
        observationValue.SendKeys(observation);
        ScrollLeft();
        var numeroRow2 = WaitForElementIsVisible(By.XPath(NUMERO2));
        numeroRow2.SendKeys(Keys.Tab);
        var compteRow2=WaitForElementIsVisible(By.XPath(COMPTE2));
        compteRow2.Click();
        var compte2ByText = _webDriver.FindElement(By.XPath(string.Format(COMPTE_BY_TEXT2, compte)));
        compte2ByText.Click();
        var Libelle2 = WaitForElementIsVisible(By.XPath(LIBELLE_INPUT2));
        Libelle2.Click();
        var LibelleInput2 = WaitForElementIsVisible(By.XPath(LIBELLE_WRITE2));
        LibelleInput2.Click();
        LibelleInput2.SendKeys(libelle);
        LibelleInput2.SendKeys(Keys.Tab);
        var tieres2 = WaitForElementIsVisible(By.XPath(TIERE2));
        tieres2.Click();
        Thread.Sleep(2000);
        var tiereByText2 = _webDriver.FindElement(By.XPath(string.Format(TIERE_BY_TEXT2, tiere)));
        tiereByText2.Click();

        var creditInput2 = WaitForElementIsVisible(By.XPath(CREDIT_INPUT2));
        creditInput2.Click();
        var creditWrite2 = WaitForElementIsVisible(By.XPath(CREDIT_WRITE2));
        creditWrite2.SendKeys("22");
        creditWrite2.SendKeys(Keys.Tab);


       bool result= CheckValues();
        if (result==true)
        {

            var affectationTrésorie2 = WaitForElementIsVisible(By.XPath(AFFECTATION_TRESORERIE2));
            affectationTrésorie2.Click();

            var numeroSequence2 = WaitForElementIsVisible(By.XPath(NUMERO_SEQUENCE2));
            numeroSequence2.Click();
            var numeroSequenceInput2 = WaitForElementIsVisible(By.XPath(NUMERO_SEQUENCE_INPUT2));
            numeroSequenceInput2.Click();
            numeroSequenceInput2.SendKeys(numeroSequenece);

            var clientI2 = WaitForElementIsVisible(By.XPath(CLIENT2));
            clientI2.Click();
            var clientInput2 = WaitForElementIsVisible(By.XPath(CLIENT_INPUT2));
            clientInput2.Click();
            clientInput2.SendKeys(client);

            var referenceValue2 = WaitForElementIsVisible(By.XPath(REFERENCE2));
            referenceValue2.Click();
            var referenceInput2 = WaitForElementIsVisible(By.XPath(REFERENCE_INPUT2));
            referenceInput2.Click();
            referenceInput2.SendKeys(reference);
            referenceInput2.SendKeys(Keys.Tab);


            var affectationCombo2 = WaitForElementIsVisible(By.XPath(AFFECTATION2));
            affectationCombo2.Click();
            Thread.Sleep(2000);
            var affectationByText2 = _webDriver.FindElement(By.XPath(string.Format(AFFECTATION_BY_TEXT2, affectation)));
            affectationByText2.Click();


            var observationInput2 = WaitForElementIsVisible(By.XPath(OBSERVATION2));
            observationInput2.Click();
            var observationValue2 = WaitForElementIsVisible(By.XPath(OBSERVATION_INPUT2));
            observationValue2.SendKeys(observation);

            OnClickValidation();
            OnClickCancel();

        }

        OnClickValidation();
        OnClickCancel();



    }

    public void OnClickCancel()
    {
        var cancelButton = WaitForElementIsVisible(By.XPath(CANCEL_BUTTON));
        cancelButton.Click();
    }
    public void OnClickValidation()
    {
        var validButton = WaitForElementIsVisible(By.XPath(VALID_BUTTON));
        validButton.Click();

      
    }
    public void ScrollLeft()

    {
        Actions actions = new Actions(_webDriver);
        actions.SendKeys(Keys.ArrowRight).Perform();
        actions.SendKeys(Keys.ArrowLeft).Perform();
    }


}

