using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V107.Network;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using PageObjects.Comptabilite_Generale.Ecriture;
using PageObjects.Comptabilite_Generale.Parametres;
using PageObjects.paie.parametres;
using PageObjects.PARAMBASE.Autres_paramètres;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text.RegularExpressions;
using Tests.paie.parametre.Emplois;

namespace PageObjects;
 public class PageBase
{

    protected readonly IWebDriver _webDriver;
    protected PageBase(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }



    private const string HOME_PAGE_URL = "http://197.13.18.37:5000/app/home";
    private const string EMPLOIS_PAGE_URL = "http://197.13.18.37:5000/app/paie/parametres/emploi/emploi-list";
    private const string GRILLE_PAGE_URL = "http://197.13.18.37:5000/app/paie/parametres/grille/grille-list";
    private const string ANNEE_PAGE_URL = "http://197.13.18.37:5000/app/param-base/autres-params/annee/annees-list";
    private const string Nouvelle_Ecriture_Comptable_PAGE_URL = "http://197.13.18.37:5000/app/comptabilite-generale/ecritures/new-ecriture";
    private const string JOURNAUX_COMPTABLES_PAGE_URL = "http://197.13.18.37:5000/app/comptabilite-generale/parametres/journal/journal-list";
    private const string LISTE_DES_ANNEXES_PAGE_URL = "http://197.13.18.37:5000/app/comptabilite-generale/parametres/decempannexe/decempannexe-list";
    private const string PAGES_NUMBERS = "/html/body/app-root/app-layout/div/div[2]/div/app-emploi/tsi-generic-crud/div/tsi-generic-grid/p-table/div/p-paginator/div/span[2]/button";
    private const string NEXT_BUTTON = "//*[@id=\"pr_id_4\"]/p-paginator/div/button[3]";
    private const string ROW_NUMBER = "//*[@id=\"pr_id_4-table\"]/tbody/tr[*]/td[4]";
    private const string COL_NUMBER = "//*[@id=\"pr_id_4-table\"]/tbody/tr[1]/td[*]";
    private const string PAGE_SIZE = "//*[@id=\"pr_id_5_label\"]";
    private const string ALL_DATA_STRING = "//*[@id=\"pr_id_4\"]/div[3]";
    public HomePage GoToHomePage()
    {
        _webDriver.Navigate().GoToUrl(HOME_PAGE_URL);
        return new HomePage(_webDriver);
    }

    public EmploiPage GoToEmploisPage()
    {
        _webDriver.Navigate().GoToUrl(EMPLOIS_PAGE_URL);
        return new EmploiPage(_webDriver);
    }

    public GrillesPage GoToGrillesPages()
    {
        _webDriver.Navigate().GoToUrl(GRILLE_PAGE_URL);
        return new GrillesPage(_webDriver); 
    }
    public AnnéesPage GoToAnneePages()
    {
        _webDriver.Navigate().GoToUrl(ANNEE_PAGE_URL);
        return new AnnéesPage(_webDriver);
    }
    public Nouvelle_Ecriture_ComptablePage GoToNvleEcritureComptablePage()
    {
        _webDriver.Navigate().GoToUrl(Nouvelle_Ecriture_Comptable_PAGE_URL);
        return new Nouvelle_Ecriture_ComptablePage(_webDriver);
    }
    public JournauxComptablesPage GoToJornauxComptable()
    {
        _webDriver.Navigate().GoToUrl(JOURNAUX_COMPTABLES_PAGE_URL);
        return new JournauxComptablesPage(_webDriver);
    }
    public ListeDesAnnexesPage GoToListeDesAnnexes()
    {
        _webDriver.Navigate().GoToUrl(LISTE_DES_ANNEXES_PAGE_URL);
        return new ListeDesAnnexesPage(_webDriver);
    }

    public IWebElement WaitForElementIsVisible(By value, string elementName = null)
    {
        // Initialisation des variables
        int compteur = 1;
        bool isFound = false;
        IWebElement element = null;

        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3));
        while (compteur <= 10 && !isFound)
        {
            try
            {
                var elm = wait.Until(ExpectedConditions.ElementIsVisible(value));
                isFound = true;
                element = elm;
            }
            catch
            {
                compteur++;
            }
        }

        if (!isFound)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToShortDateString()} {DateTime.UtcNow.ToLongTimeString()}] [WaitForElementIsVisible] Element not visible {value}");

            if (elementName != null)
            {
                throw new Exception($"L'element {elementName} n'est pas visible dans la page.");
            }
            else
            
            {
                throw new Exception($"L'element {value} n'est pas visible dans la page.");
            }
        }

        return element;
    }

    //pagination method
    public int GetNumberPages()
    {
        var pages = _webDriver.FindElements(By.XPath(PAGES_NUMBERS));
        return pages.Count;
    }
   
    public int GetNumberPagesBySize()
    {
        #region old code
        //int rows = 0;
        //int v = 0;
        //for (int i = 1; i < GetNumberPages(); i++)
        //{
        //    rows =rows+GetNumberOfRows();
        //    int size = GetNumberOfRows();
        //    v= rows /size;
        //}

        //return v ;
        #endregion

        #region new code
        var pageSizeString = WaitForElementIsVisible(By.XPath(PAGE_SIZE)).Text;
        //convertir en nombre decimal
        var pageSizeInt = decimal.Parse(pageSizeString);
        //recuperation of all data=40
        var allDataString = WaitForElementIsVisible(By.XPath(ALL_DATA_STRING)).Text;
        //elimination des caractere 
        string pattern = @"\d+";
        Match match = Regex.Match(allDataString, pattern);
        decimal number = 0;
        if (match.Success)
        {
            number = int.Parse(match.Value);
        }

        return (int)Math.Ceiling(number/pageSizeInt);
        #endregion
    }
    //nombre de lignes pour chaque page 
    public int GetNumberOfRows()
    {
        Thread.Sleep(2000);
        var rows = _webDriver.FindElements(By.XPath(ROW_NUMBER));

        
        return rows.Count;
    }
    public int GetNumberOfCols()
    {
        var cols = _webDriver.FindElements(By.XPath(COL_NUMBER));
        return cols.Count;


    }

    public void GoToNextPage()
    {
        var nextBtn = WaitForElementIsVisible(By.XPath(NEXT_BUTTON));
        nextBtn.Click();
    }
    public void ScrollUp()
    { 
        ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.scrollTo(0, 0);");
    }
   
}

