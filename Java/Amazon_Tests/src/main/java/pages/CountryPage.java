package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.ui.Select;

public class CountryPage extends BasePage {

    @FindBy(xpath = "//select[@id='icp-selected-country' or @id='icp-dropdown']")
    private WebElement countriesDropDown;

    @FindBy(xpath = "//input[@class='a-button-input']")
    private WebElement goToCountriesWebSiteButton;

    Actions action = new Actions(driver);


    public CountryPage(WebDriver driver) {
        super(driver);
    }

    public void closeDropDown(){
        action.moveByOffset(350 , 0).click().perform();
    }

    public void clickGoToCountriesWebSiteButton(){
        goToCountriesWebSiteButton.click();
    }

    public void chooseCountry(final String country) {
        Select select = new Select(countriesDropDown);
        select.selectByVisibleText(country);
    }
}
