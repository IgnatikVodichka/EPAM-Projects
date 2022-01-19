package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.ui.Select;

public class SettingsPage extends BasePage {

    @FindBy(xpath = "//select[@id='icp-sc-dropdown']")
    private WebElement currencyDropDown;

    @FindBy(xpath = "//input[@aria-labelledby='icp-btn-save-announce']")
    private WebElement saveChangesButton;


    public SettingsPage(WebDriver driver) {
        super(driver);
    }

    public void clickSaveChangesButton(){
        saveChangesButton.click();
    }

    public void chooseCurrency(final String currencyCode) {
        Select select = new Select(currencyDropDown);
        select.selectByValue(currencyCode);
    }
}
