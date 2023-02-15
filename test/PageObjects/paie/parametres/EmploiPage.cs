using OpenQA.Selenium;
using System.ComponentModel.DataAnnotations;

namespace PageObjects.paie.parametres;

public class EmploiPage : PageBase
{
    public EmploiPage(IWebDriver webDriver) : base(webDriver)
    {
    }
    //const
    private const string CODE_INPUT = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-emploi/form/div/fieldset/div[1]/tsi-integer/p-inputnumber/span/input";
    private const string LibelleFR_INPUT = "libelleFr";
    private const string Libelle_Ar_INPUT = "libelleAr";
    private const string SAVE_BUTTON = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-emploi/form/tsi-modal-footer/div/button[2]";
    private const string NEW_BUTTON = "/html/body/app-root/app-layout/div/div[2]/div/app-emploi/tsi-generic-crud/div/p-toolbar/div/div/button[1]/span[2]";
    private const string CODES_FROM_COLUMN = "//*[@id=\"pr_id_4-table\"]/tbody/tr[*]/td[3]/tsi-integer-display/span";
    private const string DELETE_BUTTON = "//*[@id=\"pr_id_4-table\"]/tbody/tr[1]/td[2]/div/button";
    private const string DELETE_SAVE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-emploi/form/tsi-modal-footer/div/button[2]/span[2]";
    private const string CONFIRM_BUTTON = "/html/body/app-root/p-confirmdialog/div/div/div[3]/button[2]/span[2]";
    private const string FIRST_CODE = "//*[@id=\"pr_id_4-table\"]/tbody/tr[1]/td[3]/tsi-integer-display/span";
    private const string UPDATE_BUTTON = "//*[@id=\"pr_id_4-table\"]/tbody/tr[1]/td[1]/div/button";
    private const string SAVE_UPDATE = "/html/body/p-dynamicdialog/div/div/div[2]/app-create-or-edit-emploi/form/tsi-modal-footer/div/button[2]";
    public void AjouterEmployee(string code , string libelleFr,string libelleAr)
    {
        ScrollUp();
        var NewBtn = WaitForElementIsVisible(By.XPath(NEW_BUTTON));
        NewBtn.Click();
        var codeInput = WaitForElementIsVisible(By.XPath(CODE_INPUT));
        codeInput.SendKeys(code);
        var libellleFR_INPUT = WaitForElementIsVisible(By.Id(LibelleFR_INPUT));
        libellleFR_INPUT.SendKeys(libelleFr);
        var libelleAr_INPUT=WaitForElementIsVisible(By.Id(Libelle_Ar_INPUT));
        libelleAr_INPUT.SendKeys(libelleAr);
        var saveBtn = WaitForElementIsVisible(By.XPath(SAVE_BUTTON));
        saveBtn.Click();
        Thread.Sleep(2000);
        
    }

    public void DeleteEmployee()
    {
        var DeleteBtn = WaitForElementIsVisible(By.XPath(DELETE_BUTTON));
        DeleteBtn.Click();
        var Save_Delete = WaitForElementIsVisible(By.XPath(DELETE_SAVE)); 
        Save_Delete.Click();
        Thread.Sleep(2000);
        var ConfirmBtn = WaitForElementIsVisible(By.XPath(CONFIRM_BUTTON));
        ConfirmBtn.Click();
        
    }
    public bool VerifierCodeExist(string code)
    {
        for(int i =1; i<= GetNumberPagesBySize(); i++)
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
            if(i != GetNumberPagesBySize())
            {
                GoToNextPage();
            }
            
        }
        return false;
    }
    public bool VerifierCodeNotExist(string code)
    {
        for (int i = 1; i < GetNumberPages(); i++)
        {
            //nombre de ligne
            var codes = _webDriver.FindElements(By.XPath(CODES_FROM_COLUMN));
            foreach (var element in codes)
            {
                if (!element.Text.Equals(code))
                {
                    return true;
                }
            }
            GoToNextPage();
        }
        return false;
    }

    public void ModifierEmployee(string code, string libelleFr, string libelleAr) { 
        var updateBtn=WaitForElementIsVisible(By.XPath(UPDATE_BUTTON)); ;
        updateBtn.Click();
        var codeInput = WaitForElementIsVisible(By.XPath(CODE_INPUT));
        var libellleFR_INPUT = WaitForElementIsVisible(By.Id(LibelleFR_INPUT));
        var libelleAr_INPUT = WaitForElementIsVisible(By.Id(Libelle_Ar_INPUT));
        
            codeInput.Clear();
            codeInput.SendKeys(code);
        
       
            libellleFR_INPUT.Clear();
            libellleFR_INPUT.SendKeys(libelleFr);
        
       
            libelleAr_INPUT.Clear();
            libelleAr_INPUT.SendKeys(libelleAr);
        
        var saveUpdate=WaitForElementIsVisible(By.XPath(SAVE_UPDATE));
        saveUpdate.Click();
        Thread.Sleep(2000);
    }

    public string getFirstCode()
    {
        var firstCode = WaitForElementIsVisible(By.XPath(FIRST_CODE));
        return firstCode.Text;
    }
}
