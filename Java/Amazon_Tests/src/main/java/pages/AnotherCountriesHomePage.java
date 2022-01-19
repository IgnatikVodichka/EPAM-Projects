package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

public class AnotherCountriesHomePage extends BasePage {

    @FindBy(xpath = "//span[contains(@class,'icp-nav-flag')]")
    private WebElement navCountryFlag;


    public AnotherCountriesHomePage(WebDriver driver) {
        super(driver);
    }

    public String getNavCountryFlagCLass() {
        return navCountryFlag.getAttribute("class");
    }
}
