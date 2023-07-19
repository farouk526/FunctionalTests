using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PageObjects.Comptabilite_Generale.Parametres;

    public class ListeDesAnnexesPage:PageBase
{
	public ListeDesAnnexesPage(IWebDriver webDriver) : base(webDriver)
    {

	}
    private const string NEW_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-decempannexe/tsi-generic-crud/div/p-toolbar/div/div[1]/button[1]";
    private const string CODE_INPUT = "code";
    private const string LIBELLE_INPUT = "libelle";
    private const string OBSERVATION = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-decempannexe/tsi-form/form/fieldset/div/fieldset/div/div[3]/div[2]/tsi-text-area/textarea";
    private const string CODE_BUTTON = "button";
    private const string DELETE_BY_TEXT = "//tsi-integer-display/span[text()={0}]/../../../td[2]/div/button";
    private const string SAVE_BUTTON = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-decempannexe/tsi-form/form/fieldset/tsi-modal-footer/div/button[2]";
    public void AjouterListeDesAnnexes(string code, string libelle, string observation)
    {
        var NewBtn = WaitForElementIsVisible(By.XPath(NEW_BUTTON));
        NewBtn.Click();
        var codeInput = WaitForElementIsVisible(By.Id(CODE_INPUT));
        codeInput.SendKeys(code);
      
        
            var libelleInput = WaitForElementIsVisible(By.Id(LIBELLE_INPUT));
            libelleInput.SendKeys(libelle);
         
            
                var observationInput = WaitForElementIsVisible(By.XPath(OBSERVATION));
                observationInput.SendKeys(observation);
            
        

        var SaveBtn = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
        SaveBtn.Click();
        IWebElement modalDialog = WaitForElementIsVisible(By.XPath("//div[@class='p-dialog-content ng-tns-c89-1254']"));
        var x = modalDialog.Text;
        Console.WriteLine("The value of the number is: {0}", x);


    }
    public IEnumerable<string> Verifier()
    {
        bool verif = false;
        string searchCode = "Code";
        string searchLibelle = "Libelle";

       
        IWebElement modalDialog = WaitForElementIsVisible(By.XPath("//div[@class='p-dialog-content ng-tns-c89-1254']"));
        var x = modalDialog.Text;
        string code = @"\b" + Regex.Escape(searchCode) + @"\b";
        string libelle = @"\b" + Regex.Escape(searchLibelle) + @"\b";
        Match foundCode = Regex.Match(x, code, RegexOptions.IgnoreCase);
        Match foundLibelle = Regex.Match(x, libelle, RegexOptions.IgnoreCase);
       
            string Code = foundCode.Value;
          
            string Libelle = foundLibelle.Value;
           
           IEnumerable<string> stringEnumerable = new List<string>
         {
            Code,
          Libelle,
        };
       
        return stringEnumerable;

    }
    public void DeleteListeDesAnnexes(int code)
    {

        var selectedCode = WaitForElementIsVisible(By.XPath(string.Format(DELETE_BY_TEXT, code)));
        selectedCode.Click();
        var SaveButton = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
        SaveButton.Click();
        //var confirmButton = WaitForElementIsVisible(By.XPath(CONFIRM_BUTTON));
        //confirmButton.Click();

    }
}

